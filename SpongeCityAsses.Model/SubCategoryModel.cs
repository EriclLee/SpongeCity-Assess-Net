using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpongeCityAsses.Model
{
    public class SubCategoryModel
    {
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
        
        public ViewModel View { get; set; }
        
        public SubCategoryModel Parent { get; set; }

        public List<SubCategoryModel> SubCategorys { get; set; }
    }
}
