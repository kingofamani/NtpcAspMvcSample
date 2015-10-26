using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using s01.Models;//(01-1)

namespace s01.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index(int? age)//03-1:加問號表示Nullable
        {
            //(01-2)
            User user = new User();
            user.UserID = 1;
            user.Name = "John";
            user.Age = age??0;//03-2:??判斷IS NULL

            return View(user);
        }

        //04:url get 傳物件
        public ActionResult Index2(User u)
        {
            User user = new User();
            user.UserID = u.UserID;
            user.Name = u.Name;
            user.Age = u.Age;

            return View("Index", user);//04:指定Index頁面，這樣就不用再做Index2頁面了
        }
    }
}