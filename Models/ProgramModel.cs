using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniReportsProject.Models
{
    public class ProgramModel
    {
        public int ProgramID { get; set; }
        public string ProgramType { get; set; }
        public int SiteCount { get; set; }
        public int SchoolCount { get; set; }
    }
}