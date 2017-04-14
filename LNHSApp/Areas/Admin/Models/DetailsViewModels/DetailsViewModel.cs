using LNHSApp.Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNHSApp.Areas.Admin.Models.DetailsViewModels
{
    public class DetailsViewModel
    {
        public DetailFilter Filter { get; set; }
        public ICollection<DetailViewModel> DetailsList { get; set; }
    }
}