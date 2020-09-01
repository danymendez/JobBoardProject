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
        public IEnumerable<JobEntity> Get()
        {  
           var ListEntity = jobEntityBL.GetAll();
            return ListEntity;
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
        public JobEntity Post(JobEntity entity)
        {
               var InsertedEntity = jobEntityBL.Create(entity);
            return InsertedEntity;
        }

        // PUT api/<JobEntityController>/5
        [HttpPut]
        public JobEntity Put(JobEntity entity)
        {
             var updatedEntity  = jobEntityBL.Update(entity);
            return updatedEntity;
        }

        // DELETE api/<JobEntityController>/5
        [HttpDelete("{id}")]
        public JobEntity Delete(int id)
        {
            var updatedEntity  = jobEntityBL.Delete(id);
            return updatedEntity;
        }
    }
}
