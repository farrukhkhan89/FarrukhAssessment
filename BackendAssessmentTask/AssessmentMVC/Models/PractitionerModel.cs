using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssessmentMVC.Models
{
    public class PractitionerModel
    {
        public int PractitionerId { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public double Revenue { get; set; }
        // public DateTime DOB { get; set; }
        [Range(typeof(DateTime), "01/01/2000", "01/01/2010")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime HireDate { get; set; }

    }
}