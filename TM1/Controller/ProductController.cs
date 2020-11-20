using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TM1.Handler;
using TM1.Helpers;
using TM1.Models;

namespace TM1.Controller
{
    public class ProductController
    {

      
        public static List<Product> GetProducts()
        {
            return ProductHandler.GetProducts();
        }

        public static Product GetProduct(int ID)
        {
            return ProductHandler.GetProduct(ID);
        }
        public static Response DeleteProduct(int ProductID)
        {
            Response response = ProductHandler.DeleteProduct(ProductID);
            return response;
        }
       
        public static List<Product> RandomizeProduct()
        {
            List<Product> ProductList = ProductHandler.GetProducts();
            List<Product> NewProductList = new List<Product>();
            Random rand = new Random();
            int index = 0;
            if (ProductList.Count <= 5)
            {
                return ProductList;
            }

            for (int i = 0; i < 5; i++)
            {
                index = rand.Next(0, ProductList.Count);
                while (isDuplicate(NewProductList, ProductList[index]))
                {
                    index = rand.Next(0, ProductList.Count);
                }
                NewProductList.Add(ProductList[index]);

            }

            return NewProductList;
        }

        protected static bool isDuplicate(List<Product> ListProduct, Product pro)
        {
            foreach (var item in ListProduct)
            {
                if (pro == item)
                {
                    return true;
                }
            }
            return false;
        }
        public static Response UpdateProduct(int productid, string name, string priceTxt, string stockTxt)
        {
            if(priceTxt == "")
            {
                return new Response(false, "Price must be filled.");
            }
            if (stockTxt == "")
            {
                return new Response(false, "Stock must be filled.");
            }
            if (name == "")
            {
                return new Response(false, "Name must be filled.");
            }

            int stock = int.Parse(stockTxt);
            int price = int.Parse(priceTxt);

            if (stock < 1)
            {
                return new Response(false, "Stock must be 1 or over 1.");
            }

            if (price < 1000 || price % 1000 != 0)
            {
                return new Response(false, "price must be above 1000 and multiply of 1000.");

            }

            Response response = ProductHandler.UpdateProduct(productid, name, price, stock);
            return response;

        }
      
        public static Response InsertProduct(int productTypeID, string name, string priceTxt, string stockTxt)
        {
           if(priceTxt == "")
            {
                return new Response(false, "Price must be filled.");
            }

            if (name == "")
            {
                return new Response(false, "Name must be filled.");

            }
            if (stockTxt == "")
            {
                return new Response(false, "Stock must be filled.");
            }

            int stock = int.Parse(stockTxt);
            int price = int.Parse(priceTxt);

            if (stock < 1)
            {
                return new Response(false, "Stock must be 1 or more");

            }

            if (price < 1000 || price % 1000 != 0)
            {
                return new Response(false, "Price must be over 1000 and multiply of 1000");

            }

            Response response = ProductHandler.InsertProduct(productTypeID, name, price, stock);

            return response;
        }
    }

}