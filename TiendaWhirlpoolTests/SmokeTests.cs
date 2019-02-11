using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCases;
using TiendaWhirlpool;

namespace TiendaWhirlpoolTests
{
    [TestClass]
    public class SmokeTests : BaseTestClass
    {
        [TestMethod]
        public void Am_I_Able_To_Login()
        {
            Login.useUser("aguils4").WithPassword("Calidad1").LoginIntent();
            Assert.IsTrue(Home.IsAt());
        }

        [TestMethod]
        public void Am_I_Unable_To_Login_With_Missing_Data()
        {
            Login.useUser("aguils4").WithPassword("Calidad2").LoginIntent();
            Assert.IsTrue(Login.IsErrorShowed());
        }

    }
}
