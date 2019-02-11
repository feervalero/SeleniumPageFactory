using KitchenAid;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCases;

namespace KitchenAidTests
{
    [TestClass]
    public class ProductListTests : BaseTestClass
    {

        [TestMethod]
        public void Can_Go_To()
        {
            Header.GoTo(Header.menu_plp.parrilas_de_gas);
            Assert.IsTrue(ProductListPage.IsAt,"Failed to reach PLP");
            
        }
    }
}
