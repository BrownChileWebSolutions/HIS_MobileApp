using GoogleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GoogleAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        //public IEnumerable<user> Get()
        //{
        //    return new List<user>()
        //    {
        //        new user { name  = "Maulik", surname = "Maulik1!" },
        //        new user { name = "Maddy", surname = "Maddy1!" }
        //    };

        //}
        //// GET api/values/5
        //public user Get(int id)
        //{
        //    if (id == 1)
        //    {
        //        return new user { name = "Maulik", surname = "Maulik" };
        //    }
        //    else
        //        if (id == 2)
        //        {
        //            return new user { name = "Maddy", surname = "Maddy" };
        //        }
        //    return null;
        //}
        // POST api/values
         [HttpPost]
        public string IsAuthorized(User objuser)
        {
            return "true";
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}