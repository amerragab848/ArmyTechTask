using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//added
using BLL.Servicces;
using ArmyTechTask.Models;
using DataAccessL.EF;
using System.Net;

namespace ArmyTechTask.Controllers
{
    public class StudentController : Controller
    {
        StudentService studentService = new StudentService();
        FieldService fieldService = new FieldService();
        GovernorateService governorateService = new GovernorateService();
        NeighborhoodService neighborhoodService = new NeighborhoodService();

        // GET: Student
        public ActionResult Index()
        {
            List<StudentListingVM> studentListingVM = new List<StudentListingVM>();
            studentService.GetAllStudents().ToList().ForEach(c => {
                StudentListingVM studentListing = new StudentListingVM
                {
                    ID = c.ID,
                    Name = c.Name,
                    BirthDate=c.BirthDate,
                    Field=c.Field.Name,
                    Governorate=c.Governorate.Name,
                    Neighborhood=c.Neighborhood.Name

                };
                studentListingVM.Add(studentListing);
            });

            return View(studentListingVM);
        }

        // GET: Field/Details/5
        public ActionResult Details(int id)
        {
            var student = studentService.GetStudentById(id);
            StudentListingVM studentListingVM = new StudentListingVM()
            {
                ID = student.ID,
                Name = student.Name,
                BirthDate = student.BirthDate,
                Field = student.Field.Name,
                Governorate = student.Governorate.Name,
                Neighborhood = student.Neighborhood.Name
            };
            return View(studentListingVM);
        }

        // GET: Field/Create
        public ActionResult Create()
        {

            StudentVM student = new StudentVM();
            student.Governorates = governorateService.GetAllGovernorates().Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.ID.ToString()
            }).ToList();
            student.Fields = fieldService.GetAllFields().Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.ID.ToString()
            }).ToList();
            student.Neighborhoods = neighborhoodService.GetAllNeighborhoods().Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.ID.ToString()
            }).ToList();
            return View(student);
        }

        // POST: Field/Create
        [HttpPost]
        public ActionResult Create(StudentVM student)
        {
            try
            {

                Student studentEF = new Student
                {
                    ID = student.ID,
                    Name = student.Name,
                    GovernorateId = student.GovernorateId,
                    BirthDate=student.BirthDate,
                    FieldId=student.FieldId,
                    NeighborhoodId=student.NeighborhoodId
                };
                studentService.InsertStudent(studentEF);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: Field/Edit/5
        public ActionResult Edit(int id)
        {
            var studentEF = studentService.GetStudentById(id);
            StudentVM student = new StudentVM();

            student.Governorates = governorateService.GetAllGovernorates().Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.ID.ToString()
            }).ToList();
            student.Fields = fieldService.GetAllFields().Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.ID.ToString()
            }).ToList();
            student.Neighborhoods = neighborhoodService.GetAllNeighborhoods().Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.ID.ToString()
            }).ToList();
            student.ID = studentEF.ID;
            student.Name = studentEF.Name;
            student.BirthDate = studentEF.BirthDate;
            student.FieldId = studentEF.FieldId;
            student.GovernorateId = studentEF.GovernorateId;
            student.NeighborhoodId = studentEF.NeighborhoodId;

            return View(student);
        }

        // POST: Field/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, StudentVM student)
        {
            try
            {
                var studentEF = studentService.GetStudentById(id);

                if (studentEF != null)
                {
                    studentEF.ID = student.ID;
                    studentEF.Name = student.Name;
                    studentEF.GovernorateId = student.GovernorateId;

                    studentService.UpdateStudent(studentEF);

                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public ActionResult Delete(int? id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var student = studentService.GetStudentById(id);
            StudentListingVM studentListingVM = new StudentListingVM()
            {
                ID = student.ID,
                Name = student.Name,
                BirthDate = student.BirthDate,
                Field = student.Field.Name,
                Governorate = student.Governorate.Name,
                Neighborhood = student.Neighborhood.Name
            };
            return View(studentListingVM);
            // return View();
        }
        // POST: Field/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var student = studentService.GetStudentById(id);
                studentService.DeleteStudent(student);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
