using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TM1.Handler;
using TM1.Helpers;
using TM1.Models;

namespace TM1.Controller
{
    public class UserController
    {
        public static User GetUser(string email)
        {
            return UserHandler.GetUser(email);
        }
        public static User GetUser(int id)
        {
            return UserHandler.GetUser(id);
        }
        public static List<User> GetUsers()
        {
            return UserHandler.GetUsers();
        }

        public static Response UpdateUserActiviation(int clickedUserID, int nowSessionID)
        {
            if(clickedUserID == nowSessionID)
            {
                return new Response(false, "You can't change your own status.");
            }

            Response response = UserHandler.UpdateUserActiviation(clickedUserID);
            return response;

        }

        public static Response UpdateUser(int id, string name, string email, string gender)
        {
            if(name == "")
            {
                return new Helpers.Response(false, "Name cant be empty");
            }
            if(email == "")
            {
                return new Helpers.Response(false, "Email cant be empty");
            }
            Response response = UserHandler.UpdateUser(id, name, email, gender);
            return response;

        }

        public static Response InsertUser(int roleID, string name, string email, string pass, string confpass, bool Female, bool Male, string status)
        {
            if(name == "")
            {
                return new Response(false, "Name cant be empty");
            }
            if (email == "")
            {
                return new Response(false, "Email cant be empty");
            }
            if (pass == "")
            {
                return new Response(false, "Password cant be empty");
            }
            if (pass != confpass)
            {
                return new Response(false, "Password and confirm password must be the same");
            }
            if(!Female && !Male)
            {
                return new Response(false, "Gender must be choosen");
            }
            String gender = "";

            if (Female)
            {
                gender = "Female";
            }

            if (Male)
            {
                gender = "Male";
            }
            
            Response response = UserHandler.InsertUser(roleID, name, email, pass, gender, status);
            return response;

        }

        public static Response doChangePassword(string email, string oldPass, string newPass, string confPass)
        {
            if(newPass != confPass)
            {
                return new Response(false, "Confirm password must be matched with the new password");
            }
            Response response = UserHandler.doChangePassword(email, oldPass, newPass);
            return response;

        }
    }
}