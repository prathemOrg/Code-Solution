using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using CodeSolution;
using CodeSolutionDataLayer;

namespace CodeSolutionApiLayer.Controllers
{
    [RoutePrefix("api/Problems")]
    public class ProblemController : ApiController
    {
        [HttpPost]
        [Route("addProblem")]
        public IHttpActionResult PostProblem([FromBody] string problem)
        {
            try
            {
                JObject jsondata = JObject.Parse(problem);

                var u = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsondata.ToString());
                Problem p = new Problem
                {
                    ProblemDesc = u["ProblemDesc"],
                    ProblemAsked = DateTime.Now,
                    ProblemStatus = "Not Completed",
                    ProblemViewed = 0,
                    UserId = Convert.ToInt32(u["UserId"])
                };
                DataManager dm = new DataManager();
                dm.AddProblem(p);

                return Ok("Problem Successfully Posted");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpGet]
        [Route("problemsList")]
        public HttpResponseMessage GetAllProblems()
        {
            try
            {
                DataManager dm = new DataManager();
                var problemList = dm.GetAllProblems();
                if (problemList != null)
                {
                    var obj = JsonConvert.SerializeObject(problemList, Formatting.Indented,
                    new JsonSerializerSettings()
                    {
                         ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    }
                    );
                    return Request.CreateResponse<string>(HttpStatusCode.OK, obj);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Users not Found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}
