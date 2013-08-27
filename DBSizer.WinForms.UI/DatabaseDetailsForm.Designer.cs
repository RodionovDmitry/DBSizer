using DBSizer.Data;

namespace DBSizer.WinForms.UI
{
    partial class DatabaseDetailsForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btRefresh = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nudTopItemsCount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.rbRowCount = new System.Windows.Forms.RadioButton();
            this.rbIndexSize = new System.Windows.Forms.RadioButton();
            this.rbDataSize = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btClose = new System.Windows.Forms.Button();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.bsData = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTopItemsCount)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btRefresh);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nudTopItemsCount);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rbRowCount);
            this.groupBox1.Controls.Add(this.rbIndexSize);
            this.groupBox1.Controls.Add(this.rbDataSize);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(605, 48);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btRefresh
            // 
            this.btRefresh.Image = global::DBSizer.WinForms.UI.Properties.Resources.refresh;
            this.btRefresh.Location = new System.Drawing.Point(12, 16);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(75, 23);
            this.btRefresh.TabIndex = 6;
            this.btRefresh.Text = "Refresh";
            this.btRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btRefresh.UseVisualStyleBackColor = true;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(556, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "values";
            // 
            // nudTopItemsCount
            // 
            this.nudTopItemsCount.Location = new System.Drawing.Point(514, 19);
            this.nudTopItemsCount.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudTopItemsCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTopItemsCount.Name = "nudTopItemsCount";
            this.nudTopItemsCount.Size = new System.Drawing.Size(36, 20);
            this.nudTopItemsCount.TabIndex = 4;
            this.nudTopItemsCount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudTopItemsCount.ValueChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(437, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Show biggest";
            // 
            // rbRowCount
            // 
            this.rbRowCount.AutoSize = true;
            this.rbRowCount.Location = new System.Drawing.Point(335, 19);
            this.rbRowCount.Name = "rbRowCount";
            this.rbRowCount.Size = new System.Drawing.Size(77, 17);
            this.rbRowCount.TabIndex = 2;
            this.rbRowCount.Text = "Row count";
            this.rbRowCount.UseVisualStyleBackColor = true;
            this.rbRowCount.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // rbIndexSize
            // 
            this.rbIndexSize.AutoSize = true;
            this.rbIndexSize.Location = new System.Drawing.Point(223, 19);
            this.rbIndexSize.Name = "rbIndexSize";
            this.rbIndexSize.Size = new System.Drawing.Size(97, 17);
            this.rbIndexSize.TabIndex = 1;
            this.rbIndexSize.Text = "Index size (MB)";
            this.rbIndexSize.UseVisualStyleBackColor = true;
            this.rbIndexSize.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // rbDataSize
            // 
            this.rbDataSize.AutoSize = true;
            this.rbDataSize.Checked = true;
            this.rbDataSize.Location = new System.Drawing.Point(108, 19);
            this.rbDataSize.Name = "rbDataSize";
            this.rbDataSize.Size = new System.Drawing.Size(94, 17);
            this.rbDataSize.TabIndex = 0;
            this.rbDataSize.TabStop = true;
            this.rbDataSize.Text = "Data size (MB)";
            this.rbDataSize.UseVisualStyleBackColor = true;
            this.rbDataSize.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.progressBar);
            this.panel1.Controls.Add(this.btClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 557);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(605, 37);
            this.panel1.TabIndex = 1;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(3, 6);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(518, 23);
            this.progressBar.TabIndex = 1;
            this.progressBar.Visible = false;
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btClose.Location = new System.Drawing.Point(527, 3);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 0;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            // 
            // chart
            // 
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelAutoFitStyle = System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.None;
            chartArea1.AxisX.LabelStyle.Angle = -90;
            chartArea1.AxisX.LabelStyle.Interval = 1D;
            chartArea1.AxisX.MajorTickMark.Interval = 1D;
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.DataSource = this.bsData;
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart.Location = new System.Drawing.Point(0, 48);
            this.chart.Name = "chart";
            this.chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series1.CustomProperties = "MinPixelPointWidth=10";
            series1.IsValueShownAsLabel = true;
            series1.LabelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            series1.LabelFormat = "### ### ### ###.##";
            series1.Name = "Series1";
            series1.SmartLabelStyle.CalloutLineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            series1.XValueMember = "TableName";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series1.YValueMembers = "Value";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(605, 509);
            this.chart.TabIndex = 2;
            // 
            // bsData
            // 
            this.bsData.DataSource = typeof(TableInfoViewItem);
            // 
            // TablesChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 594);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(621, 441);
            this.Name = "TablesChartForm";
            this.Text = "Database [0] details";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTopItemsCount)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btRefresh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudTopItemsCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbRowCount;
        private System.Windows.Forms.RadioButton rbIndexSize;
        private System.Windows.Forms.RadioButton rbDataSize;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.BindingSource bsData;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}