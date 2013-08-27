using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DBSizer.Data;
using DBSizer.ViewInterface;

namespace DBSizer.WinForms.UI
{
    public partial class DatabaseDetailsForm : Form, IDatabaseDetailsView
    {
        public DatabaseDetailsForm()
        {
            InitializeComponent();
        }

        public int NumTopValues
        {
            get { return Convert.ToInt32(nudTopItemsCount.Value); }
        }

        public DataToDisplay SelectedDataToDisplay
        {
            get 
            { 
                if (rbDataSize.Checked)
                {
                    return DataToDisplay.DataSize;
                }
                else if (rbIndexSize.Checked)
                {
                    return DataToDisplay.IndexSize;
                }
                else if (rbRowCount.Checked)
                {
                    return DataToDisplay.RowCount;
                }
                else
                {
                    throw new InvalidOperationException("No DataToDisplay selected");
                }
            }
        }

        public event EventHandler SelectedDataToDisplayChanged;
        public event EventHandler RefreshClicked;
        public void SetChartDataSource(List<TableInfoViewItem> values)
        {
            bsData.DataSource = values;
            chart.DataBind();
        }

        public void ShowProgressBar()
        {
            progressBar.Visible = true;
            progressBar.Value = 0;
            this.Invalidate();
            Application.DoEvents();
        }

        public void HideProgressBar()
        {
            progressBar.Visible = false;
        }

        public void SetCaption(string viewCaption)
        {
            this.Text = viewCaption;
        }

        public void ShowModal()
        {
            this.ShowDialog();
        }

        public void SetMaximumProgress(int max)
        {
            progressBar.Value = 0;
            progressBar.Maximum = max;
            this.Invalidate();
            Application.DoEvents();
        }

        public void IncProgress()
        {
            if (progressBar.Value < progressBar.Maximum)
            {
                progressBar.Value++;
                this.Invalidate();
                Application.DoEvents();
            }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectedDataToDisplayChanged != null)
                SelectedDataToDisplayChanged(this, EventArgs.Empty);
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            if (RefreshClicked != null)
                RefreshClicked(this, EventArgs.Empty);
        }
    }


}
