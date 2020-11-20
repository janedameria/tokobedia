using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TM1.Helpers;
using TM1.Models;
using TM1.Repositories;

namespace TM1.Handler
{
    public class LoginHandler
    {
        public static Response doLogin(string email, string password)
        {
            User u = UserRepositories.GetUser(email, password);

            if (u == null)
            {
                return new Response(false, "Wrong email or password.");
            }

            if (u.Status == "Blocked")
            {
                return new Response(false, "Your account is blocked.");
            }

            return new Response(true);
        }
    }
}