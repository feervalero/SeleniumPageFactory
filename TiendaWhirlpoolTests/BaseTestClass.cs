using TiendaWhirlpool;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCases
{
    public class BaseTestClass
    {
        [TestInitialize]
        public void init()
        {
            Driver.Initialize();
            Driver.Instance.Navigate().GoToUrl("http://qa.tiendawhirlpool.com/pos3/login");
            DataBase.CleanProductTable();
        }

        [TestCleanup]
        public void Close() => Driver.Close();
    }
}