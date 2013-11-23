using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DBSizer.Data;
using DBSizer.ViewInterface;

namespace DBSizer.WinForms.UI
{
    public partial class DataBasesForm : Form, IDataBasesView
    {
        public DataBasesForm()
        {
            InitializeComponent();
        }

        public void SetDbListDataSource(List<IDBInfo> dbDescriptions, List<IDBInfo> checkedItems)
        {
            clbDatabases.Items.Clear();
            foreach (IDBInfo dbDescription in dbDescriptions)
            {
                clbDatabases.Items.Add(dbDescription, checkedItems.Contains(dbDescription));
            }
        }

        public void SetChartDataSource(List<IDBInfo> dbDescriptions)
        {
            chart.Visible = true;
            bsDBInfo.DataSource = dbDescriptions;
            chart.DataBind();
        }

        public IEnumerable<IDBInfo> CheckedDatabases()
        {
            return clbDatabases.CheckedItems.Cast<IDBInfo>();
        }

        public IDBInfo SelectedDatabase
        {
            get { return clbDatabases.Items[clbDatabases.SelectedIndex] as IDBInfo; }
        }

        public event EventHandler ConnectClicked;
        public event EventHandler DataBaseCheckedChanged;
        public event EventHandler AnalyseClicked;

        public ISqlConnectionSettingsView SettingsView
        {
            get { return sqlConnectionSettingsView; }
        }

        public void ShowError(string errorText)
        {
            MessageBox.Show(errorText, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public IDatabaseDetailsView CreateDatabaseDetailsView()
        {
            return new DatabaseDetailsForm();
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            if (ConnectClicked != null)
            {
                ConnectClicked(sender, e);
            }
        }

        private void clbDatabases_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            clbDatabases.ItemCheck -= clbDatabases_ItemCheck;
            clbDatabases.SetItemChecked(e.Index, e.NewValue == CheckState.Checked);
            clbDatabases.ItemCheck += clbDatabases_ItemCheck;
            if (DataBaseCheckedChanged != null)
            {
                DataBaseCheckedChanged(sender, e);
            }
        }

        private void btAnalyse_Click(object sender, EventArgs e)
        {
            if (AnalyseClicked != null)
            {
                AnalyseClicked(this, EventArgs.Empty);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AboutForm();
            form.ShowDialog();
        }
    }
}