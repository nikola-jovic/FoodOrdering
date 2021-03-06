﻿using System.Collections.Generic;
using FoodOrdering.BLL.Responses.DTO;

namespace FoodOrdering.BLL.Responses
{
    public class GetCompaniesResponse : Response
    {
        public IList<Company> Companies { get; set; }
    }
}