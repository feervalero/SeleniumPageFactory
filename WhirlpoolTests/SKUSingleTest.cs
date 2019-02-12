using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCases;

namespace WhirlpoolTest
{
    [TestClass]
    public class SKUSingleTest : WhirlpoolBaseTestClass
    {
        [TestMethod]
        public void SearchAndValidate()
        {
            string[] items = {
                "7MWFW90HEFC"
            };

            //IList<string> items = KitchenAid.DataBase.GetProducts();

            foreach (string item in items)
            {
                Whirlpool.Header.SearchItem(item);
                if (Whirlpool.SearchPage.hasResults())
                {
                    Whirlpool.SearchPage.GoToPDP();
                    Assert.IsTrue(Whirlpool.PDP.HasPrice(), "Price not found");
                    Assert.IsTrue(Whirlpool.PDP.HasFeatures(), "Features not found");
                }
                else
                {
                    SharedClasses.DataBase.InsertNotFoundItem(item);
                }
            }
            
        }

        
    }
}