using JobBoard.EN.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobBoard.DAL
{
    public class JobEntityDAL
    {
        private JobBoardContext dbcontext;

        public JobEntityDAL(string nameConString)
        {
            dbcontext = new JobBoardContext(nameConString);
        }

        /// <summary>
        /// Insert JobEntity in database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public JobEntity Create(JobEntity entity)
        {
            dbcontext.Add(entity);
            dbcontext.SaveChanges();
            return entity;
        }

        /// <summary>
        /// Get JobEntity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JobEntity Get(int id)
        {
            var entity = dbcontext.JobEntity.Find(id);
            return entity;

        }

        /// <summary>
        /// Get List of JobEntity
        /// </summary>
        /// <returns></returns>
        public IEnumerable<JobEntity> GetAll()
        {
            var entity = dbcontext.JobEntity;
            return entity;
        }

        /// <summary>
        /// Delete JobEntity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JobEntity Delete(int id)
        {
            JobEntity jobEntity = Get(id);
            dbcontext.JobEntity.Attach(jobEntity);
            dbcontext.JobEntity.Remove(jobEntity);
            dbcontext.SaveChanges();
            return jobEntity;
        }
    }
}
