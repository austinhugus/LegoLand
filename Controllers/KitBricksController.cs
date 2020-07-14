using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Legoland.Models;
using Legoland.Services;

namespace Legoland.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KitBricksController : ControllerBase
    {
        private readonly KitBricksService _service;
        public KitBricksController(KitBricksService service)
        {
            _service = service;
        }
        //GET
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<KitBrick>> Get(int id)
        {
            try
            {
                return Ok(_service.Get(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        //POST
        [HttpPost]
        public ActionResult<DTOKitBrick> Post([FromBody] DTOKitBrick newDTOKitBrick)
        {
            try
            {
                return Ok(_service.Create(newDTOKitBrick));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //DEL
        [HttpDelete("{id}")]
        public ActionResult<DTOKitBrick> Delete(int id)
        {
            try
            {
                return Ok(_service.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}