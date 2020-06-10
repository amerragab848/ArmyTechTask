using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArmyTechTask.Models
{
    public class StudentTeacherVM
    {
        public int ID { get; set; }
        [Display(Name ="Student")]
        public int StudentId { get; set; }
        [Display(Name = "Teacher")]
        public int TeacherId { get; set; }
        public List<SelectListItem> Students
        {
            get;
            set;
        } = new List<SelectListItem>();
        public List<SelectListItem> Teachers
        {
            get;
            set;
        } = new List<SelectListItem>();
    }
}