using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DBSizer.Data;
using DBSizer.ViewPresenter;
using DBSizer.WinForms.UI;

namespace DBSizer.Winforms.Starter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form = new DataBasesForm();
            var presenter = new DataBasesPresenter(form, new SqlQueryExecutor(), 
                new WindowsIdentityProvider(), new DBInfoBuilder());
            Application.Run(form);
        }
    }
}
