using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//added
using BLL.Servicces;
using ArmyTechTask.Models;
using DataAccessL.EF;

namespace ArmyTechTask.Controllers
{
    public class GovernorateController : Controller
    {
        GovernorateService GovernorateService = new GovernorateService();
        // GET: Governorate
        public ActionResult Index()
        {
            List<GovernorateListingVM> governorateListingVM = new List<GovernorateListingVM>();
            GovernorateService.GetAllGovernorates().ToList().ForEach(c => {
                GovernorateListingVM governorateListing = new GovernorateListingVM
                {
                    ID = c.ID,
                    Name = c.Name
                };
                governorateListingVM.Add(governorateListing);
            });

            return View(governorateListingVM);
        }

        // GET: Field/Details/5
        public ActionResult Details(int id)
        {
            var governorate = GovernorateService.GetGovernorateById(id);
            GovernorateVM governorateVM = new GovernorateVM()
            {
                ID = governorate.ID,
                Name = governorate.Name
            };
            return View(governorateVM);
        }

        // GET: Field/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Field/Create
        [HttpPost]
        public ActionResult Create(GovernorateVM governorateVM)
        {
            try
            {
                Governorate governorate = new Governorate
                {
                    ID = governorateVM.ID,
                    Name = governorateVM.Name
                };
                GovernorateService.InsertGovernorate(governorate);
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
            var governorate = GovernorateService.GetGovernorateById(id);
            GovernorateVM governorateVM = new GovernorateVM()
            {
                ID = governorate.ID,
                Name = governorate.Name
            };
            return View(governorateVM);
        }

        // POST: Field/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, GovernorateVM governorate)
        {
            try
            {
                var governorateEF = GovernorateService.GetGovernorateById(id);

                if (governorateEF != null)
                {
                    governorateEF.ID = governorate.ID;
                    governorateEF.Name = governorate.Name;
                    GovernorateService.UpdateGovernorate(governorateEF);

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
            var governorate = GovernorateService.GetGovernorateById(id);
            GovernorateVM governorateVM = new GovernorateVM()
            {
                ID = governorate.ID,
                Name = governorate.Name
            };
            return View(governorateVM);
        }
        // POST: Field/Delete/5
        [HttpPost]
        public ActionResult Delete(int id )
        {
            try
            {
                var governorate = GovernorateService.GetGovernorateById(id);
                GovernorateService.DeleteGovernorate(governorate);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
