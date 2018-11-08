using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;

namespace SeleniumPageFactory
{
    public class ProductListPage
    {
        public static bool IsAt
        {
            get
            {
                Thread.Sleep(TimeSpan.FromSeconds(3));
                var title = Driver.Instance.FindElement(By.CssSelector(".main > h1:nth-child(2)"));
                if (title.Text.Contains("PARRILLA")) { return true; }
                else return false;

            }
        }
    }
}
