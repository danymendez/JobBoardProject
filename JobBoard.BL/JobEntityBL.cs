using JobBoard.DAL;
using JobBoard.EN.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobBoard.BL
{
    public class JobEntityBL
    {
       private JobEntityDAL dal;
        public JobEntityBL(IConfiguration configuration){ 
               dal = new JobEntityDAL(configuration.GetConnectionString("JobBoardConn"));
            }

        /// <summary>
        /// Insert JobEntity in database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public JobEntity Create(JobEntity entity)
        {
            var jobEntity = dal.Create(entity);
            return jobEntity;
        }

        /// <summary>
        /// Get JobEntity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JobEntity Get(int id)
        {
            var jobEntity = dal.Get(id);
            return jobEntity;

        }

        /// <summary>
        /// Get List of JobEntity
        /// </summary>
        /// <returns></returns>
        public IEnumerable<JobEntity> GetAll()
        {
          var ListJobEntity = dal.GetAll();
            return ListJobEntity;
        }

        /// <summary>
        /// Delete JobEntity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JobEntity Delete(int id)
        {
            var job = dal.Delete(id);
            return job;
        }
    }
}
