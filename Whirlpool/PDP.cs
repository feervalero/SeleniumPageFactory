using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SharedClasses;


namespace Whirlpool
{
    public class PDP
    {
        public static bool HasPrice()
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
            try
            {
               
                
                
                ProductDetail product = new ProductDetail();

                product.SKU = Driver.Instance.FindElement(By.ClassName("model-number")).Text;
                product.Description = Driver.Instance.FindElement(By.ClassName("the-product-title")).Text;
                product.BrandCode = "WHR";
                product.Feature = "";
                product.FeatureDescription = "";
                product.FeatureType = "";
                product.Price = "";


                DataBase.ExecuteProcedure(product);
                return true;
            }
            catch (NoSuchElementException e)
            {
                var SKU = Driver.Instance.FindElement(By.ClassName("model-number")).Text;
                DataBase.InsertNotFoundItem(SKU);
                return false;
            }
        }

        public static bool HasFeatures()
        {
            throw new NotImplementedException();
        }
    }
}
