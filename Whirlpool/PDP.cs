using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SharedClasses;


namespace Whirlpool
{
    public class PDP
    {
        /*public static bool HasPrice()
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
                DataBase.InsertNotFoundItem(SKU,"WHR");
                return false;
            }
        }
        */


        public static void getDocuments(string item)
        {
            try
            {
                IWebElement listOfDocuments = Driver.Instance.FindElement(By.Id("documents"));
                IWebElement doc = listOfDocuments.FindElement(By.TagName("A"));
                var a_text = doc.Text;
                var a_href = doc.GetAttribute("href");
                DataBase.AddManual(item,a_text,a_href,"1");

                ProductDetailPage pdp = new ProductDetailPage();
                pdp.Date = DataBase.GetDateFormatDB();
                pdp.ProductoId = item;
                pdp.URL = Driver.Instance.Url;

                var PDPId = DataBase.AddPDP(pdp);

                ProductDetail2 pd = new ProductDetail2();
                pd.DetailTypeId = DataBase.GetDetailTypeId("Manual");
                pd.Date = DataBase.GetDateFormatDB();
                pd.Value = a_href;
                pd.ProductDetailPageId = PDPId;

                DataBase.AddProductDetail(pd);

            }
            catch (NoSuchElementException e)
            {
                DataBase.AddManual(item,"no doc","no doc","0");
            }
                
            
        }

        public static void getInfoFromPDP(string item)
        {
            ProductDetailPage pdp = new ProductDetailPage();
            pdp.Date = DataBase.GetDateFormatDB();
            pdp.ProductoId = item;
            pdp.URL = Driver.Instance.Url;

            var PDPId = DataBase.AddPDP(pdp);
            var Date = DataBase.GetDateFormatDB();


            ProductDetail2 pd = new ProductDetail2();

            pd.DetailTypeId = DataBase.GetDetailTypeId("Title");
            pd.Date = Date;
            pd.ProductDetailPageId = PDPId;
            pd.Value = Driver.Instance.FindElement(By.ClassName("the-product-title")).Text;

            DataBase.AddProductDetail(pd);
            


            try
            {
                IWebElement mainFeatureElement = Driver.Instance.FindElement(By.Id("features"));
                IList<IWebElement> mainFeatures = mainFeatureElement.FindElements(By.ClassName("show-more-container"));
                if (mainFeatures.Count == 0)
                {
                   
                }
                else
                {
                    var iy = 0;
                    foreach(IWebElement mainFeature in mainFeatures)
                    {
                        IWebElement mainFeatureTitle = mainFeature.FindElement(By.TagName("h4"));
                        IWebElement mainFeatureDescription = mainFeature.FindElement(By.ClassName("additional-content"));

                        pd.DetailTypeId = DataBase.GetDetailTypeId("MainFeatureDescription");
                        pd.Value = mainFeatureDescription.Text;

                        DataBase.AddProductDetail(pd);

                        pd.DetailTypeId = DataBase.GetDetailTypeId("MainFeatureTitle");
                        pd.Value = mainFeatureTitle.Text;

                        DataBase.AddProductDetail(pd);

                        iy++;
                    }
                }

                
            }
            catch (NoSuchElementException e)
            {
                
            }



            try
            {

                IWebElement additionalFeatureElement = Driver.Instance.FindElement(By.Id("additionalFeature"));
                IList<IWebElement> additionalFeatures = additionalFeatureElement.FindElements(By.ClassName("additional-feature"));


                if (additionalFeatures.Count == 0)
                {
                    
                    
                }
                else
                {
                    var iy = 0;
                    foreach (IWebElement additionalFeature in additionalFeatures)
                    {
                        IWebElement additionalFeatureTitle = additionalFeature.FindElement(By.TagName("h5"));
                        IWebElement additionalFeatureDescription = additionalFeature.FindElement(By.TagName("p"));

                        pd.DetailTypeId = DataBase.GetDetailTypeId("AdditionalFeatureDescription");
                        pd.Value = additionalFeatureDescription.Text;

                        DataBase.AddProductDetail(pd);

                        pd.DetailTypeId = DataBase.GetDetailTypeId("AdditionalFeatureTitle");
                        pd.Value = additionalFeatureTitle.Text;

                        DataBase.AddProductDetail(pd);

                        iy++;
                    }
                }

                

            }
            catch (NoSuchElementException e)
            {
                
            }

            try
            {
                IList<IWebElement> thumbs = Driver.Instance.FindElements(By.ClassName("s7thumbcell"));
                foreach (IWebElement imageElement in thumbs)
                {
                    

                    
                    string a = imageElement.Text;
                    a = a + "";





                }
            }
            catch (NoSuchElementException e)
            {

            }



        }

        public static bool IsAt
        {
            get{
                try
                {
                    IWebElement neWebElement =
                        Driver.Instance.FindElement(By.XPath("//*[@id='main']/div/div[1]/div/h3"));

                    string url = Driver.Instance.Url;

                    Driver.Instance.Navigate()
                        .GoToUrl("https://www.whirlpool.mx/resultados-de-busqueda.html?term=AAAAA");
                    Thread.Sleep(TimeSpan.FromSeconds(5));
                    return false; //*[@id="main"]/div/div[1]/div/h3
                }
                catch (NoSuchElementException e)
                {
                    return true;
                }
            }


        }

        public static bool HasFeatures()
        {
            throw new NotImplementedException();
        }
    }
}
