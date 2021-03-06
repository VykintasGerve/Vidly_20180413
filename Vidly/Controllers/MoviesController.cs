﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer{ Name = "Customer 1" },
                new Customer{ Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
            //return Content("Hello world!");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });

            //ViewData["Movie"] = movie;
            //ViewBag.Movie = movie;
            //return View();
        }

        public ActionResult Edit (int id)
        {
            return Content("id=" + id);
        }
        /*
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue) pageIndex = 1;
            if (string.IsNullOrWhiteSpace(sortBy)) sortBy = "Name";
            return Content(String.Format("pageIndex={0}, sortBy={1}",pageIndex, sortBy));
        }
        */
        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year +"/" + month);
        }

        public ActionResult Index()
        {

            var movieList = new List<Movie>
            {
                new Movie{ Id = 1, Name = "Shrek!" },
                new Movie{ Id = 2, Name = "Wall-e" },
            };
            var movies = new MoviesViewModel()
            {
                Id = 1,
                Name = "Movies",
                Movies = movieList

            };
            return View(movies);
        }

        public ActionResult Details(int? Id)
        {
            var movieList = new List<Movie>
            {
                new Movie{ Id = 1, Name = "Shrek!" },
                new Movie{ Id = 2, Name = "Wall-e" },
            };

            if (!Id.HasValue)
            {
                return HttpNotFound();
            }
            else
            {
                var customer = movieList.Find(c => c.Id == Id);
                if (customer == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(customer);
                }

            }
        }
    }
}