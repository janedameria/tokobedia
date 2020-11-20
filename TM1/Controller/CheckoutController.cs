using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TM1.Handler;
using TM1.Helpers;
using TM1.Models;

namespace TM1.Controller
{
    public class CheckoutController
    {
        

        public static Response doCheckout(List<Cart> carts, int UserID, int PaymentTypeID, DateTime date)
        {
              
            if (!carts.Any())
            {
                return new Response(false, "Cant do checkout because cart is empty");
            }

            Response response = CheckoutHandler.doCheckout(carts, UserID, PaymentTypeID, date);
            return response;
        }
    }
}