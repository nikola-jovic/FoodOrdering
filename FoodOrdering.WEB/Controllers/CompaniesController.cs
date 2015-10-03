using FoodOrdering.DAL.DB;
using FoodOrdering.WEB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FoodOrdering.WEB.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly FoodOrderingEntities _foodOrderingDb;

        public CompaniesController()
        {
            _foodOrderingDb = new FoodOrderingDbFactory().GetDatabase();
        }

        // GET: Companies
        public ActionResult List()
        {
            var list = _foodOrderingDb.Companies;
            var model = list.Select(company => new CompanyModel
            {
                Id = company.Id,
                CompanyCode = company.CompanyCode,
                Name = company.Name
            }).ToList();

            return View(model);
        }

        // GET: Companies/Details/5
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
            return View(company);
        }

        // GET: Companies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,CompanyCode")] CompanyModel company)
        {
            if (ModelState.IsValid)
            {
                Company companyToCreate = new Company { Name = company.Name, CompanyCode = company.CompanyCode };
                _foodOrderingDb.Companies.Add(companyToCreate);
                _foodOrderingDb.SaveChanges();
                return RedirectToAction("List");
            }

            return View(company);
        }

        // GET: Companies/Edit/5
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
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CompanyCode")] Company company)
        {
            if (ModelState.IsValid)
            {
                _foodOrderingDb.Entry(company).State = EntityState.Modified;
                _foodOrderingDb.SaveChanges();
                return RedirectToAction("List");
            }
            return View(company);
        }

        // GET: Companies/Delete/5
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
            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Company company = _foodOrderingDb.Companies.Find(id);
            _foodOrderingDb.Companies.Remove(company);
            _foodOrderingDb.SaveChanges();
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