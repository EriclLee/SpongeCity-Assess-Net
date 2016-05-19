using SpongeCity.Asses.BLL;
using SpongeCityAsses.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpongeCity.Assess.Web.Controllers
{
    public class ViewPageController : Controller
    {
        // GET: ViewPage
        public ActionResult PageView(int subCategoryId, int viewId, int kpiId, int categoryId)
        {
            ViewModel vm = new ViewModel();
            ViewBLL bll = new ViewBLL();
            vm = bll.GetViewbyViewId(viewId,kpiId, categoryId);
            return PartialView(vm);
        }
    }
}