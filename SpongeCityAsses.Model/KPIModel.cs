using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpongeCityAsses.Model
{
    public class KPIModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public int CategoryId { get; set; }

        public int SortIdx { get; set; }

        public bool IsDefault { get; set; }

        public bool IsShow { get; set; }

        public string DeviceTypes { get; set; }

        public string DataTypes { get; set; }

        public CategoryModel Category { get; set; }

        public List<ViewModel> Views { get; set; }
    }
}
