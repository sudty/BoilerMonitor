namespace BoilerMonitor
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.ucWaterTank1 = new WinCustControls.UCWaterTank();
            this.thermometerBar = new HZH_Controls.Controls.UCThermometer();
            this.dewPointTemperatureTs = new XKTControl.xktTextShow();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.relativeHumidityTs = new XKTControl.xktTextShow();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.runningStatus = new WinCustControls.ULightControl();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // ucWaterTank1
            // 
            this.ucWaterTank1.Location = new System.Drawing.Point(134, 184);
            this.ucWaterTank1.Name = "ucWaterTank1";
            this.ucWaterTank1.RectWidth = 2;
            this.ucWaterTank1.Size = new System.Drawing.Size(64, 235);
            this.ucWaterTank1.TabIndex = 0;
            this.ucWaterTank1.Value = 50;
            // 
            // thermometerBar
            // 
            this.thermometerBar.GlassTubeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.thermometerBar.LeftTemperatureUnit = HZH_Controls.Controls.TemperatureUnit.C;
            this.thermometerBar.Location = new System.Drawing.Point(39, 176);
            this.thermometerBar.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.thermometerBar.MercuryColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.thermometerBar.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.thermometerBar.Name = "thermometerBar";
            this.thermometerBar.RightTemperatureUnit = HZH_Controls.Controls.TemperatureUnit.C;
            this.thermometerBar.Size = new System.Drawing.Size(61, 243);
            this.thermometerBar.SplitCount = 1;
            this.thermometerBar.TabIndex = 1;
            this.thermometerBar.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // dewPointTemperatureTs
            // 
            this.dewPointTemperatureTs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dewPointTemperatureTs.Location = new System.Drawing.Point(125, 16);
            this.dewPointTemperatureTs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dewPointTemperatureTs.Name = "dewPointTemperatureTs";
            this.dewPointTemperatureTs.Size = new System.Drawing.Size(130, 31);
            this.dewPointTemperatureTs.TabIndex = 2;
            this.dewPointTemperatureTs.TextFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.dewPointTemperatureTs.TextScale = 0.6F;
            this.dewPointTemperatureTs.Unit = "℃";
            this.dewPointTemperatureTs.VarName = null;
            this.dewPointTemperatureTs.VarValue = "30";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(20, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "露点温度";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(20, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "相对湿度";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // relativeHumidityTs
            // 
            this.relativeHumidityTs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.relativeHumidityTs.Location = new System.Drawing.Point(125, 76);
            this.relativeHumidityTs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.relativeHumidityTs.Name = "relativeHumidityTs";
            this.relativeHumidityTs.Size = new System.Drawing.Size(130, 31);
            this.relativeHumidityTs.TabIndex = 4;
            this.relativeHumidityTs.TextFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.relativeHumidityTs.TextScale = 0.6F;
            this.relativeHumidityTs.Unit = "RH";
            this.relativeHumidityTs.VarName = null;
            this.relativeHumidityTs.VarValue = "30";
            // 
            // chart1                                                                                                                                               
            // 
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            legend1.Title = "图例";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(281, 16);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "温度";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(507, 412);
            this.chart1.TabIndex = 6;
            this.chart1.Text = "chart1";
            title1.Name = "Title1";
            title1.Text = "水温增长趋势";
            this.chart1.Titles.Add(title1);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // runningStatus
            // 
            this.runningStatus.Location = new System.Drawing.Point(134, 126);
            this.runningStatus.Name = "runningStatus";
            this.runningStatus.Size = new System.Drawing.Size(75, 52);
            this.runningStatus.TabIndex = 8;
            this.runningStatus.Text = "uLightControl2";
            this.runningStatus.VarName = null;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.runningStatus);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.relativeHumidityTs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dewPointTemperatureTs);
            this.Controls.Add(this.thermometerBar);
            this.Controls.Add(this.ucWaterTank1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WinCustControls.UCWaterTank ucWaterTank1;
        private HZH_Controls.Controls.UCThermometer thermometerBar;
        private XKTControl.xktTextShow dewPointTemperatureTs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private XKTControl.xktTextShow relativeHumidityTs;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Timer timer1;
        private WinCustControls.ULightControl runningStatus;
    }
}

