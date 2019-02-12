using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCases;

namespace KitchenAidTests
{
    [TestClass]
    public class SKUSingleTest : BaseTestClass
    {
        [TestMethod]
        public void SearchAndValidate()
        {
            string[] items = {
                "5KSBSPJ"
            };

            //IList<string> items = KitchenAid.DataBase.GetProducts();

            foreach (string item in items)
            {
                KitchenAid.Header.SearchItem(item);
                if (KitchenAid.SearchPage.hasResults())
                {
                    KitchenAid.SearchPage.GoToPDP();
                    Assert.IsTrue(KitchenAid.PDP.HasPrice(), "Price not found");
                    Assert.IsTrue(KitchenAid.PDP.HasFeatures(), "Features not found");
                }
                else
                {
                    SharedClasses.DataBase.InsertNotFoundItem(item);
                }
            }
            
        }

        
    }
}