using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TiendaWhirlpool
{
    public class AccountPage
    {
        public static bool IsAt{
            get
            {
                WebDriverWait wait = new WebDriverWait(Driver.Instance,TimeSpan.FromSeconds(3));
                wait.Until(d => d.SwitchTo().ActiveElement().FindElement(By.ClassName("header-user-name")));
                
                var headerAccountMenu = Driver.Instance.FindElement(By.ClassName("header-account-menu"));
                var usernameSpan = headerAccountMenu.FindElements(By.ClassName("header-user-name"));
                
                var title = usernameSpan;
                if (title[0].Text.Contains("Hola"))
                {
                    return true;
                }
                else return false;
            }
        }

    }
}
