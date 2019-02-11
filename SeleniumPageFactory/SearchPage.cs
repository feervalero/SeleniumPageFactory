using System;
using System.Collections.ObjectModel;
using System.Threading;
using OpenQA.Selenium;

namespace KitchenAid
{
    public static class SearchPage
    {
        public static bool hasResults()
        {
            Thread.Sleep(TimeSpan.FromSeconds(3));

            IWebElement tab_indicator = Driver.Instance.FindElement(By.ClassName("slp-tab-count-value"));
            IWebElement found_indicator = Driver.Instance.FindElement(By.ClassName("plp-counter-value"));

            var a = tab_indicator.Text;
            var b = found_indicator.Text;
            var c = 1;
            var tab = 0;
            var found = 0;
            try
            {
                tab = Convert.ToInt32(tab_indicator.Text);
            }
            catch (System.FormatException)
            {
                tab = 0;
            }
            try
            {
                found = Convert.ToInt32(found_indicator.Text);
            }
            catch (System.FormatException)
            {
                found = 0;
            }
            

            if (tab > 0 && found > 0)
            {
                return true;
            }
            else return false;

        }

        public static void GoToPDP()
        {
            ReadOnlyCollection<IWebElement> plp_items = Driver.Instance.FindElements(By.ClassName("plp-item-detail-link"));
            plp_items[0].Click();
        }
    }
}
