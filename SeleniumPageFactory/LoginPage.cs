using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;

namespace SeleniumPageFactory
{
    public class LoginPage
    {
        public static void GoTo()
        {
            
            Header.GoTo(Header.menu_plp.account);
        }

        public static LoginCommand LoginAs(string role)
        {
            return new LoginCommand(role);
        }
    }

    public class LoginCommand
    {
        private string username;
        private string password;

        public LoginCommand(string username)
        {
            this.username = username;
        }

        public LoginCommand WithPassword(string password)
        {
            this.password = password;
            return this;
        }

        public void Login()
        {
            IWebElement loginForm = Driver.Instance.FindElement(By.ClassName("login-registration-form"));
            IWebElement userField = loginForm.FindElement(By.Name("headerSignin_Email"));
            IWebElement passField = loginForm.FindElement(By.Name("headerSignin_Password"));
            IWebElement submitButton = loginForm.FindElement(By.CssSelector("button.form-button"));
            
            userField.SendKeys(this.username);
            passField.SendKeys(this.password);
            submitButton.Click();


        }
    }
}
