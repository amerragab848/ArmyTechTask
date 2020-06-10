using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArmyTechTask.Models
{
    public class NeighborhoodListingVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Governorate { get; set; }
   
    }
}