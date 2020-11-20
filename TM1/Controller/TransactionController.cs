using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TM1.Handler;
using TM1.Models;

namespace TM1.Controller
{
    public class TransactionController
    {
        public static List<Header_Transaction> GetHeaderTransactionsByUser(int UserID)
        {
            return TransactionHandler.GetHeaderTransactionsByUser(UserID);
        }
        public static List<Detail_Transaction> GetDetailTransactionsByTransactionID(int TransactionID)
        {
            return TransactionHandler.GetDetailTransactionsByTransactionID(TransactionID);
        }
        public static List<Header_Transaction> GetHeaderTransactions()
        {
            return TransactionHandler.GetHeaderTransactions();
        }

        public static List<Detail_Transaction> GetDetailTransactions()
        {
            return TransactionHandler.GetDetailTransactions();
        }
    }
}