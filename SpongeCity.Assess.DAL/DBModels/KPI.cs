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
    public class KPI
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
 
        public string Name { get; set; }
  
        public string DisplayName { get; set; }

        public int CategoryId { get; set; }

        public int SortIdx { get; set; }
    
        public bool IsDefault { get; set; }

        public string DeviceTypes { get; set; }

        public bool IsShow { get; set; }

        public string DataTypes { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category{get;set;}

        public virtual ICollection<View> Views { get; set; }
    }
}
