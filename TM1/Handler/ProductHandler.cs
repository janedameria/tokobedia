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
    public class ProductHandler
    {
        public static Response InsertProduct(int productTypeID, string name, int price, int stock)
        {
            Product pro = ProductFactories.InsertProduct(productTypeID, name, price, stock);
            ProductRepositories.InsertProduct(pro);

            return new Response(true);
        }
      
        public static Response DeleteProduct(int ProductID)
        {
            Cart cart = CartRepositories.GetCartByProduct(ProductID);
            Detail_Transaction detailTran = TransactionRepositories.GetDetailTransactionByProductID(ProductID);

            if (cart != null || detailTran != null)
            {
                return new Response(false, "Cant delete this product because its referenced in another table in database");
            }

            Product pro = ProductRepositories.GetProduct(ProductID);

            if(pro != null)
            {
                ProductRepositories.DeleteProduct(ProductID);
                return new Response(true);
            }

            return new Response(false, "cant find the product");

        }


        public static Product GetProduct(int ID)
        {
            return ProductRepositories.GetProduct(ID);

        }
        

        public static Response UpdateProduct(int productid, string name, int price, int stock)
        {
            if (ProductRepositories.GetProduct(productid) != null)
            {
                ProductRepositories.UpdateProduct(productid, name, price, stock);
                return new Response(true);
            }
           
            return new Response(false);
        }

      

        public static List<Product> GetProducts()
        {
            return ProductRepositories.GetProducts();
        }

    }
}