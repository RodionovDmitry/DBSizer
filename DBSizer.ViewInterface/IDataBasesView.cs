using System;
using System.Collections.Generic;
using DBSizer.Data;

namespace DBSizer.ViewInterface
{
    public interface IDataBasesView
    {
        IDBInfo SelectedDatabase { get; }
        ISqlConnectionSettingsView SettingsView { get; }
        void SetDbListDataSource(List<IDBInfo> dbDescriptions, List<IDBInfo> checkedItems);
        void SetChartDataSource(List<IDBInfo> dbDescriptions);
        IEnumerable<IDBInfo> CheckedDatabases();
        event EventHandler ConnectClicked;
        event EventHandler DataBaseCheckedChanged;
        event EventHandler Shown;
        event EventHandler AnalyseClicked;
        void ShowError(string errorText);

        IDatabaseDetailsView CreateDatabaseDetailsView();
    }
}