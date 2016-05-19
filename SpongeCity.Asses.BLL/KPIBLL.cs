using SpongeCity.Assess.DAL;
using SpongeCityAsses.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpongeCity.Asses.BLL
{
    public class KPIBLL
    {
        public List<KPIModel> GetKpisbyCategoryId(int categoryId)
        {
            List<KPIModel> catelist = new List<KPIModel>();
            using (AssessDBContext db = new AssessDBContext())
            {
                var cateQ = db.Categorys.FirstOrDefault(s=>s.ID==categoryId);
                if (cateQ != null)
                {
                    var kpiQ = cateQ.KPIS;
                    foreach (var kpi in kpiQ)
                    {
                        KPIModel cateM = new KPIModel()
                        {
                            ID = kpi.ID,
                            Name = kpi.Name,
                            DisplayName = kpi.DisplayName,
                            IsDefault = kpi.IsDefault,
                            IsShow = kpi.IsShow,
                            SortIdx = kpi.SortIdx,
                            //Category = new List<KPIModel>()
                            DataTypes = kpi.DataTypes,
                            DeviceTypes = kpi.DeviceTypes,
                            Views = new List<ViewModel>(),
                            CategoryId = kpi.CategoryId
                        };
                        #region 
                        //foreach (var view in kpi.Views)
                        //{
                        //    ViewModel kpim = new ViewModel()
                        //    {
                        //        ID = kpi.ID,
                        //        Category = cateM,
                        //        CategoryId = cateM.ID,
                        //        DataTypes = kpi.DataTypes,
                        //        DeviceTypes = kpi.DeviceTypes,
                        //        DisplayName = kpi.DisplayName,
                        //        Name = kpi.Name,
                        //        IsDefault = kpi.IsDefault,
                        //        IsShow = kpi.IsShow,
                        //        SortIdx = kpi.SortIdx
                        //    };
                        //    cateM.KPIS.Add(kpim);
                        //}
                        #endregion
                        catelist.Add(cateM);
                    }
                }
            }
            return catelist;
        }
    }
}
