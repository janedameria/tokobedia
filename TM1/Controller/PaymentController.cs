using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TM1.Handler;
using TM1.Helpers;
using TM1.Models;

namespace TM1.Controller
{
    public class PaymentController
    {
        public static Response InsertPaymentType(string name)
        {
            if(name == "")
            {
                return new Response(false, "Type must be filled");
            }
            if (name.Length < 3 )
            {
                return new Response(false, "Type must consists of 3 characters or more");
            }

            Response response = PaymentHandler.InsertPaymentType(name);
            return response;
        }

        public static PaymentType GetPayment(int ID)
        {
          
            return PaymentHandler.GetPayment(ID);
        }

        public static List<PaymentType> GetPaymentTypes()
        {
            return PaymentHandler.GetPaymentTypes();
        }

        public static Response DeletePayment(int ID)
        {
            Response response = PaymentHandler.DeletePayment(ID);

            return response;
        }

        public static Response UpdatePayment(int ID, string newType)
        {

            if (newType == "")
            {
                return new Response(false, "Type must be filled");
            }
            if (newType.Length < 3)
            {
                return new Response(false, "Type must consists of 3 characters or more");
            }

            Response response = PaymentHandler.UpdatePayment(ID, newType);
            return response;
        }
    }
}