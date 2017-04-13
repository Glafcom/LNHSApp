using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNHSApp.Areas.Admin.Models.BreakingsViewModels
{
    public class BlankBreakingViewModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid DetailId { get; set; }
        public Guid? GameId { get; set; }
        public Guid? TableId { get; set; }

        public IEnumerable<Guid> Guilties { get; set; }
    }
}