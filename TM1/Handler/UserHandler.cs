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
    public class UserHandler
    {
       public static User GetUser(String email)
        {
            return UserRepositories.GetUserName(email);
        }
        public static User GetUser(int id)
        {
            return UserRepositories.GetUser(id);
        }
        public static Response UpdateUserActiviation(int id)
        {
            User u = UserRepositories.GetUser(id);
            if (u != null)
            {
                if(u.Status == "Active")
                {
                    UserRepositories.UpdateUserActivation(id, "Blocked");
                }
                else
                {
                    UserRepositories.UpdateUserActivation(id, "Active");
                }
                return new Response(true);
            }
            

            return new Response(false, "No User found");
        }

        public static List<User> GetUsers()
        {
            return UserRepositories.GetUsers();
        }

       public static Response InsertUser(int roleID, string name, string email, string pass, string gender, string status)
        {
            if(UserRepositories.GetUserName(email) == null)
            {
                User newUser = UserFactories.InsertUser(roleID, name, email, pass, gender, status);
                UserRepositories.InsertUser(newUser);
                return new Response(true);
            }

            return new Response(false, "The email has been taken");
        }

      

        public static Response UpdateUser(int id, string name, string email, string gender)
        {

            User u = UserRepositories.GetUser(id);
            if(u.Email == email)
            {
                UserRepositories.UpdateUser(u, name, email, gender);
                return new Response(true);
            }

            if(UserRepositories.GetUserName(email) == null)
            {
                UserRepositories.UpdateUser(u, name, email, gender);
                return new Response(true);
            }

            return new Response(false, "The email has been taken.");


        }

        public static Response doChangePassword(string email, string oldPassword, string newPassword)
        {

            User u = UserRepositories.GetUserName(email);
            if(u.Password != oldPassword)
            {
                return new Response(false, "Old Password must be same with current password");
            }
            if (u.Password == newPassword)
            {
                return new Response(false, "New password cannot be the same with old password");
            }
            UserRepositories.UpdateUserPassword(u.ID, newPassword);

            return new Response(true);
        }
      
    }
}