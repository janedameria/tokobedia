using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TM1.Models;
using TM1.Repositories;

namespace TM1.Handler
{
    public class TransactionHandler
    {
        public static List<Header_Transaction> GetHeaderTransactionsByUser(int UserID)
        {
            return TransactionRepositories.GetHeaderTransactionsByUser(UserID);
        }

        public static List<Detail_Transaction> GetDetailTransactionsByTransactionID(int TransactionID)
        {
            return TransactionRepositories.GetDetailTransactionsByTransactionID(TransactionID);
        }

        public static List<Header_Transaction> GetHeaderTransactions()
        {
            return TransactionRepositories.GetHeaderTransactions();
        }


        public static List<Detail_Transaction> GetDetailTransactions()
        {
            return TransactionRepositories.GetDetailTransactions();
        }
    }
}