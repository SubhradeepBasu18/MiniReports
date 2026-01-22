using MiniReportsProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniReportsProject.Controllers
{
    public class ProgramController : Controller
    {
        ProgramDAL _programDAL = new ProgramDAL();
        // GET: Program/{program ID}
        public ActionResult Index(int id)
        {
            var SitesLinkedToCurrentProgram = _programDAL.GetAllSitesDetailsByProgramID(id);
            return View(SitesLinkedToCurrentProgram);
        }
    }
}