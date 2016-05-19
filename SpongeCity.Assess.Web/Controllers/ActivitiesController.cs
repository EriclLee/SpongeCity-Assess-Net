using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpongeCity.Assess.Web.Controllers
{
    public class ActivitiesController : Controller
    {
        // GET: Activities
        public ActionResult Streamflow_Control_Rate()
        {
            return PartialView();
        }

        public ActionResult RainvsStream() {
            return PartialView();
        }

        public ActionResult In_Out_Water()
        {
            return PartialView();
        }
    }
}