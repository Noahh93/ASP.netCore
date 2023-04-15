﻿using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
        List<User> _users;
        public LoginController() 
        {
            _users = new List<User>();
            User user1 = new User();
            user1.Firstname = "John";
            user1.Lastname = "Adamson";
            user1.Email = "J.Adams@gmail.com";
            user1.Password = "12345";

            _users.Add(user1);

            User user2 = new User();
            user2.Firstname = "Laverz";
            user2.Lastname = "Schlowinsky";
            user2.Email = "Schmo_2@gmai.com";
            user2.Password = "abcde";

            _users.Add(user2);

            User user3 = new User();
            user3.Firstname = "Mahmood";
            user3.Lastname = "Abdi";
            user3.Email = "AbdiMahmod@yahoo.com";
            user3.Password = "password";

            _users.Add(user3);
        }
        public ActionResult LoginForm()
        {
            return View();
        }
        public ActionResult CheckUser(string email, string password)
        {
            foreach(User user in _users)
            {
                if (email == user.Email && password == user.Password)
                {
                    return View("Welcome");
                }
            }
            ViewBag.errorMessage = "Wrong user, please check your password!";
            return View("LoginForm");
        }
    }
}
