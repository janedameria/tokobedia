using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TM1.Models;

namespace TM1.Factories
{
    public class ProductFactories
    {

        public static Product InsertProduct(int productTypeID, string name, int price, int stock)
        {
            Product pro = new Product()
            {
                ProductTypeID = productTypeID,
                Name = name,
                Price = price,
                Stock = stock
            };
            return pro;
        }
    }
}