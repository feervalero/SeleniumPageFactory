using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TiendaWhirlpool
{
    public class Login
    {
        public static void GoTo()
        {
            
            Header.GoTo(Header.menu_plp.account);
        }

        public static LoginCommand useUser(string userName)
        {
            return new LoginCommand(userName);
        }

        public static bool IsErrorShowed()
        {
            Boolean is_error = false;
            ReadOnlyCollection<IWebElement> errorCollection =  Driver.Instance.FindElements(By.ClassName("help-block"));
            foreach (IWebElement errorElement in errorCollection)
            {
                if (errorElement.Text.Contains("incorrectos")) is_error = true;
                else is_error = false;
            }

            return is_error;
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

        public void LoginIntent()
        {

            IWebElement select = Driver.Instance.FindElement(By.Id("tienda"));
            var selectElement = new SelectElement(select);
            selectElement.SelectByValue("1"); // PMIER
            Driver.Instance.FindElement(By.Id("login")).SendKeys(this.username);
            Driver.Instance.FindElement(By.Id("password")).SendKeys(this.password);
            Driver.Instance.FindElement(By.Id("btn_login")).Click();

        }
    }
}
