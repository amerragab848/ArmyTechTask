using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArmyTechTask.Models
{
    public class NeighborhoodVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [Display(Name = "Governorate")]
        public int GovernorateId { get; set; }
        public List<SelectListItem> Governorates
        {
            get;
            set;
        } = new List<SelectListItem>();
    }
}