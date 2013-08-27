using System;
using System.Collections.Generic;
using DBSizer.Data;

namespace DBSizer.ViewInterface
{
    public interface IDatabaseDetailsView : IProgressable, IDisposable
    {
        int NumTopValues { get; }
        DataToDisplay SelectedDataToDisplay { get; }
        event EventHandler SelectedDataToDisplayChanged;
        event EventHandler RefreshClicked;
        event EventHandler Shown;
        void SetChartDataSource(List<TableInfoViewItem> values);
        void ShowProgressBar();
        void HideProgressBar();

        void SetCaption(string viewCaption);
        void ShowModal();
    }
}