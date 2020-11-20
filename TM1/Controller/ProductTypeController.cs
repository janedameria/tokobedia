using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TM1.Handler;
using TM1.Helpers;
using TM1.Models;

namespace TM1.Controller
{
    public class ProductTypeController
    {
        public static List<Product_Type> GetProductTypes()
        {
            return ProductTypeHandler.GetProductTypes();
        }

        public static Product_Type GetProductType(int ID)
        {
            return ProductTypeHandler.GetProductType(ID);
        }
        public static Response DeleteProductType(int ID)
        {

            Response response = ProductTypeHandler.DeleteProductType(ID);
            return response;

        }



        public static Response UpdateProductType(int protypeid, string name, string desc)
        {
            if (name == "" || name.Length < 5)
            {
                return new Response(false, "Product Type must be filled and consists of 5 characters or more");
            }

            if (desc == "")
            {
                return new Response(false, "Description ust be filled.");

            }



            Response response = ProductTypeHandler.UpdateProductType(protypeid, name, desc);

            return response;

        }
        public static Response InsertProductType(string productType, string desc)
        {
            if (productType.Length < 5)
            {
                return new Response(false, "Product type must be over 5 characters");


            }
            else if (desc == "")
            {
                return new Response(false, "Description must be filled.");

            }
            Response response = ProductTypeHandler.InsertProductType(productType, desc);

            return response;
        }

    }
}