using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArmyTechTask.Models;
//added
using BLL.Servicces;
using DataAccessL.EF;

namespace ArmyTechTask.Controllers
{
    public class FieldController : Controller
    {
        // GET: Field
        FieldService fieldService = new FieldService();
        public ActionResult Index()
        {
           List< FieldListingVM> fieldListingVM = new List<FieldListingVM> ();
           fieldService.GetAllFields().ToList().ForEach(c=> {
               FieldListingVM fieldListing = new FieldListingVM
               {
                   ID = c.ID,
                   Name=c.Name
               };
               fieldListingVM.Add(fieldListing);
           } );
            
            return View(fieldListingVM);
        }

        // GET: Field/Details/5
        public ActionResult Details(int id)
        {
            var field = fieldService.GetFieldById(id);
            FieldVM fieldVM = new FieldVM()
            {
                ID = field.ID,
                Name = field.Name
            };
            return View(fieldVM);
        }

        // GET: Field/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Field/Create
        [HttpPost]
        public ActionResult Create(FieldVM fieldVM)
        {
            try
            {
                Field field = new Field
                {
                    ID=fieldVM.ID,
                    Name=fieldVM.Name
                };
                fieldService.InsertField(field);
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
            var field = fieldService.GetFieldById(id);
            FieldVM fieldVM = new FieldVM()
            {
                ID=field.ID,
                Name=field.Name
            };
            return View(fieldVM);
        }

        // POST: Field/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FieldVM field)
        {
            try
            {
                var fieldEF = fieldService.GetFieldById(id);

                if (fieldEF != null)
                {
                    fieldEF.ID = field.ID;
                    fieldEF.Name = field.Name;
                    fieldService.UpdateField(fieldEF);

                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Delete(int? id )
        {
            var field = fieldService.GetFieldById(id);
            FieldVM fieldVM = new FieldVM()
            {
                ID = field.ID,
                Name = field.Name
            };
            return View(fieldVM);
        }

        // POST: Field/Delete/5
        [HttpPost]
        public ActionResult Delete(int id )
        {
            try
            {
               var field=  fieldService.GetFieldById(id);
                fieldService.DeleteField(field);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
