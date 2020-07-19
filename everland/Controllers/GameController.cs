﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using everland.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace everland.Controllers
{
    public class GameController : Controller
    {
        // GET: GameController
        public ActionResult Index()
        {
            //return View();

            var w = new World(30, 30);

            

            ViewBag.HexImage = w.Draw(500, 500);
            return View();

            
        }

        [HttpPost]
        public ActionResult Index(int width, int height)
        {
            var w = new World(width, height);



            ViewBag.HexImage = w.Draw(500, 500);
            return View();
        }


        // GET: GameController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GameController/Create
        public ActionResult New()
        {
            return View();


        }

        // POST: GameController/Create
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

     
    }
}
