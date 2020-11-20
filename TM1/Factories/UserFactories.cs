using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TM1.Models;

namespace TM1.Factories
{
    public class UserFactories
    {
        public static User InsertUser(int roleID, string name, string email, string password, string gender, string status)
        {
            User u = new User()
            {
                RoleID = roleID,
                Name = name,
                Email = email,
                Password = password,
                Gender = gender,
                Status = status
                              
            };
            return u;
        }

        
    }
}