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

            WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("ajax-container-search")));

            IWebElement count_indicador = Driver.Instance.FindElement(By.ClassName("count-value"));
            IWebElement tab_indicator = Driver.Instance.FindElement(By.Id("total-search-results"));


            Driver.Instance.FindElement(By.CssSelector("#search-tab > ul > li:nth-child(1) > a")).Click();

            var tab = 0;
            var count = 0;
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
                count= Convert.ToInt32(count_indicador.Text);
            }
            catch (System.FormatException)
            {
                count = 0;
            }




            if (tab > 0 && count > 0)
            {
                return true;
            }
            else return false;
        }

        public static void GoToPDP()
        {
            
            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> itemsFounded =
                Driver.Instance.FindElements(By.ClassName("product-view-details"));
            itemsFounded[0].Click();
        }
    }
}
