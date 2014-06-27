using GoogleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GoogleAPI.Controllers
{
    public class MapController : ApiController
    {
        public IEnumerable<User> Get()
        {
            return new List<User> {
                new User {UserName="Maulik", Password="Maulik1!"},
                new User {UserName="Ramesh", Password="Ramesh1!"},
                new User {UserName="Mountu", Password="Mountu1!"}
            };
        }
    }
}
