using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SharedClasses;

namespace Whirlpool
{
    public class Header
    {
        public static void SearchItem(string item)
        {
            IWebElement input_search_form = Driver.Instance.FindElement(By.Id("search"));
            input_search_form.Clear();
            input_search_form.SendKeys(item);
            input_search_form.SendKeys(Keys.Enter);
        }
    }
}
