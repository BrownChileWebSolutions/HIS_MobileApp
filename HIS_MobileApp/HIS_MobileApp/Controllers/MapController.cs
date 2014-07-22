using HIS_MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HIS_MobileApp.Controllers
{
    public class MapController : Controller
    {
        //
        // GET: /Map/     
        public ActionResult Index()
        {            
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
