using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpongeCity.Assess.DAL.DBModels
{
    public class ViewTemplate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
   
        public string Name { get; set; }
       
        public string DisplayName { get; set; }
  
        public int RowCount { get; set; }
   
        public int ColumnCount { get; set; }
    
        public int TotalWidth { get; set; }
    
        public int TotalHeight{get;set;}
     
        public int SubWidth { get; set; }
      
        public int SubHeight { get; set; }

        public virtual ICollection<View> Views { get; set; }
    }
}
