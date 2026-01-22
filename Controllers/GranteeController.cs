using MiniReportsProject.DAL;
using MiniReportsProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniReportsProject.Controllers
{
    public class GranteeController : Controller
    {
        GranteeDAL _granteeDAL = new GranteeDAL();
        ProgramDAL _programDAL = new ProgramDAL();
        // GET: Grantee
        public ActionResult Index(int ID)
        {
            var SiteList = _granteeDAL.GetAllSitesByGranteeID(ID);
            string GranteeName = _granteeDAL.GetGranteeNameByID(ID);

            var ProgramData = _programDAL.GetProgramData();

            int GranteeID = ID;

            var siteViewModel = new SiteViewModel();
            siteViewModel.siteList = SiteList;
            siteViewModel.GranteeName = GranteeName;
            siteViewModel.GranteeID = GranteeID;

            siteViewModel.ProgramList = ProgramData;
            // pass the string as the model (not as a view name)
            //return View((object)GranteeName);
            return View(siteViewModel);
        }



    }
}