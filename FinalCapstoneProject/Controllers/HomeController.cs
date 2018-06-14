using FinalCapstoneProject.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace FinalCapstoneProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult GetCars()
        {
            HttpWebRequest WR = WebRequest.CreateHttp("http://localhost:59832/api/Values/GetCars");
            WR.UserAgent = ".NET Framework Test Client";

            HttpWebResponse Response;

            try
            {
                Response = (HttpWebResponse)WR.GetResponse();
            }
            catch (WebException e)
            {
                ViewBag.Error = "Exception";
                ViewBag.ErrorDescription = e.Message;
                return View();
            }

            if (Response.StatusCode != HttpStatusCode.OK)
            {
                ViewBag.Error = Response.StatusCode;
                ViewBag.ErrorDescription = Response.StatusDescription;
                return View();
            }

            StreamReader reader = new StreamReader(Response.GetResponseStream());
            string CarData = reader.ReadToEnd();

            try
            {
                JArray JsonData = JArray.Parse(CarData);
                ViewBag.Cars = JsonData;


            }
            catch (Exception e)
            {
                ViewBag.Error = "JSON Issue";
                ViewBag.ErrorDescription = e.Message;
                return View();
            }

            return View();
        }

        
        //public ActionResult GetCarsByMake(string make)
        //{
            

        //        HttpWebRequest WR = WebRequest.CreateHttp($"http://localhost:59832/api/Values/GetCarsByMake?make={make}");
        //        WR.UserAgent = ".NET Framework Test Client";

        //        HttpWebResponse Response;

        //        try
        //        {
        //            Response = (HttpWebResponse)WR.GetResponse();
        //        }
        //        catch (WebException e)
        //        {
        //            ViewBag.Error = "Exception";
        //            ViewBag.ErrorDescription = e.Message;
        //            return View();
        //        }

        //        if (Response.StatusCode != HttpStatusCode.OK)
        //        {
        //            ViewBag.Error = Response.StatusCode;
        //            ViewBag.ErrorDescription = Response.StatusDescription;
        //            return View();
        //        }

        //        StreamReader reader = new StreamReader(Response.GetResponseStream());
        //        string CarData = reader.ReadToEnd();

        //        try
        //        {

        //            if (CarData == "[]")
        //            {
        //                ViewBag.Message = "Car does not exist in the database.";
        //                return View("Error");
        //            }
        //            else
        //            { 
        //            JArray JsonData = JArray.Parse(CarData);

        //            ViewBag.Cars = JsonData;

        //            }

        //        }
        //        catch (Exception e)
        //        {
        //            ViewBag.Error = "JSON Issue";
        //            ViewBag.ErrorDescription = e.Message;
        //            return View();
        //        }


        //    return View("GetCars");
        //}

        //public ActionResult GetCarsByModel(string model)
        //{


        //    HttpWebRequest WR = WebRequest.CreateHttp($"http://localhost:59832/api/Values/GetCarsByModel?model={model}");
        //    WR.UserAgent = ".NET Framework Test Client";

        //    HttpWebResponse Response;

        //    try
        //    {
        //        Response = (HttpWebResponse)WR.GetResponse();
        //    }
        //    catch (WebException e)
        //    {
        //        ViewBag.Error = "Exception";
        //        ViewBag.ErrorDescription = e.Message;
        //        return View();
        //    }

        //    if (Response.StatusCode != HttpStatusCode.OK)
        //    {
        //        ViewBag.Error = Response.StatusCode;
        //        ViewBag.ErrorDescription = Response.StatusDescription;
        //        return View();
        //    }

        //    StreamReader reader = new StreamReader(Response.GetResponseStream());
        //    string CarData = reader.ReadToEnd();

        //    try
        //    {

        //        if (CarData == "[]")
        //        {
        //            ViewBag.Message = "That car model does not exist in the database.";
        //            return View("Error");
        //        }
        //        else
        //        {
        //            JArray JsonData = JArray.Parse(CarData);

        //            ViewBag.Cars = JsonData;

        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        ViewBag.Error = "JSON Issue";
        //        ViewBag.ErrorDescription = e.Message;
        //        return View();
        //    }


        //    return View("GetCars");
        //}

        //public ActionResult GetCarsByYear(int? year)
        //{


        //    HttpWebRequest WR = WebRequest.CreateHttp($"http://localhost:59832/api/Values/GetCarsByYear?year={year}");
        //    WR.UserAgent = ".NET Framework Test Client";

        //    HttpWebResponse Response;

        //    try
        //    {
        //        Response = (HttpWebResponse)WR.GetResponse();
        //    }
        //    catch (WebException e)
        //    {
        //        ViewBag.Error = "Exception";
        //        ViewBag.ErrorDescription = e.Message;
        //        return View();
        //    }

        //    if (Response.StatusCode != HttpStatusCode.OK)
        //    {
        //        ViewBag.Error = Response.StatusCode;
        //        ViewBag.ErrorDescription = Response.StatusDescription;
        //        return View();
        //    }

        //    StreamReader reader = new StreamReader(Response.GetResponseStream());
        //    string CarData = reader.ReadToEnd();

        //    try
        //    {

        //        if (CarData == "[]")
        //        {
        //            ViewBag.Message = "No cars from that year are available.";
        //            return View("Error");
        //        }
        //        else
        //        {
        //            JArray JsonData = JArray.Parse(CarData);

        //            ViewBag.Cars = JsonData;

        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        ViewBag.Error = "JSON Issue";
        //        ViewBag.ErrorDescription = e.Message;
        //        return View();
        //    }


        //    return View("GetCars");
        //}


        //public ActionResult GetCarsByColor(string color)
        //{


        //    HttpWebRequest WR = WebRequest.CreateHttp($"http://localhost:59832/api/Values/GetCarsByColor?color={color}");
        //    WR.UserAgent = ".NET Framework Test Client";

        //    HttpWebResponse Response;

        //    try
        //    {
        //        Response = (HttpWebResponse)WR.GetResponse();
        //    }
        //    catch (WebException e)
        //    {
        //        ViewBag.Error = "Exception";
        //        ViewBag.ErrorDescription = e.Message;
        //        return View();
        //    }

        //    if (Response.StatusCode != HttpStatusCode.OK)
        //    {
        //        ViewBag.Error = Response.StatusCode;
        //        ViewBag.ErrorDescription = Response.StatusDescription;
        //        return View();
        //    }

        //    StreamReader reader = new StreamReader(Response.GetResponseStream());
        //    string CarData = reader.ReadToEnd();

        //    try
        //    {

        //        if (CarData == "[]")
        //        {
        //            ViewBag.Message = "Color is not available.";
        //            return View("Error");
        //        }
        //        else
        //        {
        //            JArray JsonData = JArray.Parse(CarData);

        //            ViewBag.Cars = JsonData;

        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        ViewBag.Error = "JSON Issue";
        //        ViewBag.ErrorDescription = e.Message;
        //        return View();
        //    }


        //    return View("GetCars");
        //}

            // This action returns all search fields, so above actions are commented out

        public ActionResult GetCarsSearch(string make, string model, int? year, string color)
        {


            HttpWebRequest WR = WebRequest.CreateHttp($"http://localhost:59832/api/Values/GetCarsSearch?make={make}&model={model}&year={year}&color={color}");
            WR.UserAgent = ".NET Framework Test Client";

            HttpWebResponse Response;

            try
            {
                Response = (HttpWebResponse)WR.GetResponse();
            }
            catch (WebException e)
            {
                ViewBag.Error = "Exception";
                ViewBag.ErrorDescription = e.Message;
                return View("GetCars");
            }

            if (Response.StatusCode != HttpStatusCode.OK)
            {
                ViewBag.Error = Response.StatusCode;
                ViewBag.ErrorDescription = Response.StatusDescription;
                return View("GetCars");
            }

            StreamReader reader = new StreamReader(Response.GetResponseStream());
            string CarData = reader.ReadToEnd();

            try
            {

                if (CarData == "[]")
                {
                    ViewBag.Message = "Car does not exist in the database.";
                    return View("Error");
                }
                else
                {
                    JArray JsonData = JArray.Parse(CarData);

                    ViewBag.Cars = JsonData;

                }

            }
            catch (Exception e)
            {
                ViewBag.Error = "JSON Issue";
                ViewBag.ErrorDescription = e.Message;
                return View("GetCars");
            }


            return View("GetCars");
        }


    }
}
