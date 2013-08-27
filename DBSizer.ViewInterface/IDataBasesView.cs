using System;
using System.Collections.Generic;
using DBSizer.Data;

namespace DBSizer.ViewInterface
{
    public interface IDataBasesView
    {
        DBInfo SelectedDatabase { get; }
        ISqlConnectionSettingsView SettingsView { get; }
        void SetDbListDataSource(List<DBInfo> dbDescriptions);
        void SetChartDataSource(List<DBInfo> dbDescriptions);
        IEnumerable<DBInfo> CheckedDatabases();
        event EventHandler ConnectClicked;
        event EventHandler DataBaseCheckedChanged;
        event EventHandler Shown;
        event EventHandler AnalyseClicked;
        void ShowError(string errorText);

        IDatabaseDetailsView CreateDatabaseDetailsView();
    }
}