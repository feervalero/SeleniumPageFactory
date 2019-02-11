using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TiendaWhirlpool
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; }

        public static void Initialize()
        {
            Instance = new ChromeDriver(@"C:\Users\valerf2\Downloads\chromedriver");
            Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            
        }

        public static void Close()
        {
            Instance.Close();
        }
    }
}