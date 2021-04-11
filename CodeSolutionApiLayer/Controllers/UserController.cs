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
    [RoutePrefix("api/Users")]
    public class UserController : ApiController
    {
       private DataManager dataManager = new DataManager();
        
        [HttpGet]
        [Route("usersList")]
        public HttpResponseMessage GetAllUsers()
        
        {
            try
            {
                var userList = dataManager.GetAllUsers();
                if (userList != null)
                {
                    return Request.CreateResponse<List<User>>(HttpStatusCode.OK, userList);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Users not Found");
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
           
        }

        [HttpGet]
        [Route("userInfo/{id}")]
        public HttpResponseMessage GetUserByID(int id)
        {
            try 
            {
                
               var user = dataManager.GetUserByID(id);
                if (user != null)
                {
                    return Request.CreateResponse<User>(HttpStatusCode.OK, user);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User Not Found");
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            
            
        }
        [HttpPost]
        [Route("addUser")]
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

        [HttpDelete]
        [Route("deleteUser/{id}")]

        public IHttpActionResult DeleteUSer(int ID)
        {
            if (ID == 0)
                return BadRequest();
            try
            {
                if (dataManager.GetUserByID(ID)!=null)
                {
                    dataManager.DeleteUser(ID);
                    return Ok("Deleted User Successfully");
                }
                else return Content(HttpStatusCode.NotFound, "User Not Found");
            }catch(Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}
