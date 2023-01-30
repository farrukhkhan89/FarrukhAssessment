using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssessmentMVC.Models
{
    public class PractitionerVM
    {
        public List<PractitionerModel> prModel { get; set; }
        public DateTime? DOB { get; set; }
    }

    public class PractitionerModel
    {
        public int PractitionerId { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public double Revenue { get; set; }
        // public DateTime DOB { get; set; }

        //public DateTime Dob { get; set; }

    }
}