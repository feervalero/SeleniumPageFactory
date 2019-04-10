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
                DataBase.InsertNotFoundItem(SKU,"WHR");
                return false;
            }
        }

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
                pdp.Date = "010119";
                pdp.ProductoId = item;
                pdp.URL = Driver.Instance.Url;

                var PDPId = DataBase.AddPDP(pdp);

                ProductDetail2 pd = new ProductDetail2();
                pd.DetailTypeId = DataBase.GetDetailTypeId("Manual");
                pd.Date = "010219";
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
            ProductDetail product = new ProductDetail();

            product.SKU = item;
            product.Description = Driver.Instance.FindElement(By.ClassName("the-product-title")).Text;
            product.BrandCode = "WHR";
            product.Price = "";

            try
            {
                IWebElement mainFeatureElement = Driver.Instance.FindElement(By.Id("features"));
                IList<IWebElement> mainFeatures = mainFeatureElement.FindElements(By.ClassName("show-more-container"));
                if (mainFeatures.Count == 0)
                {
                    product.Feature = "no main feature";
                    product.FeatureDescription = "no main feature";
                    product.FeatureType = "main";
                    product.MaterialFeature = item + "-m-0";
                    DataBase.ExecuteProcedure(product);
                }
                else
                {
                    var iy = 0;
                    foreach(IWebElement mainFeature in mainFeatures)
                    {
                        IWebElement mainFeatureTitle = mainFeature.FindElement(By.TagName("h4"));
                        IWebElement mainFeatureDescription = mainFeature.FindElement(By.ClassName("additional-content"));
                        product.MaterialFeature = item + "-m-" + iy;
                        product.Feature = mainFeatureTitle.Text;
                        product.FeatureDescription = mainFeatureDescription.Text;
                        product.FeatureType = "main";
                        DataBase.ExecuteProcedure(product);
                        iy++;
                    }
                }

                
            }
            catch (NoSuchElementException e)
            {
                product.Feature = "no main feature";
                product.FeatureDescription = "no main feature";
                product.FeatureType = "main";
                product.MaterialFeature = item + "-m-0";
                DataBase.ExecuteProcedure(product);
            }



            try
            {

                IWebElement additionalFeatureElement = Driver.Instance.FindElement(By.Id("additionalFeature"));
                IList<IWebElement> additionalFeatures = additionalFeatureElement.FindElements(By.ClassName("additional-feature"));


                if (additionalFeatures.Count == 0)
                {
                    product.Feature = "no additional feature";
                    product.FeatureDescription = "no additional feature";
                    product.FeatureType = "other";
                    product.MaterialFeature = item + "-o-0";
                    DataBase.ExecuteProcedure(product); 
                    
                }
                else
                {
                    var iy = 0;
                    foreach (IWebElement additionalFeature in additionalFeatures)
                    {
                        IWebElement additionalFeatureTitle = additionalFeature.FindElement(By.TagName("h5"));
                        IWebElement additionalFeatureDescription = additionalFeature.FindElement(By.TagName("p"));
                        product.MaterialFeature = item + "-o-" + iy;
                        product.Feature = additionalFeatureTitle.Text;
                        product.FeatureDescription = additionalFeatureDescription.Text;
                        product.FeatureType = "other";
                        DataBase.ExecuteProcedure(product);
                        iy++;
                    }
                }

                

            }
            catch (NoSuchElementException e)
            {
                product.Feature = "no additional feature";
                product.FeatureDescription = "no additional feature";
                product.FeatureType = "other";
                product.MaterialFeature = item + "-o-0";
                DataBase.ExecuteProcedure(product);
            }

            try
            {
                IList<IWebElement> thumbs = Driver.Instance.FindElements(By.ClassName("s7thumbcell"));
                foreach (IWebElement imageElement in thumbs)
                {
                    

                    //width: 56px; height: 56px; background-image: url("https://kitchenaid-h.assetsadobe.com/is/image/content/dam/business-unit/whirlpool/es-mx/assets/product/kitchen/refrigeration/top-mount/wt1865a/WT1865A%2000.jpg?fit=constrain,1&wid=56&hei=56&fmt=jpg");
                    string a = imageElement.Text;
                    a = a + "";
                    //var style = imageElement.GetCssValue("backgroundImage");
                    
                    //if (style != "none")
                    //{
                    //    var http = style.IndexOf("http");

                    //    var url = style.Substring(http, style.Length - 7);


                    //    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                    //    webRequest.AllowAutoRedirect = false;
                    //    HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                    //    var code = response.StatusCode.ToString();


                    //    int active = (code == "OK") ? 1 : 0;

                    //    DataBase.InsertImage(item, url, active);
                    //}
                    //else
                    //{

                    //    DataBase.InsertImage(item,"no url",0);
                    //}







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
