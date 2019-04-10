using System;
using System.Collections.Generic;
using System.Text;

namespace SharedClasses
{
    public class ProductDetail
    {
        public string SKU { get; set; }
        public string Description { get; set; }
    }

    public class ProductImages
    {
        public string SKU { get; set; }
        public string HeroImage { get; set; }
        public IList<string> Thumbnail { get; set; }
    }
    

    public class ProductFeature
    {
        public string SKU { get; set; }
        public string Feature { get; set; }
        public string FeatureDescription { get; set; }
        public string FeatureType { get; set; }
    }

    public class Producto
    {
        public string SKU { get; set; }
    }

    public class ProductDetailPage
    {
        public string ProductoId { get; set; }
        public string URL { get; set; }
        public string Date { get; set; }
    }

    public class ProductDetail2
    {
        public string DetailTypeId { get; set; }
        public string ProductDetailPageId { get; set; }
        public string Value { get; set; }
        public string Date { get; set; }

    }

    public class ProductListPage
    {
        public string URL { get; set; }
        public string Name { get; set; }
    }
}
