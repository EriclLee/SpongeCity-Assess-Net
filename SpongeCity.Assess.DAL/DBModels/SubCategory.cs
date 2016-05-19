using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpongeCity.Assess.DAL.DBModels
{
    public class SubCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public int KpiId { get; set; }

        public int SortIdx { get; set; }

        public bool IsDefault { get; set; }

        public bool IsShow { get; set; }

        public string AreaId { get; set; }

        public int? ParentId { get; set; }

        public int ViewId { get; set; }

        [ForeignKey("ViewId")]
        public virtual View View { get; set; }

        [ForeignKey("ParentId")]
        public virtual SubCategory Parent { get; set; }

        public virtual ICollection<SubCategory> SubCategorys { get; set; }
    }
}
