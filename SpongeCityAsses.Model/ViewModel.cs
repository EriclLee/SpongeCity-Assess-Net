using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpongeCityAsses.Model
{
    public class ViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public int KpiId { get; set; }

        public int SortIdx { get; set; }

        public bool IsDefault { get; set; }

        public bool IsShow { get; set; }

        public string MenuName { get; set; }

        public int ViewTemplateId { get; set; }

        public KPIModel KPI { get; set; }

        public  VTModel ViewTemplate { get; set; }

        public List<SubCategoryModel> SubCategorys { get; set; }

        public List<ActivityModel> Activities { get; set; }
    }
}
