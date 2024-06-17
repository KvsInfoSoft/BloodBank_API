using BloodBank_DBConfiguration.ConnectionServices;
using BloodBank_DBConfiguration.DatabaseContext;
using BloodBank_Interfaces.InterfacesResources;
using BloodBank_Utility.UtilityTools.Constrains;
using BloodBank_Utility.UtilityTools;
using BloodBank_ViewModels.RequestModal.StockRecordReqModal;
using BloodBank_ViewModels.ResponseModal.IssueRecord;
using BloodBank_ViewModels.ResponseModal.StockRecord;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BloodBank_DBConfiguration.DatabaseContext.DbInfo;

namespace BloodBank_Repositories.RepositoriesResources.StockRecord
{
    public class StockRecordServices:IStockRecord
    {
        private readonly AdoConnectionReositery _adoConnection;
        public StockRecordServices(BloodBankDbInfo dbInfo)
        {
            _adoConnection = new AdoConnectionReositery(new AdoContext(dbInfo.ConnectionString));

        }

        public async Task<List<ComponentModal>> GetComponent()
        {
            SqlParameter[] p =
            {

            };
            var ds = _adoConnection.GetDataTable(StoreProcedureConstarins.SPGETCOMPONENT, p);
            if (ds == null) return null;
            var res = ds?.ConvertDataTable<ComponentModal>();
            return res.AsEnumerable().ToList();
        }

        public async Task<List<StockRecordModal>> GetStockRecords(StockRecordReqestModal requestModal)
        {
            SqlParameter[] p =
         {
                new SqlParameter(SqlParameterConstrains.PARTYCODE, requestModal.PartyCode),
                 new SqlParameter(SqlParameterConstrains.BRANCHCODE, requestModal.BranchCode),
                 new SqlParameter(SqlParameterConstrains.COMPONENT, requestModal.Component)
               
            };
            var ds = _adoConnection.GetDataTable(StoreProcedureConstarins.SPGETSTOCKRECORDDETAILS, p);
            if (ds == null) return null;
            var res = ds?.ConvertDataTable<StockRecordModal>();
            return res.AsEnumerable().ToList();
        }
    }
}
