using System;
using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;
using Modbus.Device;

namespace BoilerMonitor.Helper
{
    internal class DigitalTubeHelper
    {
        private ModbusMaster _master;

        public byte SlaveAddress { set; get; }

        private string _contentCache;

        public DigitalTubeHelper(SerialPort serialPort, byte slaveAddress)
        {
            _master = ModbusSerialMaster.CreateRtu(serialPort);
            _master.Transport.WriteTimeout = 1000;
            SlaveAddress = slaveAddress;
        }

        public Task<bool> GetBlink(int seq)
        {
            var task = _master.ReadHoldingRegistersAsync(SlaveAddress, 8, 1);
            return task.ContinueWith(t =>
            {
                var value = t.Result; //得到异步返回的结果
                byte status = 1;
                if (seq > 1)
                {
                    status = (byte)(status << (seq - 1));
                }
                return (value[0] & status) == status; //将结果转换位bool
            }
            );
            
            /*var value = _master.ReadHoldingRegisters(SlaveAddress, 8, 1);
            byte status = 1;
            if (seq > 1)
            {
                status = (byte)(status << (seq - 1));
            }
            return (value[0] & status) == status;*/
        }

        public Task<byte> GetBlink()
        {
            var task = _master.ReadHoldingRegistersAsync(SlaveAddress, 8, 1);
            return task.ContinueWith(t => (byte)t.Result[0]);
        }

        //设置指定位置的闪烁
        public void SetBlink(int seq, bool blink)
        {
            byte status = (byte)(blink ? 1 : 0);
            if (seq > 1)
            {
                status = (byte)(status << seq - 1);
            }
            SetBlink(status);
        }

        //设置闪烁，每一位代表一个位置
        private void SetBlink(byte blink)
        {
            _master.WriteSingleRegisterAsync(SlaveAddress, 8, blink);
        }

        //设置显示内容
        public void ShowContent(string content)
        {
            if (content == _contentCache)
            {
                return;
            }

            // 0b0000_0000 0b0000_0000 0b0000_0000 0b0000_0000
            // 0b0001_0000
            var bytes = new byte[4];
            bytes[0] |= ParseSymbol(content);
            bytes[0] |= ParseDot(content);
            var intBytes = ParseInt(content);
            bytes[1] = intBytes[1];
            bytes[2] = intBytes[2];
            bytes[3] = intBytes[3];
            var data = new ushort[2];
            data[0] = (ushort)((bytes[0] << 8) | bytes[1]);
            data[1] = (ushort)((bytes[2] << 8) | bytes[3]);

          /*  data[0] = BitConverter.ToUInt16(bytes, 0);
            data[1] = BitConverter.ToUInt16(bytes, 2);*/
            _master.WriteMultipleRegistersAsync(SlaveAddress, 6, data);
        }

        //解析整数部分
        private byte[] ParseInt(string content)
        {
            content = content.Trim();
            var value = content.Replace("-", "").Replace(".", "");
            var number = int.Parse(value);
            number &= 0b0000_0000_1111_1111_1111_1111_1111_1111;
            return BitConverter.GetBytes(number).Reverse().ToArray();
        }

        //解析小数点
        private byte ParseDot(string content)
        {
            //1.234
            if (string.IsNullOrEmpty(content) || content.Trim().Length == 0)
            {
                throw new System.Exception("内容为空");
            }
            var index = content.Trim().IndexOf(".", System.StringComparison.Ordinal);
            if (index == -1)
            {
                return 0b0000_0000;
            }

            if (index == 0 || index == content.Trim().Length - 1)
            {
                throw new System.Exception("小数点位置错误");
            }
            if (index != content.Trim().LastIndexOf(".", System.StringComparison.Ordinal))
            {
                throw new System.Exception("小数点位置错误");
            }
            return ((byte)((content.Trim().Length - index - 1) & 0b0000_1111));
        }

        //解析正负号
        private byte ParseSymbol(string content)
        {
            if (string.IsNullOrEmpty(content) || content.Trim().Length == 0)
            {
                throw new System.Exception("内容为空");
            }

            int indexOf = content.Trim().IndexOf("-");
            if (indexOf > 0)
            {
                throw new System.Exception("符号位置错误");
            }
            if (content.Trim().LastIndexOf("-") != indexOf)
            {
                throw new System.Exception("符号位置错误");
            }
            return indexOf == 0 ? (byte)0b0001_0000 : (byte)0b0000_0000;
        }
    }
}
