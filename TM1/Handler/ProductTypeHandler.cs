using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TM1.Factories;
using TM1.Helpers;
using TM1.Models;
using TM1.Repositories;

namespace TM1.Handler
{
    public class ProductTypeHandler
    {
        public static Response InsertProductType(string name, string desc)
        {

            if (ProductTypeRepositories.GetProductType(name) == null)
            {
                Product_Type pro = ProductTypeFactories.InsertProductType(name, desc);
                ProductTypeRepositories.InsertProductType(pro);
                return new Response(true);
            }

            return new Response(false, "The product type must be unique");
        }
        public static Response DeleteProductType(int productTypeID)
        {

            if (ProductRepositories.GetProductByProductTypeID(productTypeID) != null)
            {
                return new Response(false, "Cant delete this product type because its referenced in another table.");
            }

            ProductTypeRepositories.DeleteProductType(productTypeID);
            return new Response(true);
        }
        public static Product_Type GetProductType(int ID)
        {
            return ProductTypeRepositories.GetProductType(ID);

        }
        public static Response UpdateProductType(int protypeid, string name, string desc)
        {
            Product_Type pro = ProductTypeRepositories.GetProductType(protypeid);
            if (pro.Name == name || ProductTypeRepositories.GetProductType(name) == null)
            {
                ProductTypeRepositories.UpdateProductType(protypeid, name, desc);
                return new Response(true);
            }


            return new Response(false, "Product Type must be unique");
        }


        public static List<Product_Type> GetProductTypes()
        {
            return ProductTypeRepositories.GetProductTypes();
        }
    }
}