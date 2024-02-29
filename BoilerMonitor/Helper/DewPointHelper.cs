using System.IO.Ports;
using System.Threading.Tasks;
using ModbusSerialMaster = Modbus.Device.ModbusSerialMaster;

namespace BoilerMonitor.Helper
{
    internal class DewPointHelper
    {
        private Modbus.Device.ModbusMaster _master;

        public byte SlaveAddress { set; get; }

        public DewPointHelper(SerialPort serialPort, byte slaveAddress)
        {
            _master = ModbusSerialMaster.CreateRtu(serialPort);
            _master.Transport.WriteTimeout = 1000;
            SlaveAddress = slaveAddress;
        }

        //读取露点温度
        public Task<double> ReadDewPointTemperature()
        {
            var task = _master.ReadHoldingRegistersAsync(SlaveAddress, 1, 1);
            return task.ContinueWith(t => t.Result[0] / 10D);
        }

        //读取相对湿度
        public Task<double> ReadRelativeHumidity()
        {
            var task = _master.ReadHoldingRegistersAsync(SlaveAddress, 0, 1);
            return task.ContinueWith(t => t.Result[0] / 10D);
        }
    }
}
