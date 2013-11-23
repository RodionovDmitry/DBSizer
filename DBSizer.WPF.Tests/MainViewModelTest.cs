using DBSizer.Data;
using DBSizer.WPF.UI.Helpers;
using DBSizer.WPF.UI.ViewInterfaces;
using DBSizer.WPF.UI.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace DBSizer.WPF.Tests
{
    [TestClass]
    public class MainViewModelTest
    {
        [TestMethod]
        public void MainViewModel_shows_init_text_on_startup()
        {
            var mocks = new MainViewModelMocks();
            var model = new MainViewModel(mocks.SqlQueryExecutorMock, mocks.MainViewMock,
                                          mocks.WindowsIdentityProviderMock, mocks.DBInfoBuilderMock);

            Assert.AreEqual(model.HelpText, model.INIT_TEXT);
        }

        [TestMethod]
        public void Only_checked_databases_shows_on_chart()
        {
            var mocks = new MainViewModelMocks();
            var model = new MainViewModel(mocks.SqlQueryExecutorMock, mocks.MainViewMock,
                                          mocks.WindowsIdentityProviderMock, mocks.DBInfoBuilderMock);

            var chart = MockRepository.GenerateStub<IRefreshChartBinding>();
            var dbInfo1 = MockRepository.GenerateStub<IDBInfo>();
            var dbInfoViewItem1 = new DBInfoListItem(dbInfo1, chart);
            dbInfoViewItem1.IsChecked = true;

            var dbInfo2 = MockRepository.GenerateStub<IDBInfo>();
            var dbInfoViewItem2 = new DBInfoListItem(dbInfo2, chart);
            dbInfoViewItem2.IsChecked = false;

            model.AllDataBases.Add(dbInfoViewItem1);
            model.AllDataBases.Add(dbInfoViewItem2);

            Assert.AreEqual(1, model.DataBasesForChart.Count);
            Assert.AreEqual(dbInfoViewItem1, model.DataBasesForChart[0]);
        }

        [TestMethod]
        public void Analyse_click_shows_message_when_no_database_selected()
        {
            var mocks = new MainViewModelMocks();
            var model = new MainViewModel(mocks.SqlQueryExecutorMock, mocks.MainViewMock,
                                          mocks.WindowsIdentityProviderMock, mocks.DBInfoBuilderMock);

            mocks.MainViewMock.Stub(x => x.SelectedItem).Return(null);
            model.Analyse.Execute(null);

            mocks.MainViewMock.Dialogs.AssertWasCalled(x => x.Info(string.Empty), options => options.IgnoreArguments());
            mocks.MainViewMock.AssertWasNotCalled(x => x.CreateDetailsWindow());
        }

        [TestMethod]
        public void Analyse_click_shows_details_view()
        {
            var mocks = new MainViewModelMocks();
            var model = new MainViewModel(mocks.SqlQueryExecutorMock, mocks.MainViewMock,
                                          mocks.WindowsIdentityProviderMock, mocks.DBInfoBuilderMock);

            var dbInfo1 = MockRepository.GenerateStub<IDBInfo>();
            dbInfo1.Stub(x => x.Name).Return("testName");
            var dbInfoViewItem1 = new DBInfoListItem(dbInfo1, null);
            mocks.MainViewMock.Stub(x => x.SelectedItem).Return(dbInfoViewItem1);

            model.Analyse.Execute(null);

            mocks.MainViewMock.AssertWasCalled(x => x.CreateDetailsWindow());
            mocks.DatabaseDetailsWindowMock.AssertWasCalled(x => x.ShowDialog());
            Assert.IsInstanceOfType(mocks.DatabaseDetailsWindowMock.DataContext, typeof(DatabaseDetailsViewModel));
        }

        [TestMethod]
        public void Connect_click_shows_error_when_connection_is_invalid()
        {
            var mocks = new MainViewModelMocks();
            var model = new MainViewModel(mocks.SqlQueryExecutorMock, mocks.MainViewMock,
                                          mocks.WindowsIdentityProviderMock, mocks.DBInfoBuilderMock);
            mocks.SqlQueryExecutorMock.Stub(x => x.ConnectionIsValid(string.Empty)).IgnoreArguments().Return(false);

            model.Connect.Execute(null);

            mocks.MainViewMock.Dialogs.AssertWasCalled(x => x.Error(string.Empty), options => options.IgnoreArguments());
        }



        private class MainViewModelMocks
        {
            internal MainViewModelMocks()
            {
                SqlQueryExecutorMock = MockRepository.GenerateStub<ISqlQueryExecutor>();
                DatabaseDetailsWindowMock = MockRepository.GenerateStub<IDatabaseDetailsWindow>();
                MainViewMock = MockRepository.GenerateStub<IMainView>();
                MainViewMock.Stub(x => x.Dialogs).Return(MockRepository.GenerateStub<ISimpleDialogs>());
                MainViewMock.Stub(x => x.CreateDetailsWindow()).Return(DatabaseDetailsWindowMock);
                WindowsIdentityProviderMock = MockRepository.GenerateStub<IWindowsIdentityProvider>();
                DBInfoBuilderMock = MockRepository.GenerateStub<IDBInfoBuilder>();
            }


            internal IDatabaseDetailsWindow DatabaseDetailsWindowMock { get; private set; }
            internal ISqlQueryExecutor SqlQueryExecutorMock { get; private set; }
            internal IMainView MainViewMock { get; private set; }
            internal IWindowsIdentityProvider WindowsIdentityProviderMock { get; private set; }
            internal IDBInfoBuilder DBInfoBuilderMock { get; private set; }
        }
    }
}