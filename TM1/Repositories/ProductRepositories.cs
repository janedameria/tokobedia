using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TM1.Factories;
using TM1.Models;

namespace TM1.Repositories
{
   
    public class ProductRepositories
    {
        private static TokobediaEntitiesEntities db = new TokobediaEntitiesEntities();


        public static Product InsertProduct(Product pro)
        {
           
            db.Products.Add(pro);
            db.SaveChanges();

            return pro;
        }

        public static Product GetProduct(int ProductID)
        {
            Product pro = (from x in db.Products where x.ID == ProductID select x).FirstOrDefault();
            return pro;
        }


        public static Product GetProductByProductTypeID(int ProductTypeID)
        {
            return (from x in db.Products where x.ProductTypeID == ProductTypeID select x).FirstOrDefault();
        }
        public static List<Product> GetProducts()
        {
            return db.Products.ToList();
        }
  

        public static Product UpdateProduct(int ID, string name, int price, int stock)
        {
            Product pro = GetProduct(ID);
            pro.Name = name;
            pro.Price = price;
            pro.Stock = stock;
            db.SaveChanges();
            return pro;

       }

        public static Product DeleteProduct(int ID)
        {
            Product pro = GetProduct(ID);
            db.Products.Remove(pro);
            db.SaveChanges();
            return pro;
            
        }
     
    }
}