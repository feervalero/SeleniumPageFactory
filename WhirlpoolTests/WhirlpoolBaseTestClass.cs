using Whirlpool;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharedClasses;

namespace TestCases
{
    public class WhirlpoolBaseTestClass
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