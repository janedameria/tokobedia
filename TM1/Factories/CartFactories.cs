using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TM1.Models;

namespace TM1.Factories
{
    public class CartFactories
    {
        public static Cart InsertCart(int UserID, int ProductID, int Quantity)
        {
            Cart cart = new Cart()
            {
                UserID = UserID,
                ProductID = ProductID,
                Quantity = Quantity
            };

            return cart;
        }
    }
}