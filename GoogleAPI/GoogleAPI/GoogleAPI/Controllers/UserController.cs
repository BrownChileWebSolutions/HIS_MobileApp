using GoogleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GoogleAPI.Controllers
{
    public class UserController : ApiController
    {
        [HttpPost]        
        public HttpResponseMessage IsAuthorized(User objuser)
        {

            HttpResponseMessage responseMessage = new HttpResponseMessage();
     
            if (objuser.UserName == null)
            {
                responseMessage.ReasonPhrase = "Enter UserName.";
                responseMessage.StatusCode = HttpStatusCode.NotFound;                
            }
            else if (objuser.Password == null)
            {
                responseMessage.ReasonPhrase = "Enter Password.";
                responseMessage.StatusCode = HttpStatusCode.NotFound;                
            }
            else if (objuser.UserName != "abc" && objuser.Password != "abc")
            {
                responseMessage.StatusCode = HttpStatusCode.Unauthorized;                                
            }
            else
            {
                responseMessage.StatusCode = HttpStatusCode.Accepted;                                
            }
            return responseMessage;     
        }
    }
}
