using AssessmentMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class PractitionerController : Controller
    {
        string practitionerJSON = @"C:\Users\farru\source\repos\BackendAssessmentTask\AssessmentMVC\JsonData\practitioners.json";
        string appointments = @"C:\Users\farru\source\repos\BackendAssessmentTask\AssessmentMVC\JsonData\appointments.json";

        string startDate = "1/28/2020";
        string endDate = "3/20/2020";

       
       
        // GET: Practitioner
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Practitioner()
        {
            return View();
        }

        public ActionResult PractitionerList()
        {
            var format = "M/dd/yyyy";
            CultureInfo provider = CultureInfo.InvariantCulture;
            var result = DateTime.ParseExact("1/28/2020", format, provider);


            string practText = System.IO.File.ReadAllText(practitionerJSON);
            var p = JsonConvert.DeserializeObject<List<Practitioner>>(practText);

            string appointmentText = System.IO.File.ReadAllText(appointments);
            var a = JsonConvert.DeserializeObject<List<Appointment>>(appointmentText);



            List<Appointment> sortedAppointments = a.OrderBy(o => o.practitioner_id).Where(x => x.date >= DateTime.ParseExact(startDate, format, provider) && x.date <= DateTime.ParseExact(endDate, format, provider)).ToList();

            List<PractitionerModel> list = new List<PractitionerModel>();

            var group = sortedAppointments.GroupBy(d => d.practitioner_id)
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
            return View(group);
        }

        [HttpPost]
        public ActionResult PractitionerList(DateTime DOB)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            var format = "M/dd/yyyy";
            var result = DateTime.ParseExact("1/28/2020", format, provider);

            string practText = System.IO.File.ReadAllText(practitionerJSON);
            var p = JsonConvert.DeserializeObject<List<Practitioner>>(practText);

            string appointmentText = System.IO.File.ReadAllText(appointments);
            var a = JsonConvert.DeserializeObject<List<Appointment>>(appointmentText);


            List<Appointment> sortedAppointments = a.OrderBy(o => o.practitioner_id).Where(x => x.date >= DateTime.ParseExact("1/28/2020", format, provider) && x.date <= DateTime.ParseExact("3/20/2020", format, provider)).ToList();

            List<PractitionerModel> list = new List<PractitionerModel>();

            var group = sortedAppointments.GroupBy(d => d.practitioner_id)
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

            PractitionerVM vm = new PractitionerVM();
            vm.prModel = group;


            return View(vm);
        }

        public ActionResult AppointmentList(int practitionerId, string name)
        {
            var format = "M/dd/yyyy";
            CultureInfo provider = CultureInfo.InvariantCulture;
            var result = DateTime.ParseExact("1/28/2020", format, provider);

            string appointmentText = System.IO.File.ReadAllText(appointments);
            var a = JsonConvert.DeserializeObject<List<Appointment>>(appointmentText);
            List<Appointment> sortedAppointments = a.OrderBy(o => o.practitioner_id).Where(x => x.date >= DateTime.ParseExact(startDate, format, provider) && x.date <= DateTime.ParseExact(endDate, format, provider) && x.practitioner_id== practitionerId).ToList();

            ViewBag.PractitionerName = name;

            return View(sortedAppointments);
        }
    }
}