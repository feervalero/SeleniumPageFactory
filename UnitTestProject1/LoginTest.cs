using Microsoft.VisualStudio.TestTools.UnitTesting;
using KitchenAid;
using TestCases;

namespace KitchenAidTests
{
    [TestClass]
    public class LoginTest : BaseTestClass
    {
       

        [TestMethod]
        public void General_User_Can_Login()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs("fer.dev.valero@gmail.com").WithPassword("C@lidad1").Login();

           Assert.IsTrue(AccountPage.IsAt,"Failed to login");
        }

       
    }
}
