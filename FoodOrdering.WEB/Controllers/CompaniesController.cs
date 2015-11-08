﻿using FoodOrdering.BLL.Requests;
using FoodOrdering.BLL.Responses;
using FoodOrdering.BLL.Services;
using FoodOrdering.DAL.DB;
using FoodOrdering.WEB.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Company = FoodOrdering.DAL.DB.Company;

namespace FoodOrdering.WEB.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly FoodOrderingEntities _foodOrderingDb;
        private readonly IGetCompaniesService _getCompaniesService;

        public CompaniesController(FoodOrderingEntities foodOrderingDb, IGetCompaniesService getCompaniesService)
        {
            _foodOrderingDb = foodOrderingDb;
            _getCompaniesService = getCompaniesService;
        }

        public async Task<ActionResult> List()
        {
            CompanyModel model = new CompanyModel();
            GetCompaniesResponse response = await _getCompaniesService.GetCompanies(new GetCompaniesRequest());
            return View(model.Adapt(response.Companies));
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = _foodOrderingDb.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            // TODO: Adapter
            CompanyModel companyModel = new CompanyModel
            {
                Id = company.Id,
                Name = company.Name,
                CompanyCode = company.CompanyCode
            };
            return View(companyModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CompanyModel company)
        {
            if (ModelState.IsValid)
            {
                Company companyToCreate = new Company { Name = company.Name, CompanyCode = company.CompanyCode };
                _foodOrderingDb.Companies.Add(companyToCreate);
                await _foodOrderingDb.SaveChangesAsync();
                return RedirectToAction("List");
            }

            return View(company);
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = _foodOrderingDb.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            // TODO: Adapter
            CompanyModel companyModel = new CompanyModel
            {
                Id = company.Id,
                Name = company.Name,
                CompanyCode = company.CompanyCode
            };
            return View(companyModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CompanyModel companyModel)
        {
            if (ModelState.IsValid)
            {
                Company company = _foodOrderingDb.Companies.Find(companyModel.Id);
                company.CompanyCode = companyModel.CompanyCode;
                company.Name = companyModel.Name;
                _foodOrderingDb.Entry(company).State = EntityState.Modified;
                await _foodOrderingDb.SaveChangesAsync();
                return RedirectToAction("List");
            }
            return View(companyModel);
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = _foodOrderingDb.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            // TODO: Adapter
            CompanyModel companyModel = new CompanyModel
            {
                Id = company.Id,
                Name = company.Name,
                CompanyCode = company.CompanyCode
            };
            return View(companyModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Company company = _foodOrderingDb.Companies.Find(id);
            if (company.AspNetUsers.Any())
            {
                // TODO: Adapter
                CompanyModel companyModel = new CompanyModel
                {
                    Id = company.Id,
                    Name = company.Name,
                    CompanyCode = company.CompanyCode,
                    Errors = true,
                    ErrorMessage = "There are users associated with this company."
                };
                return View(companyModel);
            }
            _foodOrderingDb.Companies.Remove(company);
            await _foodOrderingDb.SaveChangesAsync();
            return RedirectToAction("List");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _foodOrderingDb.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}