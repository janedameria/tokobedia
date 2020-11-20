using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TM1.Factories;
using TM1.Models;

namespace TM1.Repositories
{
    public class UserRepositories
    {
        private static TokobediaEntitiesEntities db = new TokobediaEntitiesEntities();

        public static User GetUser(string email, string password)
        {
            User u = (from user
                      in db.Users
                      where user.Email == email && user.Password == password
                      select user).FirstOrDefault();

            return u;
        }

        public static List<User> GetUsers()
        {
            return db.Users.ToList();
        }
        public static User GetUser(int id)
        {
            User u = (from User
                      in db.Users
                      where User.ID == id
                      select User).FirstOrDefault();
                 return u;
        }
        public static User GetUserName(string email)
        {
            User u = (from User
                      in db.Users
                      where User.Email == email
                      select User).FirstOrDefault();
            return u;
        }

        public static User InsertUser(User u)
        {
          
            db.Users.Add(u);
            db.SaveChanges();
            return u;
        }

        public static User UpdateUser(User u, string name, string email, string gender)
        {
           
            u.Name = name;
            u.Email = email;
            u.Gender = gender;
            db.SaveChanges();
            return u;
        }

        public static User UpdateUserActivation (int ID, string status)
        {
            User u = GetUser(ID);
            u.Status = status;
            db.SaveChanges();
            return u;
        }

        public static User UpdateUserPassword(int ID, string password)
        {
            User u = GetUser(ID);
            u.Password = password;
            db.SaveChanges();
            return u;
        }

    }
}