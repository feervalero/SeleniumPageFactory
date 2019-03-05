using Whirlpool;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharedClasses;

namespace Whirlpool
{
    public class WhirlpoolBaseTestClass
    {
        [TestInitialize]
        public void init()
        {
            Driver.Initialize();
            Driver.Instance.Navigate().GoToUrl("https://www.whirlpool.mx/resultados-de-busqueda.html?term=AAAAA");
            DataBase.CleanProductTable("WHR");
        }

        [TestCleanup]
        public void Close() => Driver.Close();
    }
}