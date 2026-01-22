using Dapper;
using MiniReportsProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;

namespace MiniReportsProject.DAL
{
    public class SiteDAL
    {
        public int AddOrEditSite(SiteModel site)
        {
            using (var db = DapperContext.GetConnection())
            {
                return db.QuerySingle<int>(
                    "sp_InsertOrEditSite",
                    new
                    {
                        SiteID = site.SiteID,
                        SiteName = site.SiteName,
                        SiteTypeID = site.SiteTypeID,
                        Address = site.Address,
                        GrantID = site.GrantID
                    },
                    commandType: CommandType.StoredProcedure
                );
            }
        }

        public List<SchoolModel> GetAllSchoolsBySiteID(int id)
        {
            try
            {
                using (var db = DapperContext.GetConnection())
                {
                    return db.Query<SchoolModel>(
                        "sp_GetSchoolBySiteID",
                        new {
                           SiteID = id 
                        },
                        commandType: CommandType.StoredProcedure
                    ).ToList();
                }
            }
            catch (Exception err)
            {
                throw new Exception("Fetching Grantee Types Failed in catch block: " + err.Message);
            }
        }

        // new: resolve site metadata (contains GrantID)
        public SiteModel GetSiteByID(int id)
        {
            try
            {
                using (var db = DapperContext.GetConnection())
                {
                    return db.Query<SiteModel>(
                        "sp_GetSiteByID",
                        new
                        {
                            SiteID = id
                        },
                        commandType: CommandType.StoredProcedure
                    ).FirstOrDefault();
                }
            }
            catch (Exception err)
            {
                throw new Exception("Failed to fetch site by ID: " + err.Message);
            }
        }

        public int DeleteSite(int id)
        {
            try
            {
                using (var db = DapperContext.GetConnection())
                {
                    return db.Execute(
                        "sp_DeleteSiteByID",
                        new
                        {
                            SiteID = id
                        },
                        commandType: CommandType.StoredProcedure
                    );
                }
            }
            catch (Exception err)
            {
                throw new Exception("Delete Failed in catch block: " + err.Message);
            }
        }
    }
}