using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TM1;
using TM1.Models;

namespace TM1.Factories
{
  
    public class ProductTypeFactories
    {
        public static Product_Type InsertProductType(string name, string desc)
        {
            Product_Type pro = new Product_Type()
            {
                Name = name,
                Description = desc
            };

            return pro;
        }
       
    }
}