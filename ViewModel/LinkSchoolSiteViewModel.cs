using MiniReportsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniReportsProject.ViewModel
{
    public class LinkSchoolSiteViewModel
    {
        public int GranteeID { get; set; }
        public IEnumerable<SiteModel> siteList;
        public IEnumerable<SchoolModel> schoolList;
    }
}