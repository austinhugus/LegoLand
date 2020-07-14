using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Legoland.Models;
using Legoland.Services;

namespace Legoland.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BricksController : ControllerBase
    {
        private readonly BricksService _service;
        public BricksController(BricksService service)
        {
            _service = service;
        }

        //GET
        [HttpGet]
        public ActionResult<IEnumerable<Brick>> Get()
        {
            try
            {
                return Ok(_service.Get());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //GETBYID
        [HttpGet("{Id}")]
        public ActionResult<Brick> Get(int Id)
        {
            try
            {
                return Ok(_service.Get(Id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //POST
        [HttpPost]
        public ActionResult<Brick> Post([FromBody] Brick newBrick)
        {
            try
            {
                return Ok(_service.Create(newBrick));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Brick> Edit([FromBody] Brick newBrick, int id)
        {
            try
            {
                newBrick.Id = id;
                return Ok(_service.Edit(newBrick));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //DEL
        [HttpDelete("{id}")]
        public ActionResult<Brick> Delete(int id)
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