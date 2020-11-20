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
    public class PaymentHandler
    {
        public static Response InsertPaymentType(string name)
        {
            PaymentType checkPayment = PaymentRepositories.GetPaymentType(name);
            if (checkPayment == null) {
                PaymentType payment = PaymentFactories.InsertPaymentType(name);
                PaymentRepositories.InsertPaymentType(payment);
                return new Response(true);
            }
           return new Response(false, "Type must be unique");
        }

        public static List<PaymentType> GetPaymentTypes()
        {
            return PaymentRepositories.GetPaymentTypes();
        }

        public static PaymentType GetPayment(int ID)
        {
          return PaymentRepositories.GetPaymentType(ID);
         
        }

        public static Response DeletePayment(int ID)
        {
            if(TransactionRepositories.GetHeaderTransactionByPaymentID(ID) != null)
            {
                return new Response(false, "Cant delete this payment type because its referenced on another table in the database");
            }

            PaymentType payment = PaymentRepositories.GetPaymentType(ID);
            if(payment != null)
            {
                PaymentRepositories.DeletePaymentType(payment);
                return new Response(true);
            }

            return new Response(false, "Theres no selected payment type.");
        }
        public static Response UpdatePayment(int ID, string newType)
        {
            PaymentType oldPayment = PaymentRepositories.GetPaymentType(ID);
           
            if (oldPayment != null)
            {
                if(oldPayment.Type == newType)
                {
                    return new Response(true);
                }

                PaymentType newPayment = PaymentRepositories.GetPaymentType(newType);
                if (newPayment == null)
                {
                    PaymentRepositories.UpdatePaymentType(oldPayment, newType);
                    return new Response(true);
                }

                else
                {
                    return new Response(false, "The new type has been taken.");
                }
              
            }

            return new Response(false, "Theres no selected payment type.");
        }
    }
}