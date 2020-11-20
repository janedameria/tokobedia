using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TM1.Models;

namespace TM1.Repositories
{
    public class TransactionRepositories
    {
        private static TokobediaEntitiesEntities db = new TokobediaEntitiesEntities();

      
        public static Header_Transaction InsertHeaderTransaction(Header_Transaction HeadTrans)
        {
            db.Header_Transactions.Add(HeadTrans);
            db.SaveChanges();
            return HeadTrans;
        }
        public static Detail_Transaction GetDetailTransactionByProductID(int ProductID)
        {
            return (from x in db.Detail_Transactions where x.ProductID == ProductID select x).FirstOrDefault();
        }

        public static Header_Transaction GetHeaderTransactionByPaymentID(int PaymentID)
        {
            return (from x in db.Header_Transactions where x.PaymentTypeID == PaymentID select x).FirstOrDefault();
        }
        public static List<Header_Transaction> GetHeaderTransactionsByUser(int UserID)
        {
            return (from x in db.Header_Transactions where x.UserID == UserID select x).ToList();
        }
        public static List<Detail_Transaction> GetDetailTransactionsByTransactionID(int TransactionID)
        {
            return (from x in db.Detail_Transactions where x.TransactionID == TransactionID select x).ToList();
        }
        
        public static List<Header_Transaction> GetHeaderTransactions()
        {
            return (from x in db.Header_Transactions select x).ToList();
        }

        public static List<Detail_Transaction> GetDetailTransactions()
        {
            return (from x in db.Detail_Transactions select x).ToList();
        }

        public static Detail_Transaction InsertDetailTransaction(Detail_Transaction DetailTrans)
        {
            db.Detail_Transactions.Add(DetailTrans);
            db.SaveChanges();

            return DetailTrans;
        }
        
    }
}