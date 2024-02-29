using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modbus.Device;

namespace BoilerMonitor.Helper
{
    internal class BoilerHelper
    {
        private Modbus.Device.ModbusMaster _master;

        public byte SlaveAddress { set; get; }

        public BoilerHelper(SerialPort serialPort, byte slaveAddress)
        {
            _master = ModbusSerialMaster.CreateRtu(serialPort);
            _master.Transport.WriteTimeout = 1000;
            SlaveAddress = slaveAddress;
        }

        //得到液位
        public Task<int> ReadLiquidLevel()
        {
            var task = _master.ReadHoldingRegistersAsync(SlaveAddress, 2, 1);
            return task.ContinueWith(t => (int)t.Result[0]);
        }

        //得到水温
        public Task<double> ReadTemperature()
        {
            var task = _master.ReadHoldingRegistersAsync(SlaveAddress, 1, 1);
            return  task.ContinueWith(t => t.Result[0] / 10D);
        }

        //得到运行状态
        public Task<bool> ReadRuningStatus()
        {
            var task = _master.ReadCoilsAsync(SlaveAddress, 0, 1);
            return task.ContinueWith(t => t.Result[0]);
/*            var readCoils = _master.ReadCoils(SlaveAddress, 0, 1);
            return readCoils[0];*/
        }

        //设置运行状态
        public void setRunningStatus(bool running)
        {
            _master.WriteSingleCoilAsync(SlaveAddress, 0, running);
        }
    }
}
