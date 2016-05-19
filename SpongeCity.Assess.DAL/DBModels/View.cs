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
    public class View
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
    
        public string Name { get; set; }
   
        public string DisplayName { get; set; }
  
        public int KpiId { get; set; }

        public int SortIdx { get; set; }

        public bool IsDefault { get; set; }
 
        public string MenuName { get; set; }

        public bool IsShow { get; set; }

        public int ViewTemplateId { get; set; }

        [ForeignKey("KpiId")]
        public virtual KPI KPI { get; set; }

        [ForeignKey("ViewTemplateId")]
        public virtual ViewTemplate ViewTemplate { get; set; }

        public virtual ICollection<SubCategory> SubCategory { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }

    }
}
