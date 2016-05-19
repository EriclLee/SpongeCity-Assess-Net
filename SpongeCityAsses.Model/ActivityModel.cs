using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpongeCityAsses.Model
{
    public class ActivityModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Route { get; set; }

        public string Action { get; set; }

        public int RowStartIdx { get; set; }

        public int RowEndIdx { get; set; }

        public int ColumnStartIdx { get; set; }

        public int ColumnEndIdx { get; set; }

        public int SortIdx { get; set; }

        public int Col_md_Count { get; set; }

        public int ViewId { get; set; }

        public bool IsShow { get; set; }

        public ViewModel View { get; set; }
    }
}
