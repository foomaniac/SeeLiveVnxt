﻿using Microsoft.AspNetCore.Mvc;
using System.Linq;
using SeeLive.Domain;

namespace SeeLive.Api.Controller
{
    [Route("Events")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly SeeLiveContext _context;

        public EventsController(SeeLiveContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var events = _context.Events.ToList();

            return Ok(events);
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
