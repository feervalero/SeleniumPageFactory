using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharedClasses;


namespace Maytag
{
    [TestClass]
    public class SKUSingleTest : MaytagBaseTestClass
    {
        [TestMethod]
        public void SearchAndValidate()
        {
            //string[] items = {
            //    "WRX735SDHV"
            //};

            IList<string> items = DataBase.GetProducts("MAY");

            foreach (string item in items)
            {
                
               Maytag.Header.SearchItem(item);
               /*if (Maytag.SearchPage.hasResults())
                {
                    //Maytag.SearchPage.GoToPDP();
                    //Assert.IsTrue(Maytag.PDP.HasPrice(), "Price not found");
                    //Assert.IsTrue(Whirlpool.PDP.HasFeatures(), "Features not found");
                }
                else
                {
                   // SharedClasses.DataBase.InsertNotFoundItem(item,"WHR");
                }
                /*Driver.Instance.Navigate().GoToUrl("https://whirlpool.mx");
                */
     
            }
            
        }

        
    }
}