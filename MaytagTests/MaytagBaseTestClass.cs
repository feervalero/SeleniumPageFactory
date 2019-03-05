using Maytag;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharedClasses;

namespace Maytag
{
    public class MaytagBaseTestClass
    {
        [TestInitialize]
        public void init()
        {
            Driver.Initialize();
            Driver.Instance.Navigate().GoToUrl("https://maytag.mx");
            DataBase.CleanProductTable("WHR");
        }

        [TestCleanup]
        public void Close() => Driver.Close();
    }
}