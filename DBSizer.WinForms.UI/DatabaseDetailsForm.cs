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

        public Characteristic SelectedCharacteristic
        {
            get 
            { 
                if (rbDataSize.Checked)
                {
                    return Characteristic.DataSize;
                }
                else if (rbIndexSize.Checked)
                {
                    return Characteristic.IndexSize;
                }
                else if (rbRowCount.Checked)
                {
                    return Characteristic.RowCount;
                }
                else
                {
                    throw new InvalidOperationException("No Characteristic selected");
                }
            }
        }

        public event EventHandler SelectedCharacteristicChanged;
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

        public void SetProgress(int progressValue)
        {
            if (progressValue < progressBar.Maximum)
            {
                progressBar.Value = progressValue;
            }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectedCharacteristicChanged != null)
                SelectedCharacteristicChanged(this, EventArgs.Empty);
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            if (RefreshClicked != null)
                RefreshClicked(this, EventArgs.Empty);
        }
    }
}
