using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities.Model;
using FusekiConnection;

namespace WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Ontology")]
    public class OntologyController : Controller
    {
        #region Maestros
        [Route("getorders")]
        [HttpGet]
        public JsonResult GetOrders()
        {
            ResultResponseModel response = new ResultResponseModel();
            try
            {
                SelectQueries query = new SelectQueries();
                var result = query.SelectOrders();

                response.data = result;
                response.error = new Error(200, "OK");
            }
            catch (Exception ex)
            {
                response.error = new Error(500, ex.Message);
            }
            return Json(response);
        }

        [Route("getfamilies")]
        [HttpGet]
        public JsonResult GetFamilies()
        {
            ResultResponseModel response = new ResultResponseModel();
            try
            {
                SelectQueries query = new SelectQueries();
                var result = query.SelectFamilies();

                response.data = result;
                response.error = new Error(200, "OK");
            }
            catch (Exception ex)
            {
                response.error = new Error(500, ex.Message);
            }
            return Json(response);
        }

        [Route("getgenus")]
        [HttpGet]
        public JsonResult GetGenus()
        {
            ResultResponseModel response = new ResultResponseModel();
            try
            {
                SelectQueries query = new SelectQueries();
                var result = query.SelectGenuses();

                response.data = result;
                response.error = new Error(200, "OK");
            }
            catch (Exception ex)
            {
                response.error = new Error(500, ex.Message);
            }
            return Json(response);
        }

        [Route("getspecies")]
        [HttpGet]
        public JsonResult GetSpecies()
        {
            ResultResponseModel response = new ResultResponseModel();
            try
            {
                SelectQueries query = new SelectQueries();
                var result = query.SelectGenuses();

                response.data = result;
                response.error = new Error(200, "OK");
            }
            catch (Exception ex)
            {
                response.error = new Error(500, ex.Message);
            }
            return Json(response);
        }

        [Route("getphylum")]
        [HttpGet]
        public JsonResult GetPhylum()
        {
            ResultResponseModel response = new ResultResponseModel();
            try
            {
                SelectQueries query = new SelectQueries();
                var result = query.SelectPhylums();

                response.data = result;
                response.error = new Error(200, "OK");
            }
            catch (Exception ex)
            {
                response.error = new Error(500, ex.Message);
            }
            return Json(response);
        }

        [Route("getbirds")]
        [HttpGet]
        public JsonResult GetBirds()
        {
            ResultResponseModel response = new ResultResponseModel();
            try
            {
                SelectQueries query = new SelectQueries();
                var result = query.SelectBirds();

                response.data = result;
                response.error = new Error(200, "OK");
            }
            catch (Exception ex)
            {
                response.error = new Error(500, ex.Message);
            }
            return Json(response);
        }

        [Route("gethabitats")]
        [HttpGet]
        public JsonResult GetHabitats()
        {
            ResultResponseModel response = new ResultResponseModel();
            try
            {
                SelectQueries query = new SelectQueries();
                var result = query.SelectHabitats();

                response.data = result;
                response.error = new Error(200, "OK");
            }
            catch (Exception ex)
            {
                response.error = new Error(500, ex.Message);
            }
            return Json(response);
        }


        [Route("getregions")]
        [HttpGet]
        public JsonResult GetRegions()
        {
            ResultResponseModel response = new ResultResponseModel();
            try
            {
                SelectQueries query = new SelectQueries();
                var result = query.SelectRegions();

                response.data = result;
                response.error = new Error(200, "OK");
            }
            catch (Exception ex)
            {
                response.error = new Error(500, ex.Message);
            }
            return Json(response);
        }

        [Route("gethabitatregion")]
        [HttpGet]
        public JsonResult GetHabitatRegion()
        {
            ResultResponseModel response = new ResultResponseModel();
            try
            {
                SelectQueries query = new SelectQueries();
                var region = query.SelectRegions();
                var habitat = query.SelectHabitats();

                response.data = new { region, habitat };
                response.error = new Error(200, "OK");
            }
            catch (Exception ex)
            {
                response.error = new Error(500, ex.Message);
            }
            return Json(response);
        }
        #endregion

        #region Filtros
        [Route("filterbirdbytax")]
        [HttpPost]
        public JsonResult FilterBirdByTax([FromBody] Bird bird)
        {
            ResultResponseModel response = new ResultResponseModel();
            try
            {
                SelectQueries query = new SelectQueries();
                var result = query.FilterBirdTaxon(bird);

                response.data = result;
                response.error = new Error(200, "OK");
            }
            catch(Exception ex)
            {
                response.error = new Error(500, ex.Message);
            }

            return Json(response);
        }

        [Route("filterbirdbyloc")]
        [HttpPost]
        public JsonResult FilterBirdByLoc([FromBody] Bird bird)
        {
            ResultResponseModel response = new ResultResponseModel();
            try
            {
                SelectQueries query = new SelectQueries();
                var result = query.FilterBirdLoc(bird);

                response.data = result;
                response.error = new Error(200, "OK");
            }
            catch (Exception ex)
            {
                response.error = new Error(500, ex.Message);
            }

            return Json(response);
        }
        #endregion

        [Route("createbird")]
        [HttpPost]
        public JsonResult CreateBird([FromBody] Bird bird)
        {
            ResultResponseModel response = new ResultResponseModel();
            try
            {
                response.error = new Error(200, "OK");
            }
            catch(Exception ex)
            {
                response.error = new Error(500, ex.Message);
            }
            return Json(response);
        }
    }
}