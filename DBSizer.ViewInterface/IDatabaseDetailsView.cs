using System;
using System.Collections.Generic;
using DBSizer.Data;

namespace DBSizer.ViewInterface
{
    public interface IDatabaseDetailsView : IDisposable
    {
        int NumTopValues { get; }
        Characteristic SelectedCharacteristic { get; }
        event EventHandler SelectedCharacteristicChanged;
        event EventHandler RefreshClicked;
        event EventHandler Shown;
        void SetChartDataSource(List<TableInfoViewItem> values);

        void ShowProgressBar();
        void HideProgressBar();
        void SetProgress(int progressValue);

        void SetCaption(string viewCaption);
        void ShowModal();
    }
}