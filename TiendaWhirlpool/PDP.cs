using System.Collections.Generic;
using OpenQA.Selenium;

namespace TiendaWhirlpool
{
    public static class PDP
    {

        public static bool HasPrice()
        {
            IWebElement price_indicator = Driver.Instance.FindElement((By.ClassName("pdp-tray__price")));
            var price = price_indicator.Text.Substring(price_indicator.Text.IndexOf("$")+1).Replace(",","");

            if (float.Parse(price.ToString())>0) return true;
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
            var sku_description = Driver.Instance.FindElement(By.ClassName("pdp-tray__prd-title--text")).Text;

            


            foreach (IWebElement pdpKeyFeature in pdp_key_features)
            {
                var feature_title = pdpKeyFeature.FindElement(By.ClassName("pdp-features-tile-title")).Text;
                var feature_description = pdpKeyFeature.FindElement(By.ClassName("pdp-features-tile-desc")).Text;
                string command = "INSERT INTO Products(SKU,Feature,FeatureType,Price,Description,FeatureDescription) VALUES ('" + sku_code + "','" + feature_title + "','key','" + price + "','"+sku_description+"','"+ feature_description+"')";
                DataBase.ExecuteNonQueryCommand(command);
            }
            foreach (IWebElement pdpOtherFeature in pdp_other_features)
            {
                var feature_title = pdpOtherFeature.FindElement(By.ClassName("pdp-add-feat-title")).Text;
                var feature_description = pdpOtherFeature.FindElement(By.ClassName("pdp-add-feat-desc")).Text;
                string command = "INSERT INTO Products(SKU,Feature,FeatureType,Price,Description,FeatureDescription) VALUES ('" + sku_code + "','" + feature_title + "','other','" + price + "','"+sku_description+"','"+ feature_description+ "')";
                DataBase.ExecuteNonQueryCommand(command);
            }
            
            return true;
        }
    }
}
