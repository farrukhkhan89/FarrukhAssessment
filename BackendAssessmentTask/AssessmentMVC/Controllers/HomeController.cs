using AssessmentMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace AssessmentMVC.Controllers
{
    public class HomeController : Controller
    {
        string practitionerJSON = @"C:\Users\farru\source\repos\BackendAssessmentTask\AssessmentMVC\JsonData\practitioners.json";
        string appointments = @"C:\Users\farru\source\repos\BackendAssessmentTask\AssessmentMVC\JsonData\appointments.json";


        // var person = JsonSerializer.Deserialize<Person>(text);
        public ActionResult Index()
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            var format = "M/dd/yyyy";
            var result = DateTime.ParseExact("1/28/2020", format, provider);

            string practText = System.IO.File.ReadAllText(practitionerJSON);
            var p = JsonConvert.DeserializeObject<List<Practitioner>>(practText);

            string appointmentText = System.IO.File.ReadAllText(appointments);
            var a = JsonConvert.DeserializeObject<List<Appointment>>(appointmentText);

            
            List<Appointment> sortedAppointments = a.OrderBy(o => o.practitioner_id).Where(x=>x.date >= DateTime.ParseExact("1/28/2020", format, provider) && x.date <= DateTime.ParseExact("3/20/2020", format, provider)).ToList(); 

            List<PractitionerModel> list = new List<PractitionerModel>();

            var group= sortedAppointments.GroupBy(d => d.practitioner_id)
            .Select(
        g => new PractitionerModel() 
        {

            //Key = g.Key,
            Cost = g.Sum(s => s.cost),
            Revenue = g.Sum(s => s.revenue),
            Name = p.FirstOrDefault(x => x.id == g.First().practitioner_id).name,
           // PractitionerName = p.FirstOrDefault(x => x.id== g.First().practitioner_id).name,
            PractitionerId = g.First().practitioner_id,
            //DOB=g.First().date
            //Category = g.First().Category
        }).ToList();

            foreach (var item in a)
            {
                
                
            }


            return View(group);

        }
        public ActionResult DateRange()
        {
            ViewBag.minDate = new DateTime(2017, 01, 05);
            ViewBag.maxDate = new DateTime(2017, 12, 20);
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult GetPractitionerAppointments()
        {
            PractitionerModel model = new PractitionerModel();
            // var oMycustomclassname = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(jsonString);

            return View();
        }
    }
}