using SpongeCity.Assess.DAL;
using SpongeCity.Assess.DAL.DBModels;
using SpongeCityAsses.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpongeCity.Asses.BLL
{
    public class ViewBLL
    {
        public List<ViewModel> GetViewsbyKpiId(int kpiId,int categoryId)
        {
            List<ViewModel> viewlist = new List<ViewModel>();
            using (AssessDBContext db = new AssessDBContext())
            {
                if (kpiId == 0)
                {
                    var cateQ = db.Categorys.FirstOrDefault(s => s.ID == categoryId);
                    if (cateQ == null) return viewlist;
                    var kpi = cateQ.KPIS.FirstOrDefault(s => s.IsDefault == true);
                    if (kpi == null) return viewlist;
                    kpiId = kpi.ID;
                }
                var kpiQ = db.KPIs.FirstOrDefault(s => s.ID == kpiId);
                if (kpiQ != null)
                {
                    KPIModel cateM = new KPIModel()
                    {
                        ID = kpiQ.ID,
                        Name = kpiQ.Name,
                        DisplayName = kpiQ.DisplayName,
                        IsDefault = kpiQ.IsDefault,
                        IsShow = kpiQ.IsShow,
                        SortIdx = kpiQ.SortIdx,
                        //Category = new List<KPIModel>()
                        DataTypes = kpiQ.DataTypes,
                        DeviceTypes = kpiQ.DeviceTypes,
                        Views = new List<ViewModel>(),
                        CategoryId = kpiQ.CategoryId
                    };
                    #region initilize view list
                    foreach (var view in kpiQ.Views)
                    {
                        ViewModel kpim = new ViewModel()
                        {
                            ID = view.ID,
                            KPI = cateM,
                            DisplayName = view.DisplayName,
                            Name = view.Name,
                            IsDefault = view.IsDefault,
                            IsShow = view.IsShow,
                            SortIdx = view.SortIdx,
                            MenuName = view.MenuName,
                            KpiId = view.KpiId,
                            //ViewTemplate = view.ViewTemplate,
                            ViewTemplateId = view.ViewTemplateId,
                            Activities = new List<ActivityModel>(),
                            SubCategorys = new List<SubCategoryModel>()
                        };
                        viewlist.Add(kpim);
                    }
                    #endregion
                }
            }
            return viewlist;
        }

        public ViewModel GetViewbyViewId(int viewId, int kpiId, int categoryId)
        {
            ViewModel viewModel = new ViewModel();
            using (AssessDBContext db = new AssessDBContext())
            {
                if (viewId == 0)
                {
                    var cateQ = db.Categorys.FirstOrDefault(s => s.ID == categoryId);
                    if (cateQ == null) return viewModel;
                    if (kpiId == 0)
                    {
                        var kpi = cateQ.KPIS.FirstOrDefault(s => s.IsDefault == true);
                        if (kpi == null) return viewModel;
                        kpiId = kpi.ID;
                    }
                    viewId = db.Views.FirstOrDefault(s => s.KpiId == kpiId && s.IsDefault == true).ID;
                }
                var kpiQ = db.KPIs.FirstOrDefault(s => s.ID == kpiId);
                if (kpiQ != null)
                {
                    KPIModel cateM = new KPIModel()
                    {
                        ID = kpiQ.ID,
                        Name = kpiQ.Name,
                        DisplayName = kpiQ.DisplayName,
                        IsDefault = kpiQ.IsDefault,
                        IsShow = kpiQ.IsShow,
                        SortIdx = kpiQ.SortIdx,
                        //Category = new List<KPIModel>()
                        DataTypes = kpiQ.DataTypes,
                        DeviceTypes = kpiQ.DeviceTypes,
                        Views = new List<ViewModel>(),
                        CategoryId = kpiQ.CategoryId
                    };
                    #region initilize view list
                    View viewQ = db.Views.FirstOrDefault(s=>s.ID == viewId);
                    ViewModel kpim = new ViewModel()
                    {
                        ID = viewQ.ID,
                        KPI = cateM,
                        DisplayName = viewQ.DisplayName,
                        Name = viewQ.Name,
                        IsDefault = viewQ.IsDefault,
                        IsShow = viewQ.IsShow,
                        SortIdx = viewQ.SortIdx,
                        MenuName = viewQ.MenuName,
                        KpiId = viewQ.KpiId,
                        //ViewTemplate = view.ViewTemplate,
                        ViewTemplateId = viewQ.ViewTemplateId,
                        Activities = new List<ActivityModel>(),
                        SubCategorys = new List<SubCategoryModel>()
                    };
                    foreach(var activity in viewQ.Activities)
                    {
                        ActivityModel am = new ActivityModel() {
                            ID=activity.ID,
                            Name=activity.Name,
                            Action = activity.Action,
                            ColumnEndIdx = activity.ColumnEndIdx,
                            ColumnStartIdx = activity.ColumnStartIdx,
                            IsShow = activity.IsShow,
                            Route = activity.Route,
                            RowEndIdx=activity.RowEndIdx,
                            RowStartIdx = activity.RowStartIdx,
                            SortIdx=activity.SortIdx,
                            Col_md_Count=activity.Col_md_Count,
                            ViewId= activity.ViewId,
                            View = kpim
                        };
                        kpim.Activities.Add(am);
                    }
                    viewModel = kpim;
                    #endregion
                }
            }
            return viewModel;
        }
    }
}
