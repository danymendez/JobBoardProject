using JobBoard.EN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        /// Update JobEntity in database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public JobEntity Update(JobEntity entity)
        {
            var entityToModified = dbcontext.JobEntity.First(c=>c.JobId==entity.JobId); 
            entityToModified.Job = entity.Job;
            entityToModified.JobTitle = entity.JobTitle;
            entityToModified.Description = entity.Description;
            entityToModified.CreatedAt=entity.CreatedAt;
            entityToModified.ExpiresAt = entity.ExpiresAt;
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
            var entity = dbcontext.JobEntity.First(c=>c.JobId==id)??new JobEntity();
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
            if(jobEntity.JobId!=0){
            dbcontext.JobEntity.Attach(jobEntity);
            dbcontext.JobEntity.Remove(jobEntity);
            dbcontext.SaveChanges();
            }
            return jobEntity;
        }
    }
}
