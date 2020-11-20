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
    public class CartHandler
    {
        public static int TotalInCart(List<Cart> ListCart)
        {
            int stock = 0;
            for (int i = 0; i < ListCart.Count; i++)
            {
                stock += ListCart[i].Quantity;
            }
            return stock;
        }


        public static Response InsertCart(int UserID, int ProductID, int Quantity)
        {
            Product pro = ProductRepositories.GetProduct(ProductID);
            if(Quantity > pro.Stock)
            {
                return new Response(false, "Quantity must be less than or equals to current stock ");
            }



            int total = 0;

            List<Cart> CartList = CartRepositories.GetCartbyProduct(ProductID);
            if (CartList.Any())
            {
                total = TotalInCart(CartList);
                int stock = pro.Stock - total;
                if (Quantity > stock)
                {
                    if (stock < 1)
                    {
                        return new Response(false, "Cant add to cart because out of stock.");
                    }
                    else
                    {
                        return new Response(false, "Quantity must be " + stock.ToString() + " or below");
                    }
                }
            }

            Cart CheckCartExists = CartRepositories.GetCart(ProductID, UserID);
            if(CheckCartExists != null)
            {
                int stock = pro.Stock - total;
                if(Quantity > stock)
                {
                    if (stock < 1)
                    {
                        return new Response(false, "Cant add to cart because out of stock.");
                    }
                    else
                    {
                        return new Response(false, "Quantity must be " + stock.ToString() + " or below");
                    }
                    
                }

                else
                {
                    CartRepositories.UpdateCart(CheckCartExists, Quantity + CheckCartExists.Quantity);
                    return new Response(true);
                }
            }

        
            Cart cart = CartFactories.InsertCart(UserID, ProductID, Quantity);
            CartRepositories.InsertCart(cart);
            return new Response(true);

        }

        public static List<Cart> GetCartbyUser(int UserID)
        {
            return CartRepositories.GetCartbyUser(UserID);
        }
        public static Cart GetCart(int ProductID, int UserID)
        {
            return CartRepositories.GetCart(ProductID, UserID);
        }
        public static Response DeleteCart(int ProductID, int UserID) 
        {
            Cart cart = CartRepositories.DeleteCart(ProductID, UserID);
            if(cart != null)
            {
                return new Response(true);
            }

            return new Response(false, "Cart cant be found");
        }

        public static Response UpdateCart(int ProductID, int UserID, int Quantity)
        {
            Product pro = ProductRepositories.GetProduct(ProductID);
            

            if (Quantity > pro.Stock)
            {
                return new Response(false, "Quantity must be less than or equals to current stock ");
            }

            List<Cart> CartList = CartRepositories.GetCartbyProduct(ProductID);
            Cart cart = CartRepositories.GetCart(ProductID, UserID);

            if(Quantity == 0)
            {
                CartRepositories.DeleteCart(ProductID, UserID);
                return new Response(true);

            }
            if (CartList.Any())
            {
                int total = TotalInCart(CartList);
                int stock = pro.Stock - total + cart.Quantity;

                if (Quantity > stock)
                {
                    return new Response(false, "Quantity must be " + stock.ToString() + "or below");
                }

                else
                {
                    CartRepositories.UpdateCart(cart, Quantity);
                    return new Response(true);
                }
            }
            
            CartRepositories.UpdateCart(cart, Quantity);
            return new Response(true);
        }

      
    }
}