using FoodOrdering.BLL.Requests;
using FoodOrdering.BLL.Services;
using FoodOrdering.WEB.Models;
using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FoodOrdering.WEB.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly ICompaniesService _companiesService;

        public CompaniesController(ICompaniesService companiesService)
        {
            _companiesService = companiesService;
        }

        public async Task<ActionResult> List()
        {
            var model = new CompanyModel();
            var response = await _companiesService.GetCompanies();

            return View(model.Adapt(response.Companies));
        }

        public async Task<ActionResult> Details(long? id) //TODO: maybe pass in the whole request instead of just ID?
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var model = new CompanyModel();
            var getCompanyResponse = await _companiesService.GetCompanyById(new GetCompanyRequest
            {
                CompanyId = (long)id,
                CorrelationId = Guid.NewGuid().ToString(),
                Requestor = ClaimsPrincipal.Current.Identity.Name
            });

            if (getCompanyResponse.Company == null) return HttpNotFound();

            return View(model.Adapt(getCompanyResponse.Company));
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
                await _companiesService.CreateCompany(new CreateCompanyRequest
                {
                    Name = company.Name,
                    CompanyCode = company.CompanyCode
                });
                return RedirectToAction("List");
            }

            return View(company);
        }

        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var model = new CompanyModel();
            var getCompanyResponse = await _companiesService.GetCompanyById(new GetCompanyRequest
            {
                CompanyId = (long)id,
                CorrelationId = Guid.NewGuid().ToString(),
                Requestor = ClaimsPrincipal.Current.Identity.Name
            });

            if (getCompanyResponse.Company == null) return HttpNotFound();

            return View(model.Adapt(getCompanyResponse.Company));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CompanyModel companyModel)
        {
            if (ModelState.IsValid)
            {
                await _companiesService.UpdateCompany(new UpdateCompanyRequest
                {
                    Name = companyModel.Name,
                    CompanyCode = companyModel.CompanyCode
                });
                return RedirectToAction("List");
            }
            return View(companyModel);
        }

        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var model = new CompanyModel();
            var getCompanyResponse = await _companiesService.GetCompanyById(new GetCompanyRequest
            {
                CompanyId = (long)id,
                CorrelationId = Guid.NewGuid().ToString(),
                Requestor = ClaimsPrincipal.Current.Identity.Name
            });

            if (getCompanyResponse.Company == null) return HttpNotFound();

            return View(model.Adapt(getCompanyResponse.Company));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            var model = new CompanyModel();
            var getCompanyResponse = await _companiesService.GetCompanyById(new GetCompanyRequest
            {
                CompanyId = id,
                CorrelationId = Guid.NewGuid().ToString(),
                Requestor = ClaimsPrincipal.Current.Identity.Name
            });
            if (getCompanyResponse.Company.Users.Any())
            {
                model = model.Adapt(getCompanyResponse.Company);
                model.Errors = true;
                model.ErrorMessage = "There are users associated with this company.";
                return View(model);
            }
            await _companiesService.DeleteCompany(new DeleteCompanyRequest
            {
                CompanyId = id,
                CorrelationId = Guid.NewGuid().ToString(),
                Requestor = ClaimsPrincipal.Current.Identity.Name
            });
            return RedirectToAction("List");
        }
    }
}