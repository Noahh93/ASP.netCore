using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices.JavaScript;
using WebApp.Models;
using WebApp.Models.AssignmentInternship;
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
        public ActionResult SearchForm(string searchWord)
        {
            UserRepository DBuser = new UserRepository();
            List<User> registeredUser = DBuser.SearchUserFirstLastNameEmail(searchWord);

            int totalNumberOfRecords = registeredUser.Count;
            ViewBag.TotalNumberOfRecords = totalNumberOfRecords;

            return View(registeredUser);
        }
        public ActionResult SearchUser(string searchWord) //This parameter comes from name="userName" in SearchForm
        {
            UserRepository DBuser = new UserRepository();
            List<User> registeredUser = DBuser.SearchUserFirstLastNameEmail(searchWord);


            return View("SearchForm", registeredUser);
        }
        public ActionResult RegisterUser()  //this is the form
        {
            CountryRepository DBcountry = new CountryRepository();
            List<Country> countries = DBcountry.GetCountries();

            ViewBag.countries = countries;

            return View(countries);
        }
        public ActionResult SavingUser(string firstname, string lastname, string email, string password, int countryid) //formsettings
        {
            UserRepository DBuser = new UserRepository();
            bool user1 = DBuser.SaveUser(firstname, lastname, email, password, countryid);
            ViewBag.Message = "User has been created";


            CountryRepository DBcountry = new CountryRepository();
            List<Country> countries = DBcountry.GetCountries();
            ViewBag.countries = countries;

            return View("RegisterUser", countries);



            //user = DBuser.GetUserByEmail(email);
            //if (user.Email != email)
            //{

            //}
            //else
            //{
            //    ViewBag.Message = "User already exists";
            //    return View("RegisterUser");
            //}
        }

















        //public ActionResult UserProfileGallery()
        //{
        //    UserRepository DBuser = new UserRepository();
        //    List<User> userList = DBuser.GetAllUsers();
        //    return View(userList);
        //}
        //public async Task<ActionResult>  DisplayUserProfile()
        //{   
        //    var client = new HttpClient();
        //    var response = await client.GetAsync("https://randomuser.me/api/?results=50");
        //    var content = await response.Content.ReadAsStringAsync();
        //    var data = JObject.Parse(content)["results"];
        //    List<UserProfile> userProfiles = new List<UserProfile>();
        //    foreach (var item in data)
        //    {
        //        UserProfile userProfile = new UserProfile();
        //        userProfile.Gender = item["gender"].ToString();
        //        userProfile.Email = item["email"].ToString();
        //        if (item["name"] != null)
        //        {
        //            var result = item["name"];
        //            userProfile.Name.Title = item["name"]?["title"]?.ToString();

        //            userProfile.Name.First = item["name"]["first"].ToString();
        //            userProfile.Name.Last = item["name"]["last"].ToString();
        //        }


        //        userProfiles.Add(userProfile);
        //    }
        //    return View(userProfiles);
        //}

    }
}
