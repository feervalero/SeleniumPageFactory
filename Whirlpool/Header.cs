using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
            Thread.Sleep(TimeSpan.FromSeconds(10));
           

        }

        public static bool GetMenus()
        {
            IList<string> urlsList = new List<string>();

            Thread.Sleep(TimeSpan.FromSeconds(10));
            IList<IWebElement> nav = Driver.Instance.FindElements(By.ClassName("nav-item "));
            IList<IWebElement> links = nav[0].FindElements(By.TagName("a"));
            
            foreach (IWebElement link in links)
            {
                if(link.GetAttribute("href") != null) urlsList.Add(link.GetAttribute("href"));
                
            }

            foreach (string url in urlsList)
            {
                Driver.Instance.Navigate().GoToUrl(url);
                if (Header.IsPLP())
                {
                    DataBase.InsertProductListPage(url);
                    var result = Header.SaveAllProducts(url);
                }
            }

            return true;
        }

        private static string SaveAllProducts(string url)
        {
            try
            {
                IList<IWebElement> Skus = Driver.Instance.FindElements(By.ClassName("compare-info-code"));
                foreach (IWebElement sku in Skus)
                {
                    DataBase.InsertProductListPageDetail(url,sku.Text);
                }

                
                return "Ok";
            }
            catch (NoSuchElementException e)
            {
                return "Esta vacio";
            }
        }

        private static bool IsPLP()
        {
            try
            {
                Driver.Instance.FindElement(By.Id("plp-results"));
                return true;
            }
            catch (NoSuchElementException e)
            {
                return false;
            }
        }
    }
}
