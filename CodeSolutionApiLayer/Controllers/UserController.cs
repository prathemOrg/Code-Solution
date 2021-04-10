using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CodeSolutionDataLayer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;




namespace CodeSolutionApiLayer.Controllers
{
    
    public class UserController : ApiController
    {
       private DataManager dataManager = new DataManager();
        
        [HttpGet]
        [Route("api/users")]
        public string GetAllUsers()
        {
            var userList = dataManager.GetAllUsers();
            var user1 = (from user2 in userList select new { user2.UserId, user2.UserFirstName, user2.UserLastName, user2.UserEmail, user2.UserRoleId }).ToList();
            var jobj = JsonConvert.SerializeObject(user1);


            return jobj;
        }

        [HttpGet]
        [Route("api/user")]
        public User GetUserByID(int id)
        {
            return dataManager.GetUserByID(id);
            
        }
        [HttpPost]
        [Route("api/adduser")]
        public HttpResponseMessage PostUser([FromBody]string user)
        {
            try
            {
                JObject jsondata = JObject.Parse(user);

                var u = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsondata.ToString());
                User us = new User
                {
                    UserFirstName = u["UserFirstName"],
                    UserLastName = u["UserLastName"],
                    UserEmail = u["UserEmail"],
                    UserPassword = u["UserPassword"],
                };
                
                dataManager.AddUser(us);

                var message = Request.CreateResponse(HttpStatusCode.Created, user);
                message.Headers.Location = new Uri(Request.RequestUri + user.ToString());
                return message;
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }


        }


    }
}
