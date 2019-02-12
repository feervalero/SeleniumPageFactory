using System;
using System.Collections.Generic;
using Microsoft.SqlServer.Server;
using OpenQA.Selenium;
using SharedClasses;


namespace KitchenAid
{
    public static class PDP
    {

        public static bool HasPrice()
        {
            IWebElement price_indicator = Driver.Instance.FindElement((By.ClassName("pdp-tray__price")));
            var price = price_indicator.Text.Substring(price_indicator.Text.IndexOf("$")+1).Replace(",","");

            if (float.Parse(price)>0) return true;
            else return false;
        }

        public static bool HasFeatures()
        {
            //pdp-features-tile-content
            IReadOnlyCollection<IWebElement> pdp_key_features = Driver.Instance.FindElements(By.ClassName("pdp-features-tile-content"));
            //pdp-add-feat-title
            IReadOnlyCollection<IWebElement> pdp_other_features = Driver.Instance.FindElement(By.ClassName("pdp-additional-features")).FindElements(By.ClassName("g-row"));
            //pdp-tray__prd-detail-list
            var sku_code = Driver.Instance.FindElement(By.ClassName("pdp-tray__prd-detail-list")).GetAttribute("data-prod-code");
            //price 
            IWebElement price_indicator = Driver.Instance.FindElement((By.ClassName("pdp-tray__price")));
            var price = price_indicator.Text.Substring(price_indicator.Text.IndexOf("$") + 1).Replace(",", "");
            //pdp-tray__prd-title--text
            var sku_description = "";
            try
            {
                sku_description = Driver.Instance.FindElement(By.ClassName("pdp-tray__prd-title--text")).Text;
            }
            catch (OpenQA.Selenium.NoSuchElementException)
            {
                sku_description = "no title";
            }
            

            


            foreach (IWebElement pdpKeyFeature in pdp_key_features)
            {
                var feature_title = "";
                var feature_description = "";
                try
                {
                    feature_title = pdpKeyFeature.FindElement(By.ClassName("pdp-features-tile-title")).Text;
                }
                catch (NoSuchElementException e)
                {
                    feature_title = "no feature title";
                }

                try
                {
                    feature_description = pdpKeyFeature.FindElement(By.ClassName("pdp-features-tile-desc")).Text;
                }
                catch (NoSuchElementException e)
                {
                    feature_description = "no feature description";
                }
                

                //string command = "INSERT INTO Products(SKU,Feature,FeatureType,Price,Description,FeatureDescription) VALUES ('" + sku_code + "','" + feature_title + "','key','" + price + "','"+sku_description+"','"+ feature_description+"')";

                SharedClasses.ProductDetail product = new SharedClasses.ProductDetail();
                product.SKU = sku_code;
                product.Feature = feature_title;
                product.FeatureDescription = feature_description;
                product.FeatureType = "key";
                product.Price = price;
                product.BrandCode = "KAD";
                product.Description = sku_description;

                DataBase.ExecuteProcedure(product);

                
            }
            foreach (IWebElement pdpOtherFeature in pdp_other_features)
            {
                var feature_title = "";
                try
                {
                    feature_title = pdpOtherFeature.FindElement(By.ClassName("pdp-add-feat-title")).Text;
                }
                catch (NoSuchElementException e)
                {
                    feature_title = "no feature title";
                }

                var feature_description = "";

                try
                {
                    feature_description = pdpOtherFeature.FindElement(By.ClassName("pdp-add-feat-desc")).Text;
                }
                catch (NoSuchElementException e)
                {
                    feature_description = "";
                }


                
                //string command = "INSERT INTO Products(SKU,Feature,FeatureType,Price,Description,FeatureDescription) VALUES ('" + sku_code + "','" + feature_title + "','other','" + price + "','"+sku_description+"','"+ feature_description+ "')";
                

                ProductDetail product = new ProductDetail();
                product.SKU = sku_code;
                product.Feature = feature_title;
                product.FeatureDescription = feature_description;
                product.FeatureType = "other";
                product.Price = price;
                product.BrandCode = "KAD";
                product.Description = sku_description;

                DataBase.ExecuteProcedure(product);
            }
            
            return true;
        }
    }
}
