using HIS_MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HIS_MobileApp.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult IsAuthorized(User objuser)
        {
            string strmsg = string.Empty;
            if (objuser.UserName == null)
            {
                strmsg = "Enter UserName.";
            }
            else if (objuser.Password == null)
            {
                strmsg = "Enter Password.";
            }
            else
            {
                Services.UserService objUserService = new Services.UserService();
                int UserID = objUserService.IsAuthorized(objuser);
                if (UserID == 0)
                {
                    strmsg = "Enter Valid UserName and Password.";
                }
                else
                {
                    Session["UserName"] = objuser.UserName;
                    strmsg = "Success";
                }
            }           
            return Json(new { result = strmsg});
        }
    }
}
