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

        public List<Car> GetCars()
        {
            List<Car> cars = db.Cars.ToList();

            return cars;
        }

        public List<Car> GetCarsByMake(string make)
        {
            List<Car> cars = (from c in db.Cars
                              where c.Make.Contains(make)
                              select c).ToList();
            return cars;
        }

        public List<Car> GetCarsByModel(string model)
        {
            List<Car> cars = (from c in db.Cars
                              where c.Model.Contains(model)
                              select c).ToList();
            return cars;
        }

        public List<Car> GetCarsByYear(int? year)
        {
            List<Car> cars = (from c in db.Cars
                              where c.Year == year
                              select c).ToList();
            return cars;
        }

        public List<Car> GetCarsByColor(string color)
        {
            List<Car> cars = (from c in db.Cars
                              where c.Color.Contains(color)
                              select c).ToList();
            return cars;
        }

        

    }
}
