using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArmyTechTask.Models
{
    public class StudentVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string BirthDate { get; set; }
        [Display(Name = "Governorate")]
        public int GovernorateId { get; set; }
        [Display(Name = "Neighborhood")]
        public int? NeighborhoodId { get; set; }
        [Display(Name = "Field")]
        public int FieldId { get; set; }
        public List<SelectListItem> Governorates
        {
            get;
            set;
        } = new List<SelectListItem>();

        public List<SelectListItem> Neighborhoods
        {
            get;
            set;
        } = new List<SelectListItem>();

        public List<SelectListItem> Fields
        {
            get;
            set;
        } = new List<SelectListItem>();
        public GovernorateVM GovernorateVM { get; set; }
        public NeighborhoodVM NeighborhoodVM { get; set; }

        public FieldVM FieldVM { get; set; }

    }
}