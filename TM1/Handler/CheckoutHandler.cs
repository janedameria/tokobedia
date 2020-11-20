using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TM1.Factories;
using TM1.Helpers;
using TM1.Models;
using TM1.Repositories;

namespace TM1.Handler
{
    public class CheckoutHandler
    {
        
      

        public static Response doCheckout(List<Cart> carts, int UserID, int PaymentTypeID, DateTime date)
        {
            Header_Transaction headerTran = TransactionsFactories.InsertHeaderTransaction(UserID, PaymentTypeID, date);
            TransactionRepositories.InsertHeaderTransaction(headerTran);

            Detail_Transaction detailTran = new Detail_Transaction();

            for (int i = 0; i<carts.Count; i++)
            {
                detailTran = TransactionsFactories.InsertDetailTransaction(headerTran.ID, carts[i].ProductID, carts[i].Quantity);
                TransactionRepositories.InsertDetailTransaction(detailTran);
                CartRepositories.DeleteCart(carts[i].ProductID, UserID);

            }
            
            return new Response(true);
        }
    }
}