using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CodeSolutionDataLayer;
using Newtonsoft.Json;

namespace CodeSolutionApiLayer.Controllers
{
    
    public class UserController : ApiController
    {
       private DataManager dataManager = new DataManager();

        [HttpGet]
        [Route("users")]
        public List<string> GetAllUsers()
        {
            List<string> userList = new List<string>();
            foreach(User user in dataManager.GetAllUsers())
            {
                var userToJson = JsonConvert.SerializeObject(user);
                userList.Add(userToJson.ToString());
            }

            return userList;
        }
    }
}
