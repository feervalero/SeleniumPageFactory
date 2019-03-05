using OpenQA.Selenium;
using SharedClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace Whirlpool
{
    public class SearchPage
    {
        public static bool hasResults()
        {

            WebDriverWait wait = new WebDriverWait(Driver.Instance,TimeSpan.FromSeconds(10));

            wait.Until(driver => driver.FindElement(By.XPath("//*[@id='search-tab']/ul/li[1]")));

            IWebElement tabResult = Driver.Instance.FindElement(By.XPath("//*[@id='search-tab']/ul/li[1]"));
            tabResult.Click();

            var tab_total = Driver.Instance.FindElement(By.Id("total-search-results")).Text;

            Int32 total = Int32.Parse(tab_total);

            if (total > 0)
            {
                
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void GoToPDP()
        {

            IList<IWebElement> items_Found =
                Driver.Instance.FindElements(By.ClassName("product-view-details"));

            //Check if is in PDP
            items_Found[0].Click();
        }
    }
}
