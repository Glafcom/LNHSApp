using LNHSApp.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.Domain.Models
{
    public class Article : BaseModel
    {
        public DateTime PublishDate { get; set; }
        public string Caption { get; set; }
        public string ShortText { get; set; }
        public string LongText { get; set; }
        public Guid AuthorId { get; set; }
        
        public virtual User Author { get; set; }
    }
}
