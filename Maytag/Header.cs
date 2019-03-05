using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;
using SharedClasses;
using SeleniumExtras;
using OpenQA.Selenium.Support.UI;

namespace Maytag
{
    public class Header
    {



        public static void SearchItem(string item)
        {
            Driver.Instance.Navigate().GoToUrl("https://www.maytag.mx/resultados-de-busqueda.html?term="+item);

            WebDriverWait wait = new WebDriverWait(Driver.Instance,TimeSpan.FromSeconds(10));
            
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
            //    .InvisibilityOfElementLocated(By.Id("ajax-container")));
            wait.Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions
                    .InvisibilityOfElementLocated(By.Id("ajax-overlay-search")));

        }
    }
}
