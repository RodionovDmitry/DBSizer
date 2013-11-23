using System;
using System.ComponentModel;
using System.Windows.Forms;
using DBSizer.Data;
using DBSizer.ViewInterface;

namespace DBSizer.WinForms.UI
{
    public partial class SqlConnectionSettingsControl : UserControl, ISqlConnectionSettingsView
    {
        public SqlConnectionSettingsControl()
        {
            InitializeComponent();
        }

        public string ServerName
        {
            get { return tbServerName.Text; }
        }

        [Browsable(false)]
        public SqlAuthMode AuthMode
        {
            get { return (SqlAuthMode) cmbAuthType.SelectedIndex; }
            set { cmbAuthType.SelectedIndex = (int) value; }
        }

        public string UserName
        {
            get { return tbUserName.Text; }
            set { tbUserName.Text = value; }
        }

        public string Password
        {
            get { return tbPassword.Text; }
        }

        public event EventHandler AuthModeChanged;

        public void DisableUserNameAndPassword()
        {
            tbPassword.Enabled = false;
            lbPassword.Enabled = false;
            tbUserName.Enabled = false;
            lbUserName.Enabled = false;
        }

        public void EnableUserNameAndPassword()
        {
            tbPassword.Enabled = true;
            lbPassword.Enabled = true;
            tbUserName.Enabled = true;
            lbUserName.Enabled = true;
        }

        private void SqlConnectionSettings_Load(object sender, EventArgs e)
        {
            cmbAuthType.SelectedIndex = 0;
        }

        private void cmbAuthType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AuthModeChanged != null)
            {
                AuthModeChanged(this, EventArgs.Empty);
            }
        }
    }
}