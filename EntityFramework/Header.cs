using System;
using OpenQA.Selenium;

namespace KitchenAid
{
    public class Header
    {

        public enum menu_plp
        {
            account,parrilas_de_gas
        }


        public static void GoTo(Enum menuLink)
        {
            switch (menuLink)
            {
                case menu_plp.account:
                    Driver.Instance.FindElement(By.CssSelector("span.header-account-link-text")).Click();
                    break;
                case menu_plp.parrilas_de_gas:
                    Driver.Instance.FindElement(By.XPath("//a[contains(text(),'Parrillas de gas')]")).Click();
                    break;
            }
            
        }

        public static void SearchItem(string item)
        {
            IWebElement input_search_form = Driver.Instance.FindElement(By.Id("header-search-form")).FindElement((By.ClassName("header-search-input")));
            input_search_form.SendKeys(item);

            input_search_form.SendKeys(Keys.Enter);
        }
    }
}
