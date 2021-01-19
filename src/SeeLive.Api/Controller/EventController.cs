using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeeLive.Infrastructure;
using SeeLive.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace SeeLive.Api.Controller
{
    [Route("event")]
    public class EventController : ControllerBase
    {
        private readonly SeeLiveContext _context;

        public EventController(SeeLiveContext context)
        {
            _context = context;
        }

        // GET: EventController
        [HttpGet]
        [Route("get")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult Index()
        {
            var eventString = "{\"event\": {\"name\": 'New Event'}}";

            return Ok(eventString);
        }

        //// GET: EventController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: EventController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: EventController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: EventController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: EventController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: EventController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: EventController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
