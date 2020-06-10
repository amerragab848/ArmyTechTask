using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArmyTechTask.Models
{
    public class StudentListingVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Governorate { get; set; }
        public string Neighborhood { get; set; }
        public string Field { get; set; }
    
    }
}