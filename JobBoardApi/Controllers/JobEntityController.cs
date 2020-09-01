using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobBoard.BL;
using JobBoard.EN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobBoardApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobEntityController : ControllerBase
    {
        private JobEntityBL jobEntityBL;
        public JobEntityController(IConfiguration configuration){ 
                jobEntityBL = new JobEntityBL(configuration);
            }

        // GET: api/<JobEntityController>
        [HttpGet]
        public IEnumerable<string> Get()
        {  
            return new string[] { "value1", "value2" };
        }

        // GET api/<JobEntityController>/5
        [HttpGet("{id}")]
        public JobEntity Get(int id)
        {
            var entity = jobEntityBL.Get(id);
            return entity;
        }

        // POST api/<JobEntityController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<JobEntityController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<JobEntityController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
