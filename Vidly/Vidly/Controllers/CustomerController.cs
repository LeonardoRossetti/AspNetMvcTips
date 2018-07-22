using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        public RandomMovieViewModel Data()
        {

            var movie = new Movie { Name = "Saw" };
            var customers = new List<Customer>
            {
                new Customer{ Name = "Will Smith", Id=1},
                new Customer{ Name = "Mike Tayson", Id=2}
            };
            var viewModel = new RandomMovieViewModel
            {
                Customers = customers,
                Movie = movie
            };
            return viewModel;
        }
        // GET: Customer
        public ActionResult Index()
        {
           
            return View(Data());
        }

        public ActionResult Details(int id)
        {
            var customer = Data().Customers[id-1];

            return View(customer);
        }
    }
}