using SpongeCity.Assess.DAL;
using SpongeCityAsses.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpongeCity.Asses.BLL
{
    public class SubCategoryBLL
    {
        public List<SubCategoryModel> GetSubCateByViewId(int viewId, int kpiId, int categoryId = 1)
        {
            List<SubCategoryModel> catelist = new List<SubCategoryModel>();
            using (AssessDBContext db = new AssessDBContext())
            {
                if (kpiId == 0)
                {
                    var cateQ = db.Categorys.FirstOrDefault(s => s.ID == categoryId);
                    kpiId = cateQ.KPIS.FirstOrDefault(s => s.IsDefault == true).ID;
                }
                if (viewId == 0)
                {
                    viewId = db.KPIs.FirstOrDefault(s => s.ID == kpiId).Views.FirstOrDefault(s => s.IsDefault == true).ID;
                }
                var viewQ = db.Views.FirstOrDefault(s => s.ID == viewId);
                if (viewQ != null)
                {
                    var subCateQ = viewQ.SubCategory;
                    #region 1-3级节点
                    foreach (var subCate in subCateQ)
                    {
                        SubCategoryModel cateM = new SubCategoryModel()
                        {
                            ID = subCate.ID,
                            Name = subCate.Name,
                            DisplayName = subCate.DisplayName,
                            IsDefault = subCate.IsDefault,
                            IsShow = subCate.IsShow,
                            SortIdx = subCate.SortIdx,
                            SubCategorys = new List<SubCategoryModel>(),
                            AreaId = subCate.AreaId,
                            Code = subCate.Code,
                            KpiId = subCate.KpiId,
                            ViewId = subCate.ViewId,
                            View = new ViewModel() { ID=viewId},
                            ParentId = subCate.ParentId
                        };
                        cateM.View.KPI = new KPIModel() { ID = kpiId };
                        cateM.View.KPI.Category = new CategoryModel() { ID = categoryId };
                        #region 2-3级节点
                        foreach (var scate in subCate.SubCategorys)
                        {
                            SubCategoryModel scateM = new SubCategoryModel()
                            {
                                ID = scate.ID,
                                Name = scate.Name,
                                DisplayName = scate.DisplayName,
                                IsDefault = scate.IsDefault,
                                IsShow = scate.IsShow,
                                SortIdx = scate.SortIdx,
                                SubCategorys = new List<SubCategoryModel>(),
                                AreaId = scate.AreaId,
                                Code = scate.Code,
                                KpiId = scate.KpiId,
                                ViewId = scate.ViewId,
                                View = new ViewModel() { ID = viewId },
                                ParentId = scate.ParentId
                            };
                            scateM.View.KPI = new KPIModel() { ID = kpiId };
                            scateM.View.KPI.Category = new CategoryModel() { ID = categoryId };
                            #region 3级节点
                            foreach (var scate2 in subCate.SubCategorys)
                            {
                                SubCategoryModel scateM2 = new SubCategoryModel()
                                {
                                    ID = scate2.ID,
                                    Name = scate2.Name,
                                    DisplayName = scate2.DisplayName,
                                    IsDefault = scate2.IsDefault,
                                    IsShow = scate2.IsShow,
                                    SortIdx = scate2.SortIdx,
                                    SubCategorys = new List<SubCategoryModel>(),
                                    AreaId = scate2.AreaId,
                                    Code = scate2.Code,
                                    KpiId = scate2.KpiId,
                                    ViewId = scate2.ViewId,
                                    View = new ViewModel() { ID = viewId },
                                    ParentId = scate2.ParentId
                                };
                                scateM2.View.KPI = new KPIModel() { ID = kpiId };
                                scateM2.View.KPI.Category = new CategoryModel() { ID = categoryId };
                                scateM.SubCategorys.Add(scateM2);
                            }
                            #endregion
                            cateM.SubCategorys.Add(scateM);
                        }
                        #endregion
                        catelist.Add(cateM);
                    }
                    #endregion
                }
                return catelist;
            }
        }

        public List<SubCategoryModel> GetRootSubCateByViewId(int viewId, int kpiId, int categoryId = 1)
        {
            List<SubCategoryModel> catelist = new List<SubCategoryModel>();
            using (AssessDBContext db = new AssessDBContext())
            {
                if (kpiId == 0)
                {
                    var cateQ = db.Categorys.FirstOrDefault(s => s.ID == categoryId);
                    if (cateQ == null) return catelist;
                    var kpiQ = cateQ.KPIS.FirstOrDefault(s => s.IsDefault == true);
                    if (kpiQ == null) return catelist;
                    kpiId = kpiQ.ID;
                }
                if (viewId == 0)
                {
                    viewId = db.KPIs.FirstOrDefault(s => s.ID == kpiId).Views.FirstOrDefault(s => s.IsDefault == true).ID;
                }
                var viewQ = db.Views.FirstOrDefault(s => s.ID == viewId);
                if (viewQ != null)
                {
                    var subCateQ = viewQ.SubCategory.Where(s=>s.ParentId== null);
                    #region 1-3级节点
                    foreach (var subCate in subCateQ)
                    {
                        SubCategoryModel cateM = new SubCategoryModel()
                        {
                            ID = subCate.ID,
                            Name = subCate.Name,
                            DisplayName = subCate.DisplayName,
                            IsDefault = subCate.IsDefault,
                            IsShow = subCate.IsShow,
                            SortIdx = subCate.SortIdx,
                            SubCategorys = new List<SubCategoryModel>(),
                            AreaId = subCate.AreaId,
                            Code = subCate.Code,
                            KpiId = subCate.KpiId,
                            ViewId = subCate.ViewId,
                            View = new ViewModel() { ID = viewId },
                            ParentId = subCate.ParentId
                        };
                        cateM.View.KPI = new KPIModel() { ID = kpiId };
                        cateM.View.KPI.Category = new CategoryModel() { ID = categoryId };
                        #region 2-3级节点
                        foreach (var scate in subCate.SubCategorys)
                        {
                            SubCategoryModel scateM = new SubCategoryModel()
                            {
                                ID = scate.ID,
                                Name = scate.Name,
                                DisplayName = scate.DisplayName,
                                IsDefault = scate.IsDefault,
                                IsShow = scate.IsShow,
                                SortIdx = scate.SortIdx,
                                SubCategorys = new List<SubCategoryModel>(),
                                AreaId = scate.AreaId,
                                Code = scate.Code,
                                KpiId = scate.KpiId,
                                ViewId = scate.ViewId,
                                View = new ViewModel() { ID = viewId,KpiId=kpiId },
                                ParentId = scate.ParentId
                            };
                            scateM.View.KPI = new KPIModel() { ID = kpiId,CategoryId=categoryId };
                            scateM.View.KPI.Category = new CategoryModel() { ID = categoryId };
                            #region 3级节点
                            foreach (var scate2 in scate.SubCategorys)
                            {
                                SubCategoryModel scateM2 = new SubCategoryModel()
                                {
                                    ID = scate2.ID,
                                    Name = scate2.Name,
                                    DisplayName = scate2.DisplayName,
                                    IsDefault = scate2.IsDefault,
                                    IsShow = scate2.IsShow,
                                    SortIdx = scate2.SortIdx,
                                    SubCategorys = new List<SubCategoryModel>(),
                                    AreaId = scate2.AreaId,
                                    Code = scate2.Code,
                                    KpiId = scate2.KpiId,
                                    ViewId = scate2.ViewId,
                                    View = new ViewModel() { ID = viewId,KpiId=kpiId },
                                    ParentId = scate2.ParentId
                                };
                                scateM2.View.KPI = new KPIModel() { ID = kpiId,CategoryId=categoryId };
                                scateM2.View.KPI.Category = new CategoryModel() { ID = categoryId };
                                scateM.SubCategorys.Add(scateM2);
                            }
                            #endregion
                            cateM.SubCategorys.Add(scateM);
                        }
                        #endregion
                        catelist.Add(cateM);
                    }
                    #endregion
                }
                return catelist;
            }
        }
    }
}

