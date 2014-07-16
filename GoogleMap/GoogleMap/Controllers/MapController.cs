using GoogleMap.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoogleMap.Controllers
{
    public class MapController : Controller
    {
        //
        // GET: /Map/
     
        public ActionResult Index()
        {
            ViewBag.UserName =Convert.ToString(Session["UserName"]);
            return View();
        }
        public ActionResult Hotel(string Latitude, string Longitude)
        {
            List<Hotel> objHotelList = new List<Hotel>();
            Services.HotelService objHotelService = new Services.HotelService();
            objHotelList = objHotelService.GetHotelList(Latitude, Longitude);
            return Json(objHotelList, JsonRequestBehavior.AllowGet);
        }
    }
}
