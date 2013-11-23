using System;
using DBSizer.Data;
using DBSizer.WPF.UI.ViewInterfaces;
using DBSizer.WPF.UI.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace DBSizer.WPF.Tests
{
    [TestClass]
    public class DBInfoListItemTest
    {
        [TestMethod]
        public void When_checked_changes_chart_refreshes()
        {
            var dbInfo = MockRepository.GenerateStub<IDBInfo>();
            var chart = MockRepository.GenerateStub<IRefreshChartBinding>();
            var item = new DBInfoListItem(dbInfo, chart);

            item.IsChecked = true;

            chart.AssertWasCalled(x => x.RefreshChartBinding());
        }
    }
}
