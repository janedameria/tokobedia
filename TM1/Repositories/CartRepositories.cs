using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TM1.Models;

namespace TM1.Repositories
{
    public class CartRepositories
    {
        private static TokobediaEntitiesEntities db = new TokobediaEntitiesEntities();

        public static Cart InsertCart(Cart cart)
        {
            db.Carts.Add(cart);
            db.SaveChanges();
            return cart;
        }

        public static Cart UpdateCart(Cart cart, int Quantity)
        {
            cart.Quantity = Quantity;
            db.SaveChanges();

            return cart;
        }

        public static Cart DeleteCart(int ProductID, int UserID)
        {
            Cart cart = (from x in db.Carts where x.ProductID == ProductID && x.UserID == UserID select x).FirstOrDefault();
            db.Carts.Remove(cart);
            db.SaveChanges();
            return cart;
        }
        
        public static List<Cart> GetCartbyProduct(int ProductID)
        {
           return (from x in db.Carts where x.ProductID == ProductID select x).ToList();
        }

        public static Cart GetCart(int ProductID, int UserID)
        {
            Cart cart = (from x in db.Carts where x.ProductID == ProductID && x.UserID == UserID select x).FirstOrDefault();
            return cart;
        }

        public static List<Cart> GetCartbyUser(int UserID)
        {
            return (from x in db.Carts where x.UserID == UserID select x).ToList();
        }

        public static Cart GetCartByProduct(int ProductID)
        {
            return (from x in db.Carts where x.ProductID == ProductID select x).FirstOrDefault();
        }
    }
}