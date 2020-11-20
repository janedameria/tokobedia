using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TM1.Models;

namespace TM1.Repositories
{
    public class PaymentRepositories
    {
        private static TokobediaEntitiesEntities db = new TokobediaEntitiesEntities();

        public static PaymentType InsertPaymentType(PaymentType payment)
        {
            db.PaymentTypes.Add(payment);
            db.SaveChanges();

            return payment;
        }

        public static PaymentType DeletePaymentType(PaymentType payment)
        {
            db.PaymentTypes.Remove(payment);
            db.SaveChanges();
            return payment;
        }

        public static PaymentType UpdatePaymentType(PaymentType payment, string newType)
        {
         
            payment.Type = newType;
           db.SaveChanges();
            return payment;
        }

        public static PaymentType GetPaymentType(string name)
        {
            PaymentType payment = (from x in db.PaymentTypes where x.Type == name select x).FirstOrDefault();
            return payment;
        }
        public static PaymentType GetPaymentType(int ID)
        {
            PaymentType payment = (from x in db.PaymentTypes where x.ID == ID select x).FirstOrDefault();
            return payment;
        }
        public static List<PaymentType> GetPaymentTypes()
        {
            return db.PaymentTypes.ToList();
        }
    }
}