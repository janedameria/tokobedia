using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TM1.Models;

namespace TM1.Factories
{
    public class TransactionsFactories
    {
        public static TokobediaEntitiesEntities db = new TokobediaEntitiesEntities();
        public static Detail_Transaction InsertDetailTransaction(int TransactionID, int ProductID, int Quantity)
        {
            Detail_Transaction DetailTrans = new Detail_Transaction()
            {
                TransactionID = TransactionID,
                ProductID = ProductID,
                Quantity = Quantity
            };

            return DetailTrans;
        }
        public static Header_Transaction InsertHeaderTransaction(int UserID, int PaymentID, DateTime date)
        {
            Header_Transaction HeadTrans = new Header_Transaction
            {
                UserID = UserID,
                PaymentTypeID = PaymentID,
                Date = date
            };

            return HeadTrans;
        }
    }
}