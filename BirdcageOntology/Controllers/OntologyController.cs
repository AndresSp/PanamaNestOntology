using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities.Model;

namespace WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Ontology")]
    public class OntologyController : Controller
    {
       /* [Route("GetOrders")]
        [HttpPost]
        public JsonResult GetOrders([FromBody] EntityFilter entityFilter)
        {
            ResultResponseModel result = new ResultResponseModel();
            //call ontology logic
            var entityList = new List<Entity>();
            entityList.Add(new Entity
            {
                uri = "MyOntology.com/Mollusca",
                resourceName = "Mollusca",
                childNumber = 5
            });
            entityList.Add(new Entity
            {
                uri = "MyOntology.com/Aveary",
                resourceName = "Aveary",
                childNumber = 17
            });
            result.data = entityList;
            result.error = new { Code = 200, Info = "OK" };
            return Json(result);
        } */
    }
}