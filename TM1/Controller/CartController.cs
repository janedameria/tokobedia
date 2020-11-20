using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TM1.Handler;
using TM1.Helpers;
using TM1.Models;

namespace TM1.Controller
{
    public class CartController
    {
        public static Response InsertCart(int UserID, int ProductID, string QuantityTxt)
        {
            if(QuantityTxt == "")
            {
                return new Response(false, "Quantity must be filled");
            }

            int Quantity;

            if(!int.TryParse(QuantityTxt, out Quantity))
            {
                return new Response(false, "Quantity must be numeric");
            }

            Quantity = int.Parse(QuantityTxt);
            if (Quantity < 1)
            {
                return new Response(false, "Quantity must be more than 0");
            }

            Response response = CartHandler.InsertCart(UserID, ProductID, Quantity);
            return response;
        }
        public static Cart GetCart(int ProductID, int UserID)
        {
            return CartHandler.GetCart(ProductID, UserID);
        }

        public static Response UpdateCart(int ProductID, int UserID, string QuantityTxt)
        {
            if(QuantityTxt == "")
            {
                return new Response(false, "Quantity must be filled");
            }
            int Quantity;
            if (!int.TryParse(QuantityTxt, out Quantity))
            {
                return new Response(false, "Quantity must be numeric");
            }
            Quantity = int.Parse(QuantityTxt);

            if (Quantity < 0)
            {
                return new Response(false, "Quantity must be 0 or more than 0");
            }

            Response response = CartHandler.UpdateCart(ProductID, UserID, Quantity);
            return response;
        }

        public static List<Cart> GetCartbyUser(int UserID)
        {
            return CartHandler.GetCartbyUser(UserID);
        }
        public static Response DeleteCart(int ProductID, int UserID)
        {
            Response response = CartHandler.DeleteCart(ProductID, UserID);

            return response;
        }

      
    }
}