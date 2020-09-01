using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobBoard.EN.Models;
using JobBoardWebApp.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace JobBoardWebApp.Controllers
{
    public class JobEntityController : Controller
    {
        private HelperServiceApi helperApi;
        private string UrlJobEntity = "JobEntity";

        public JobEntityController(IOptions<UriHelpers> configuration)
        {
        
            helperApi = new HelperServiceApi(configuration.Value);

        }

        // GET: JobEntityController
        public async Task<ActionResult> Index()
        {   var list =await helperApi.GetAll<JobEntity>("UrlJobEntity");
            return View(list);
        }

        // GET: JobEntityController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var entity =await helperApi.Get<JobEntity>($"{UrlJobEntity}/",id);
            return View(entity);
        }

        // GET: JobEntityController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobEntityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(JobEntity jobEntity)
        {
            try
            {
               var entity = await helperApi.Post(UrlJobEntity,jobEntity );
               
                if (entity.JobId == 0) {
                    return BadRequest();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: JobEntityController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
             var entity =await helperApi.Get<JobEntity>($"{UrlJobEntity}/",id);
            return View(entity);
        }

        // POST: JobEntityController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(JobEntity jobEntity)
        {
            try
            {
                var entity = await helperApi.Put(UrlJobEntity, jobEntity);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: JobEntityController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var entity =await helperApi.Get<JobEntity>($"{UrlJobEntity}/",id);
            return View(entity);
           
        }

        // POST: JobEntityController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                 var entity =await helperApi.Delete<JobEntity>($"{UrlJobEntity}/",id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
