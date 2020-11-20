using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TM1.Models;

namespace TM1.Repositories
{
    public class ProductTypeRepositories
    {
        private static TokobediaEntitiesEntities db = new TokobediaEntitiesEntities();


        public static Product_Type InsertProductType(Product_Type pro)
        {
            db.Product_Types.Add(pro);
            db.SaveChanges();

            return pro;
        }
        public static List<Product_Type> GetProductTypes()
        {
            return db.Product_Types.ToList();
        }
        public static Product_Type GetProductType(int ProTypeID)
        {
            Product_Type pro = (from x in db.Product_Types where x.ID == ProTypeID select x).First();
            return pro;
        }
        public static Product_Type GetProductType(string Name)
        {
            Product_Type pro = (from x in db.Product_Types where x.Name == Name select x).FirstOrDefault();
            return pro;
        }

        public static Product_Type UpdateProductType(int id, string name, string desc)
        {
            Product_Type pro = GetProductType(id);
            pro.Name = name;
            pro.Description = desc;
            db.SaveChanges();
            return pro;
        }
        public static Product_Type DeleteProductType(int ID)
        {
            Product_Type pro = GetProductType(ID);
            db.Product_Types.Remove(pro);
            db.SaveChanges();
            return pro;
        }
    }
}