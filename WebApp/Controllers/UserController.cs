using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Repository;

namespace WebApp.Controllers
{

    public class UserController : Controller
    {
        List<User> _users;
        public UserController() 
        {
            _users = new List<User>();
            User user1 = new User();
            user1.Id = 1;
            user1.Firstname = "John";
            user1.Lastname = "Smith";
            user1.Email = "J.sm88@gmail.com";

            _users.Add(user1);

            User user2 = new User();
            user2.Id = 2;
            user2.Firstname = "Smith";
            user2.Lastname = "John";
            user2.Email = "John.Baluchistani900@gmail.com";

            _users.Add(user2);

            User user3 = new User();
            user3.Id = 3;
            user3.Firstname = "John";
            user3.Lastname = "Habib";
            user3.Email = "js31-jan@yahoo.com";

            _users.Add(user3);

            User user4 = new User();
            user4.Id = 4;
            user4.Firstname = "John";
            user4.Lastname = "Smarahala";
            user4.Email = "sm.john@hotmail.com";

            _users.Add(user4);

            User user5 = new User();
            user5.Id = 5;
            user5.Firstname = "Smooth";
            user5.Lastname = "John";
            user5.Email = "JohnniBoy@gmail.com";

            _users.Add(user5);
        }
        public ActionResult SearchForm()
        {
            int totalNumberOfRecords = _users.Count;
            ViewBag.TotalNumberOfRecords = totalNumberOfRecords;
            return View(_users);
            
        }
        public ActionResult SearchUser(string userName) //This parameter comes from name="userName" in SearchForm
        {
            List<User> _newUsers = new List<User>(); 
            foreach (User user in _users)
            {
                string firstName = user.Firstname.ToLower();
                string lastName = user.Lastname.ToLower();
                string paramUserName = userName.ToLower();

                if (paramUserName == firstName || paramUserName == lastName)
                {
                    _newUsers.Add(user);
                }
            }
            ViewBag.TotalNumberOfRecords = _newUsers.Count; //Using ".Count" is an easy way to use total count of list
            return View("SearchForm", _newUsers);
        }
        public ActionResult UserProfileGallery()
        {
            UserRepository DBuser = new UserRepository();
            List<User> userList = DBuser.GetAllUsers();
            return View(userList);
        }
    }
}
