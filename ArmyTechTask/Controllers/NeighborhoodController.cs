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
    public class NeighborhoodController : Controller
    {
        NeighborhoodService neighborhoodService = new NeighborhoodService();
        GovernorateService GovernorateService = new GovernorateService();

        // GET: Neighborhood
        public ActionResult Index()
        {
            List<NeighborhoodListingVM> neighborhoodListingVM = new List<NeighborhoodListingVM>();
            neighborhoodService.GetAllNeighborhoods().ToList().ForEach(c => {
                NeighborhoodListingVM neighborhoodListing = new NeighborhoodListingVM
                {
                    ID = c.ID,
                    Name = c.Name,
                    
                };
                neighborhoodListingVM.Add(neighborhoodListing);
            });

            return View(neighborhoodListingVM);
        }

        // GET: Field/Details/5
        public ActionResult Details(int id)
        {
            var nighborhood = neighborhoodService.GetNeighborhoodById(id);
            NeighborhoodVM neighborhoodVM = new NeighborhoodVM()
            {
                ID = nighborhood.ID,
                Name = nighborhood.Name
            };
            return View(neighborhoodVM);
        }

        // GET: Field/Create
        public ActionResult Create()
        {

            NeighborhoodVM neighborhood = new NeighborhoodVM();
            neighborhood.Governorates = GovernorateService.GetAllGovernorates().Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.ID.ToString()
            }).ToList();
            return View(neighborhood);
        }

        // POST: Field/Create
        [HttpPost]
        public ActionResult Create(NeighborhoodVM neighborhoodVM)
        {
            try
            {
              
                Neighborhood governorate = new Neighborhood
                {
                    ID = neighborhoodVM.ID,
                    Name = neighborhoodVM.Name,
                    GovernorateId= neighborhoodVM.GovernorateId
                };
                neighborhoodService.InsertNeighborhood(governorate);
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
            var neighborhoodEF = neighborhoodService.GetNeighborhoodById(id);
            NeighborhoodVM neighborhood = new NeighborhoodVM();
            neighborhood.Governorates = GovernorateService.GetAllGovernorates().Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.ID.ToString()
            }).ToList();

            neighborhood.ID = neighborhoodEF.ID;
            neighborhood.Name = neighborhoodEF.Name;
            
            return View(neighborhood);
        }

        // POST: Field/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, NeighborhoodVM neighborhood)
        {
            try
            {
                var neighborhoodEF = neighborhoodService.GetNeighborhoodById(id);

                if (neighborhoodEF != null)
                {
                    neighborhoodEF.ID = neighborhood.ID;
                    neighborhoodEF.Name = neighborhood.Name;
                    neighborhoodEF.GovernorateId = neighborhood.GovernorateId;

                    neighborhoodService.UpdateNeighborhood(neighborhoodEF);

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
            var nighborhood = neighborhoodService.GetNeighborhoodById(id);
            NeighborhoodVM neighborhoodVM = new NeighborhoodVM()
            {
                ID = nighborhood.ID,
                Name = nighborhood.Name
            };
            return View(neighborhoodVM);
        }
        // POST: Field/Delete/5
        [HttpPost]
        public ActionResult Delete(int id )
        {
            try
            {
                var neighborhood = neighborhoodService.GetNeighborhoodById(id);
                neighborhoodService.DeleteNeighborhood(neighborhood);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
