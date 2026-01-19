using Dapper;
using MiniReportsProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MiniReportsProject.DAL
{
    public class SchoolDAL
    {
        public List<SchoolModel> GetAllSchoolNames()
        {
            try
            {
                using (var db = DapperContext.GetConnection())
                {
                    return db.Query<SchoolModel>(
                        "sp_GetAllSchoolNames",
                        commandType: CommandType.StoredProcedure
                    ).ToList();
                }
            }
            catch (Exception err)
            {
                throw new Exception("Fetching Grantee Types Failed in catch block: " + err.Message);
            }
        }

        public int LinkSchoolToSite(int schoolId, int siteId)
        {
            try
            {
                using (var db = DapperContext.GetConnection())
                {
                    return db.Execute(
                        "sp_LinkSchoolToSite",
                        new { SchoolID = schoolId, SiteID = siteId },
                        commandType: CommandType.StoredProcedure
                    );
                }
            }
            catch (Exception err)
            {
                throw new Exception("Fetching Grantee Types Failed in catch block: " + err.Message);
            }
        }
    }
}