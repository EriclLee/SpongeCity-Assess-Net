using SpongeCity.Asses.BLL;
using SpongeCityAsses.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpongeCity.Assess.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HomePage()
        {
            return PartialView();
        }

        public ActionResult CategoryMenu()
        {
            CategoryBLL bll = new CategoryBLL();
            List<CategoryModel> catelist = bll.GetAllCategory();
            return PartialView(catelist);
        }

        public ActionResult KPIMenu(int categoryId=1)
        {
            KPIBLL bll = new KPIBLL();
            List<KPIModel> kpiList = bll.GetKpisbyCategoryId(categoryId);
            return PartialView(kpiList);
        }

        public ActionResult ViewMenu(int kpiId, int categoryId=1)
        {
            ViewBLL bll = new ViewBLL();
            List<ViewModel> kpiList = bll.GetViewsbyKpiId(kpiId,categoryId);
            return PartialView(kpiList);
        }

        public ActionResult SubCategoryMenu(int viewId, int kpiId, int categoryId = 1)
        {
            SubCategoryBLL bll = new SubCategoryBLL();
            List<SubCategoryModel> kpiList = bll.GetRootSubCateByViewId(viewId,kpiId,categoryId);
            return PartialView(kpiList);
        }
    }
}