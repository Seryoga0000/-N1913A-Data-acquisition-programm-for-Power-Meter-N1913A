namespace DevicesLib
{
    partial class PMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.P_TSB_GO = new System.Windows.Forms.ToolStripButton();
            this.P_TSB_Pause = new System.Windows.Forms.ToolStripButton();
            this.P_TSB_STOP = new System.Windows.Forms.ToolStripButton();
            this.P_TSB_SET = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.PCB_Pause = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.PDataChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.PMeas_timer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.PTimeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.PTSL_CountTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.PMeas_timerSec = new System.Windows.Forms.Timer(this.components);
            this.PDataTable = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PTableAutoScroll = new System.Windows.Forms.CheckBox();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.PCB_IntTypeX = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PXmax = new System.Windows.Forms.TextBox();
            this.PLYmax = new System.Windows.Forms.Label();
            this.PLYmin = new System.Windows.Forms.Label();
            this.PLYstep = new System.Windows.Forms.Label();
            this.PYmax = new System.Windows.Forms.TextBox();
            this.PYmin = new System.Windows.Forms.TextBox();
            this.PYstep = new System.Windows.Forms.TextBox();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.PTSL_CountMeas = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PDataChart)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PDataTable)).BeginInit();
            this.Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.P_TSB_GO,
            this.P_TSB_Pause,
            this.P_TSB_STOP,
            this.P_TSB_SET,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.PCB_Pause,
            this.toolStripSeparator2,
            this.toolStripLabel1,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(571, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // P_TSB_GO
            // 
            this.P_TSB_GO.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.P_TSB_GO.Enabled = false;
            this.P_TSB_GO.Image = global::DevicesLib.Properties.Resources.GO;
            this.P_TSB_GO.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.P_TSB_GO.Name = "P_TSB_GO";
            this.P_TSB_GO.Size = new System.Drawing.Size(23, 22);
            this.P_TSB_GO.Text = "Пуск";
            this.P_TSB_GO.Click += new System.EventHandler(this.P_TSB_GO_Click);
            // 
            // P_TSB_Pause
            // 
            this.P_TSB_Pause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.P_TSB_Pause.Enabled = false;
            this.P_TSB_Pause.Image = global::DevicesLib.Properties.Resources.pause_2;
            this.P_TSB_Pause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.P_TSB_Pause.Name = "P_TSB_Pause";
            this.P_TSB_Pause.Size = new System.Drawing.Size(23, 22);
            this.P_TSB_Pause.Text = "toolStripButton1";
            this.P_TSB_Pause.Click += new System.EventHandler(this.P_TSB_Pause_Click);
            // 
            // P_TSB_STOP
            // 
            this.P_TSB_STOP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.P_TSB_STOP.Enabled = false;
            this.P_TSB_STOP.Image = global::DevicesLib.Properties.Resources.STOP;
            this.P_TSB_STOP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.P_TSB_STOP.Name = "P_TSB_STOP";
            this.P_TSB_STOP.Size = new System.Drawing.Size(23, 22);
            this.P_TSB_STOP.Text = "Стоп";
            this.P_TSB_STOP.Click += new System.EventHandler(this.P_TSB_STOP_Click);
            // 
            // P_TSB_SET
            // 
            this.P_TSB_SET.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.P_TSB_SET.Image = global::DevicesLib.Properties.Resources.SET;
            this.P_TSB_SET.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.P_TSB_SET.Name = "P_TSB_SET";
            this.P_TSB_SET.Size = new System.Drawing.Size(23, 22);
            this.P_TSB_SET.Text = "Настройки";
            this.P_TSB_SET.Click += new System.EventHandler(this.P_TSB_SET_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.AutoSize = false;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(70, 15);
            this.toolStripLabel2.Text = "Интервал:";
            // 
            // PCB_Pause
            // 
            this.PCB_Pause.AutoSize = false;
            this.PCB_Pause.Items.AddRange(new object[] {
            "5 сек.",
            "10 сек.",
            "15 сек.",
            "20 сек.",
            "30 сек.",
            "1 мин.",
            "2 мин.",
            "5 мин."});
            this.PCB_Pause.Name = "PCB_Pause";
            this.PCB_Pause.Size = new System.Drawing.Size(64, 23);
            this.PCB_Pause.Text = "15 сек.";
            this.PCB_Pause.Click += new System.EventHandler(this.PCB_Pause_Click);
            this.PCB_Pause.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PCB_Pause_MouseUp);
            this.PCB_Pause.TextChanged += new System.EventHandler(this.PCB_Pause_TextChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(112, 22);
            this.toolStripLabel1.Text = "                                   ";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // PDataChart
            // 
            this.PDataChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PDataChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.IsStartedFromZero = false;
            chartArea1.AxisX.LabelStyle.Angle = -30;
            chartArea1.AxisX.LabelStyle.Format = "{0:d/MMM HH:mm}";
            chartArea1.AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisX.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gray;
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisX.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisY.LabelStyle.Format = "0.##E+00";
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gray;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea1.CursorX.Interval = 0D;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.CursorX.LineColor = System.Drawing.Color.Blue;
            chartArea1.CursorX.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            chartArea1.CursorY.IsUserSelectionEnabled = true;
            chartArea1.CursorY.LineColor = System.Drawing.Color.Blue;
            chartArea1.CursorY.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            chartArea1.Name = "ChartArea1";
            this.PDataChart.ChartAreas.Add(chartArea1);
            this.PDataChart.Location = new System.Drawing.Point(216, 25);
            this.PDataChart.Name = "PDataChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.Blue;
            series1.Name = "Series1";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            this.PDataChart.Series.Add(series1);
            this.PDataChart.Size = new System.Drawing.Size(355, 271);
            this.PDataChart.TabIndex = 1;
            this.PDataChart.Text = "chart1";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // PMeas_timer
            // 
            this.PMeas_timer.Interval = 1000;
            this.PMeas_timer.Tick += new System.EventHandler(this.PMeas_timer_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PTimeLabel,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel1,
            this.PTSL_CountTime,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel4,
            this.PTSL_CountMeas});
            this.statusStrip1.Location = new System.Drawing.Point(0, 356);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(571, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // PTimeLabel
            // 
            this.PTimeLabel.Name = "PTimeLabel";
            this.PTimeLabel.Size = new System.Drawing.Size(42, 17);
            this.PTimeLabel.Text = "Время";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.Gray;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(104, 17);
            this.toolStripStatusLabel1.Text = "Cлед. изм. через: ";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // PTSL_CountTime
            // 
            this.PTSL_CountTime.Name = "PTSL_CountTime";
            this.PTSL_CountTime.Size = new System.Drawing.Size(35, 17);
            this.PTSL_CountTime.Text = "####";
            // 
            // PMeas_timerSec
            // 
            this.PMeas_timerSec.Interval = 1000;
            this.PMeas_timerSec.Tick += new System.EventHandler(this.PMeas_timerSec_Tick);
            // 
            // PDataTable
            // 
            this.PDataTable.BackgroundColor = System.Drawing.Color.White;
            this.PDataTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PDataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PDataTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.PDataTable.Dock = System.Windows.Forms.DockStyle.Left;
            this.PDataTable.Location = new System.Drawing.Point(0, 25);
            this.PDataTable.Name = "PDataTable";
            this.PDataTable.RowHeadersVisible = false;
            this.PDataTable.Size = new System.Drawing.Size(216, 331);
            this.PDataTable.TabIndex = 3;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Время";
            this.Column1.Name = "Column1";
            this.Column1.Width = 108;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Показания";
            this.Column2.Name = "Column2";
            this.Column2.Width = 106;
            // 
            // PTableAutoScroll
            // 
            this.PTableAutoScroll.AutoSize = true;
            this.PTableAutoScroll.Checked = true;
            this.PTableAutoScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PTableAutoScroll.Location = new System.Drawing.Point(254, 4);
            this.PTableAutoScroll.Name = "PTableAutoScroll";
            this.PTableAutoScroll.Size = new System.Drawing.Size(102, 17);
            this.PTableAutoScroll.TabIndex = 4;
            this.PTableAutoScroll.Text = "Автопрокрутка";
            this.PTableAutoScroll.UseVisualStyleBackColor = true;
            this.PTableAutoScroll.CheckedChanged += new System.EventHandler(this.PTableAutoScroll_CheckedChanged);
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Panel2.Controls.Add(this.PCB_IntTypeX);
            this.Panel2.Controls.Add(this.label1);
            this.Panel2.Controls.Add(this.PXmax);
            this.Panel2.Controls.Add(this.PLYmax);
            this.Panel2.Controls.Add(this.PLYmin);
            this.Panel2.Controls.Add(this.PLYstep);
            this.Panel2.Controls.Add(this.PYmax);
            this.Panel2.Controls.Add(this.PYmin);
            this.Panel2.Controls.Add(this.PYstep);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel2.Location = new System.Drawing.Point(216, 296);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(355, 60);
            this.Panel2.TabIndex = 38;
            this.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel2_Paint);
            // 
            // PCB_IntTypeX
            // 
            this.PCB_IntTypeX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PCB_IntTypeX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PCB_IntTypeX.FormattingEnabled = true;
            this.PCB_IntTypeX.Items.AddRange(new object[] {
            "авт.",
            "сек.",
            "мин.",
            "час.",
            "сут.",
            "инт."});
            this.PCB_IntTypeX.Location = new System.Drawing.Point(238, 31);
            this.PCB_IntTypeX.Name = "PCB_IntTypeX";
            this.PCB_IntTypeX.Size = new System.Drawing.Size(52, 21);
            this.PCB_IntTypeX.TabIndex = 53;
            this.PCB_IntTypeX.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(194, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 52;
            this.label1.Text = "Xшаг";
            // 
            // PXmax
            // 
            this.PXmax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PXmax.ForeColor = System.Drawing.Color.Black;
            this.PXmax.Location = new System.Drawing.Point(194, 31);
            this.PXmax.Multiline = true;
            this.PXmax.Name = "PXmax";
            this.PXmax.Size = new System.Drawing.Size(43, 21);
            this.PXmax.TabIndex = 49;
            this.PXmax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PXmax.DoubleClick += new System.EventHandler(this.PXmax_DoubleClick);
            // 
            // PLYmax
            // 
            this.PLYmax.AutoSize = true;
            this.PLYmax.ForeColor = System.Drawing.Color.Black;
            this.PLYmax.Location = new System.Drawing.Point(140, 15);
            this.PLYmax.Name = "PLYmax";
            this.PLYmax.Size = new System.Drawing.Size(40, 13);
            this.PLYmax.TabIndex = 48;
            this.PLYmax.Text = "Yмакс";
            // 
            // PLYmin
            // 
            this.PLYmin.AutoSize = true;
            this.PLYmin.ForeColor = System.Drawing.Color.Black;
            this.PLYmin.Location = new System.Drawing.Point(84, 15);
            this.PLYmin.Name = "PLYmin";
            this.PLYmin.Size = new System.Drawing.Size(34, 13);
            this.PLYmin.TabIndex = 47;
            this.PLYmin.Text = "Yмин";
            // 
            // PLYstep
            // 
            this.PLYstep.AutoSize = true;
            this.PLYstep.ForeColor = System.Drawing.Color.Black;
            this.PLYstep.Location = new System.Drawing.Point(35, 15);
            this.PLYstep.Name = "PLYstep";
            this.PLYstep.Size = new System.Drawing.Size(33, 13);
            this.PLYstep.TabIndex = 46;
            this.PLYstep.Text = "Yшаг";
            // 
            // PYmax
            // 
            this.PYmax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PYmax.ForeColor = System.Drawing.Color.Black;
            this.PYmax.Location = new System.Drawing.Point(141, 31);
            this.PYmax.Multiline = true;
            this.PYmax.Name = "PYmax";
            this.PYmax.Size = new System.Drawing.Size(43, 21);
            this.PYmax.TabIndex = 43;
            this.PYmax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PYmax.DoubleClick += new System.EventHandler(this.PYmax_DoubleClick);
            // 
            // PYmin
            // 
            this.PYmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PYmin.ForeColor = System.Drawing.Color.Black;
            this.PYmin.Location = new System.Drawing.Point(88, 31);
            this.PYmin.Multiline = true;
            this.PYmin.Name = "PYmin";
            this.PYmin.Size = new System.Drawing.Size(43, 21);
            this.PYmin.TabIndex = 40;
            this.PYmin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PYmin.TextChanged += new System.EventHandler(this.PYmin_TextChanged);
            this.PYmin.DoubleClick += new System.EventHandler(this.PYmin_DoubleClick);
            // 
            // PYstep
            // 
            this.PYstep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PYstep.ForeColor = System.Drawing.Color.Black;
            this.PYstep.Location = new System.Drawing.Point(35, 31);
            this.PYstep.Multiline = true;
            this.PYstep.Name = "PYstep";
            this.PYstep.Size = new System.Drawing.Size(43, 21);
            this.PYstep.TabIndex = 36;
            this.PYstep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PYstep.TextChanged += new System.EventHandler(this.PYstep_TextChanged);
            this.PYstep.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.PYstep_MouseDoubleClick);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.ForeColor = System.Drawing.Color.Gray;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel3.Text = "|";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(113, 17);
            this.toolStripStatusLabel4.Text = "Кол-во измерений:";
            // 
            // PTSL_CountMeas
            // 
            this.PTSL_CountMeas.Name = "PTSL_CountMeas";
            this.PTSL_CountMeas.Size = new System.Drawing.Size(35, 17);
            this.PTSL_CountMeas.Text = "####";
            // 
            // PMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 378);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.PTableAutoScroll);
            this.Controls.Add(this.PDataTable);
            this.Controls.Add(this.PDataChart);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.MinimumSize = new System.Drawing.Size(587, 416);
            this.Name = "PMainForm";
            this.Text = "Программа сбора данных прибора N1913A";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PMainForm_FormClosing);
            this.Load += new System.EventHandler(this.PMainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PDataChart)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PDataTable)).EndInit();
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton P_TSB_GO;
        private System.Windows.Forms.ToolStripButton P_TSB_STOP;
        private System.Windows.Forms.ToolStripButton P_TSB_SET;
        private System.Windows.Forms.DataVisualization.Charting.Chart PDataChart;
        private System.Windows.Forms.ToolStripComboBox PCB_Pause;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer PMeas_timer;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel PTimeLabel;
        private System.Windows.Forms.Timer PMeas_timerSec;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.DataGridView PDataTable;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel PTSL_CountTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.CheckBox PTableAutoScroll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.TextBox PYmax;
        internal System.Windows.Forms.TextBox PYmin;
        internal System.Windows.Forms.TextBox PYstep;
        internal System.Windows.Forms.Label PLYmax;
        internal System.Windows.Forms.Label PLYmin;
        internal System.Windows.Forms.Label PLYstep;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox PXmax;
        private System.Windows.Forms.ToolStripButton P_TSB_Pause;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.ComboBox PCB_IntTypeX;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel PTSL_CountMeas;
    }
}