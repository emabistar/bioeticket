﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bioticket.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bioticket.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _context;

        public MoviesController(AppDbContext context)
        {
            _context = context;
        }


        public async Task <IActionResult> Index()
        {
            var allMovies = await _context.Movies.Include(m=>m.Cinema).OrderBy(m=>m.Name).ToListAsync();
            return View(allMovies);
        }
    }
}
