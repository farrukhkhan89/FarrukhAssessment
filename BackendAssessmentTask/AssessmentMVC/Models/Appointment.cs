using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssessmentMVC.Models
{
    public class Appointment
    {
       // {"id":82,"date":"3/20/2020","client_name":"Claiborn Gepheart","appointment_type":"04100ZH","duration":21,"revenue":61,"cost":29,"practitioner_id":4},

        public int id { get; set; }
        public string client_name { get; set; }

        public string appointment_type { get; set; }
        public int duration { get; set; }
        public int revenue { get; set; }
        public int cost { get; set; }
        public int practitioner_id { get; set; }
        public DateTime date { get; set; }

    }
}