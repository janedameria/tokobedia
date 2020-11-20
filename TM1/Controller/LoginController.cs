using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TM1.Handler;
using TM1.Helpers;
using TM1.Models;

namespace TM1.Controller
{
    public class LoginController
    {
        public static Response doLogin (string email, string password)
        {
            if(email == "")
            {
                return new Response(false, "Email can't be empty");
            }

            if(password == "")
            {
                return new Response(false, "Password can't be empty");
            }

            Response response = LoginHandler.doLogin(email, password);
            return response;
        }

      
    }
}