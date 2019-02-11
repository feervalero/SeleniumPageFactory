using System;
using System.Collections.Generic;
using System.Text;
using KitchenAid;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCases
{
    [TestClass]
    public class SmokeTesting : BaseTestClass
    {
        [TestMethod]
        public void Can_I_Login()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs("fer.dev.valero@gmail.com").WithPassword("C@lidad1").Login();

            //Assert.IsTrue(HomePage.IsAt,"No se llego a home con las credenciales");

        }
    }
}
