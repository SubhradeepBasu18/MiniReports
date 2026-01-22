using Dapper;
using MiniReportsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniReportsProject.DAL
{
    public class ProgramDAL
    {
        public List<ProgramModel> GetProgramData()
        {
            try
            {
                using(var db = DapperContext.GetConnection())
                {
                    return db.Query<ProgramModel>(
                        "sp_GetAllSitesByProgramID",
                        commandType: System.Data.CommandType.StoredProcedure
                    ).ToList();
                    
                }
            }
            catch (Exception err)
            {
                throw new Exception("Error in GetProgramData: " + err.Message);
            }
        }

        public List<string> GetAllSitesDetailsByProgramID(int id)
        {
            try
            {
                using (var db = DapperContext.GetConnection())
                {
                    return db.Query<string>(
                        "sp_GetAllSitesDetailsByProgramID",
                        new { ProgramID = id },
                        commandType: System.Data.CommandType.StoredProcedure
                    ).ToList();
                }
            }
            catch (Exception err)
            {
                throw new Exception("Error in GetAllSitesByProgramID: " + err.Message);
            }
        }
    }
}