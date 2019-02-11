using KitchenAid;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCases
{
    public class BaseTestClass
    {
        [TestInitialize]
        public void init()
        {
            Driver.Initialize();
            Driver.Instance.Navigate().GoToUrl("https://kitchenaid.mx");
            DataBase.CleanProductTable();
        }

        [TestCleanup]
        public void Close() => Driver.Close();
    }
}