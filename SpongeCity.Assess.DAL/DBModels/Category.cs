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
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public int SortIdx { get; set; }

        public bool IsDefault { get; set; }

        public bool IsShow { get; set; }

        public virtual ICollection<KPI> KPIS { get; set; }
      
    }
}
