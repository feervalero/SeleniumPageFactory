using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TiendaWhirlpool;
namespace TestCases_TiendaWhirlpool
{
    [TestClass]
    public class BaseTest
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
