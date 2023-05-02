using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using carspi.EfCore;
using carspi.Model;

namespace carspi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarModelController : ControllerBase
    {
        private readonly DbHelper _db;
        public CarModelController(EF_DataContext eF_DataContext) {
            _db = new DbHelper(eF_DataContext);
        }
        // GET: api/<carApiController>
        [HttpGet]
        [Route("api/[controller]/GetCars")]
        public IActionResult Get() {
            ResponseType type = ResponseType.Success;
            try {
                IEnumerable < CarModel > data = _db.GetCars();
                if (!data.Any()) {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            } catch (Exception ex) {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
        // GET api/<carApiController>/5
        [HttpGet]
        [Route("api/[controller]/GetProductById/{id}")]
        public IActionResult Get(int id) {
            ResponseType type = ResponseType.Success;
            try {
                CarModel data = _db.GetCarById(id);
                if (data == null) {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            } catch (Exception ex) {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
        // POST api/<carApiController>
        [HttpPost]
        [Route("api/[controller]/SaveCar")]
        public IActionResult Post([FromBody] CarModel model) {
            try {
                ResponseType type = ResponseType.Success;
                _db.SaveCar(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            } catch (Exception ex) {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
        // PUT api/<carApiController>/5
        [HttpPut]
        [Route("api/[controller]/UpdateCar")]
        public IActionResult Put([FromBody] CarModel model) {
            try {
                ResponseType type = ResponseType.Success;
                _db.SaveCar(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            } catch (Exception ex) {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
        // DELETE api/<CarApiController>/5
        [HttpDelete]
        [Route("api/[controller]/DeleteCar/{id}")]
        public IActionResult Delete(int id) {
            try {
                ResponseType type = ResponseType.Success;
                _db.DeleteCar(id);
                return Ok(ResponseHandler.GetAppResponse(type, "Delete Successfully"));
            } catch (Exception ex) {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}