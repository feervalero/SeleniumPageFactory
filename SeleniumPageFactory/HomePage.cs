using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace KitchenAid
{
    public class HomePage
    {
        public static bool IsLoged
        { 
            get
            {
                Thread.Sleep(TimeSpan.FromSeconds(3));

                IWebElement usernameElement = Driver.Instance.FindElement(By.ClassName("header-user-name"));
                if (usernameElement.Text.Contains("Hola"))
                {
                    return true;
                }
                else return false;
            }
        }
    }
}
