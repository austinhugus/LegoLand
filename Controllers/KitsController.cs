using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Legoland.Models;
using Legoland.Services;

namespace Legoland.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KitsController : ControllerBase
    {
        private readonly KitsService _service;
        public KitsController(KitsService service)
        {
            _service = service;
        }

        //GET
        [HttpGet]
        public ActionResult<IEnumerable<Kit>> Get()
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
        [HttpGet("{tacoId}")]
        public ActionResult<Kit> Get(int tacoId)
        {
            try
            {
                return Ok(_service.Get(tacoId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //POST
        [HttpPost]
        public ActionResult<Kit> Post([FromBody] Kit newKit)
        {
            try
            {
                return Ok(_service.Create(newKit));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //DEL
        [HttpDelete("{id}")]
        public ActionResult<Kit> Delete(int id)
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
        //PUT
        [HttpPut("{id}")]
        public ActionResult<Kit> Edit([FromBody] Kit newKit, int id)
        {
            try
            {
                newKit.Id = id;
                return Ok(_service.Edit(newKit));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}