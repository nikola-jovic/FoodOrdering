using FoodOrdering.BLL.Responses.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace FoodOrdering.WEB.Models
{
	public class CompanyModel
	{
		public long Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		[Display(Name = "Company Code")]
		public string CompanyCode { get; set; }

		public bool Errors { get; set; }
		public string ErrorMessage { get; set; }

		public CompanyModel Adapt(Company companyToAdapt)
		{
			if (companyToAdapt == null) throw new ArgumentNullException("companyToAdapt");

			return new CompanyModel
			{
				Id = companyToAdapt.Id,
				CompanyCode = companyToAdapt.CompanyCode,
				Name = companyToAdapt.Name
			};
		}

		public IList<CompanyModel> Adapt(IList<Company> companiestoAdapt)
		{
			if (companiestoAdapt == null) throw new ArgumentNullException("companiestoAdapt");

			return companiestoAdapt.Select(Adapt).ToList();
		}
	}
}