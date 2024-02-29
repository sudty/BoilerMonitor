using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BoilerMonitor.Helper;

namespace BoilerMonitor
{
    public partial class MainForm : Form
    {
        private BoilerHelper boilerHelper;
        private DewPointHelper dewPointHelper;
        private DigitalTubeHelper digitalTubeHelper;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var appSettings = ConfigurationManager.AppSettings;
            var serialPort = new SerialPort()
            {
                PortName = appSettings["dewPoint.serial.PortName"],
                BaudRate = int.Parse(appSettings["dewPoint.serial.BauRate"]),
                DataBits = int.Parse(appSettings["dewPoint.serial.DataBits"]),
                Parity = (Parity)Enum.Parse(typeof(Parity), appSettings["dewPoint.serial.Parity"]),
                StopBits = (StopBits)
                    Enum.Parse(typeof(StopBits), appSettings["dewPoint.serial.StopBits"]),
            };
            serialPort.Open();
            dewPointHelper = new DewPointHelper(
                serialPort,
                byte.Parse(appSettings["dewPoint.temperature.slave"])
            );
            digitalTubeHelper = new DigitalTubeHelper(
                serialPort,
                byte.Parse(appSettings["dewPoint.digitalTube.slave"])
            );
            dewPointHelper = new DewPointHelper(
                serialPort,
                byte.Parse(appSettings["dewPoint.temperature.slave"])
            );
            digitalTubeHelper = new DigitalTubeHelper(
                serialPort,
                byte.Parse(appSettings["dewPoint.digitalTube.slave"])
            );
            var serialPort2 = new SerialPort()
            {
                PortName = appSettings["boiler.serial.PortName"],
                BaudRate = int.Parse(appSettings["boiler.serial.BauRate"]),
                DataBits = int.Parse(appSettings["boiler.serial.DataBits"]),
                Parity = (Parity)Enum.Parse(typeof(Parity), appSettings["boiler.serial.Parity"]),
                StopBits = (StopBits)
                    Enum.Parse(typeof(StopBits), appSettings["boiler.serial.StopBits"]),
            };
            serialPort2.Open();
            boilerHelper = new BoilerHelper(serialPort2, byte.Parse(appSettings["boiler.slave"]));
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dewPointHelper
                .ReadRelativeHumidity()
                .ContinueWith(t =>
                {
                    this.Invoke(
                        new Action(() =>
                        {
                            relativeHumidityTs.VarValue = $"{t.Result:F1}";
                        })
                    );
                });

            dewPointHelper.ReadDewPointTemperature().ContinueWith(t =>
            {
                this.Invoke(new Action(() =>
                {
                    dewPointTemperatureTs.VarValue = $"{t.Result:F1}";
                }));
            });


            boilerHelper.ReadLiquidLevel().ContinueWith(t =>
            {
                this.Invoke(new Action(() =>
                {
                    ucWaterTank1.Value = t.Result;
                }));
            });
            boilerHelper.ReadTemperature().ContinueWith(t =>
            {
                this.BeginInvoke(new Action(() =>
                {
                    var temperature = t.Result;
                    thermometerBar.Value = (decimal)t.Result;
                    digitalTubeHelper.ShowContent(t.Result.ToString());
                    AppendData(t.Result, DateTime.Now);

                    var upper = double.Parse(ConfigurationManager.AppSettings["boiler.temperature.upper"]);
                    var lower = double.Parse(ConfigurationManager.AppSettings["boiler.temperature.lower"]);
                    if (temperature >= upper)
                    {
                        boilerHelper.setRunningStatus(false);
                    }
                    else if (temperature <= lower)
                    {
                        boilerHelper.setRunningStatus(true);
                    }
                }));
            });
            boilerHelper.ReadRuningStatus().ContinueWith(t =>
            {
                this.Invoke(new Action(() =>
                {
                    runningStatus.IsOn = t.Result;
                    runningStatus.StateText = t.Result ? "运行" : "停止";
                }));
            });

        }

        private void AppendData(double temperature, DateTime time)
        {
            var series = chart1.Series[0];
            series.Points.AddXY(time, temperature);
            //清除多余数据
            while (series.Points.Count > 20)
            {
                series.Points.RemoveAt(0);
            }
            //重新绘制
            chart1.ResetAutoValues();
        }

    }
}
