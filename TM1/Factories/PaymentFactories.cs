using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TM1.Models;

namespace TM1.Factories
{
    public class PaymentFactories
    {
        public static PaymentType InsertPaymentType(string name)
        {
            PaymentType payment = new PaymentType()
            {
                Type = name
            };

            return payment;
        }
 
    }
}