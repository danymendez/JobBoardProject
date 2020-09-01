using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardWebApp.Controllers
{
    public class JobEntityController : Controller
    {
        // GET: JobEntityController
        public ActionResult Index()
        {
            return View();
        }

        // GET: JobEntityController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: JobEntityController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobEntityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: JobEntityController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: JobEntityController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: JobEntityController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: JobEntityController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
