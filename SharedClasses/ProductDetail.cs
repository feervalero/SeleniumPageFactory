using System;
using System.Collections.Generic;
using System.Text;

namespace SharedClasses
{
    public class ProductDetail
    {
        public string SKU { get; set; }
        public string Description { get; set; }
        public string MaterialFeature { get; set; }
        public string Price { get; set; }
        public string BrandCode { get; set; }
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
