using BloodBank_DBConfiguration.ConnectionServices;
using BloodBank_DBConfiguration.DatabaseContext;
using BloodBank_Interfaces.InterfacesResources;
using BloodBank_Utility.UtilityTools;
using BloodBank_Utility.UtilityTools.Constrains;
using BloodBank_ViewModels.RequestModal;
using BloodBank_ViewModels.RequestModal.CollectionRecord;
using BloodBank_ViewModels.ResponseModal.CollectionRecord;
using CypherUtility;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BloodBank_DBConfiguration.DatabaseContext.DbInfo;

namespace BloodBank_Repositories.RepositoriesResources.CollectionRecord
{
    public class DashboardServices : IDashboardRecord
    {
        #region Varibles
        private readonly AdoConnectionReositery _adoDBContext;
        #endregion
        #region COnstructor
        public DashboardServices(BloodBankDbInfo dbInfo)
        {
            _adoDBContext = new AdoConnectionReositery(new AdoContext(dbInfo.ConnectionString));
        }

        public async Task< List <BranchDetail>> GetBranchDetail(DashboardRequestModal recordRequestModal)
        {
            SqlParameter[] p =
           {
                new SqlParameter(SqlParameterConstrains.USERID,recordRequestModal.PartyCode) 
            };
            var ds = _adoDBContext.GetDataTable(StoreProcedureConstarins.SPGETBRANCHDETAIL, p);
            if (ds == null) return null;
            var res = ds?.ConvertDataTable<BranchDetail>();
            return res.AsEnumerable().ToList();

        }



        #endregion
        #region GetCardCount
        public async Task<DashboardModal> GetCardCount(DashboardRequestModal recordRequestModal)
        {
            SqlParameter[] p =
            {
                new SqlParameter(SqlParameterConstrains.PARTYCODE,recordRequestModal.PartyCode) ,
                new SqlParameter(SqlParameterConstrains.BRANCHCODE, recordRequestModal.BranchCode)
            };
            var ds = _adoDBContext.GetDataTable(StoreProcedureConstarins.SPGETDASHBOARDCARDCOUNT, p);
            if (ds == null) return null;
            var res = ds?.ConvertDataTable<DashboardModal>();
            return res.FirstOrDefault();
        }

        #endregion
    }
}
