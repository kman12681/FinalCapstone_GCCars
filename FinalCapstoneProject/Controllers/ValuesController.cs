using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FinalCapstoneProject.Models;

namespace FinalCapstoneProject.Controllers
{
    public class ValuesController : ApiController
    {

        CarsEntities db = new CarsEntities();

        [HttpGet]
        public List<Car> GetCars()
        {
            List<Car> cars = db.Cars.ToList();

            return cars;
        }

        [HttpGet]
        public List<Car> GetCarsByMake(string make)
        {
            List<Car> cars = (from c in db.Cars
                              where c.Make.Contains(make)
                              select c).ToList();
            return cars;
        }

        [HttpGet]
        public List<Car> GetCarsByModel(string model)
        {
            List<Car> cars = (from c in db.Cars
                              where c.Model.Contains(model)
                              select c).ToList();
            return cars;
        }

        [HttpGet]
        public List<Car> GetCarsByYear(int? year)
        {
            List<Car> cars = (from c in db.Cars
                              where c.Year == year
                              select c).ToList();
            return cars;
        }

        [HttpGet]
        public List<Car> GetCarsByColor(string color)
        {
            List<Car> cars = (from c in db.Cars
                              where c.Color.Contains(color)
                              select c).ToList();
            return cars;
        }

        [HttpGet]
        public List<Car> GetCarsSearch (string make = "", string model = "", int? year = 0, string color = "")
        {           
            List<Car> cars = db.Cars.ToList();          

            if (make != null && make != "")
            {
                cars = cars.Where(c => c.Make.ToLower() == make.ToLower()).ToList();
            }
            if (model != null && model != "")
            {
                cars = cars.Where(c => c.Model.ToLower() == model.ToLower()).ToList(); 
            }
            if (year.ToString() != null && year.ToString() != "")
            {
                cars = cars.Where(c => c.Year.Equals(year)).ToList();
            }
            if (!string.IsNullOrEmpty(color))
            {
                cars = cars.Where(c => c.Color.ToLower() == color.ToLower()).ToList();
            }
            return cars;
        }

    }
}
