using SpongeCity.Assess.DAL;
using SpongeCityAsses.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpongeCity.Asses.BLL
{
    public class CategoryBLL
    {
        public List<CategoryModel> GetAllCategory()
        {
            List<CategoryModel> catelist = new List<CategoryModel>();
            using (AssessDBContext db = new AssessDBContext())
            {
                var cateQ = db.Categorys;
                foreach (var cate in cateQ)
                {
                    CategoryModel cateM = new CategoryModel() {
                        ID = cate.ID,
                        Name = cate.Name,
                        DisplayName = cate.DisplayName,
                        IsDefault = cate.IsDefault,
                        IsShow = cate.IsShow,
                        SortIdx = cate.SortIdx,
                        KPIS = new List<KPIModel>()
                    };
                    foreach (var kpi in cate.KPIS)
                    {
                        KPIModel kpim = new KPIModel() {
                            ID = kpi.ID,
                            Category = cateM,
                            CategoryId = cateM.ID,
                            DataTypes = kpi.DataTypes,
                            DeviceTypes = kpi.DeviceTypes,
                            DisplayName = kpi.DisplayName,
                            Name = kpi.Name,
                            IsDefault = kpi.IsDefault,
                            IsShow = kpi.IsShow,
                            SortIdx = kpi.SortIdx
                        };
                        cateM.KPIS.Add(kpim);  
                    }
                    catelist.Add(cateM);
                }
            }
            return catelist;
        }
    }
}
