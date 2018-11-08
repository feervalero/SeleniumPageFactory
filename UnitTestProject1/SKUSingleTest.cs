using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumPageFactory;
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
                "KOWT100ESS",
                "KVIB606DSS",
                "KDTM354ESS",
                "KCGS956ESS",
                "KICU569XBL",
                "KRMF606ESS",
                "KXW9736YSS",
                "KDTM704ESS",
                "KVWB606DSS"/*,
                "KRSF505ESS",
                "KOSE500ESS",
                "KOCE500ESS",
                "KGCU467VSS",
                "KSGB900ESS",
                "KUDR204ESB",
                "KRFF707ESS",
                "KBSD608ESS",
                "KMCS3022GSS",
                "KMCS1016GSS",
                "KMHC319ESS",
                "KXD4636YSS",
                "KUIX305ESS",
                "KCDS075T",
                "KUIX505ESS",
                "KUBR304ESS",
                "KUWR304ESS"*/
            };

            foreach (string item in items)
            {
                Header.SearchItem(item);
                if (SearchPage.hasResults())
                {
                    SearchPage.GoToPDP();
                    Assert.IsTrue(PDP.HasPrice(), "Price not found");
                    Assert.IsTrue(PDP.HasFeatures(), "Features not found");
                }
                else
                {
                    DataBase.InsertNotFoundItem(item);
                }
            }
            
        }

        
    }
}