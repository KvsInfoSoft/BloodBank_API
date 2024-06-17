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
    public class CollectionRecordServices : ICollectionRecord
    {
        private readonly AdoConnectionReositery _adoConnection;
        public CollectionRecordServices(BloodBankDbInfo dbInfo)
        {
            _adoConnection = new AdoConnectionReositery(new AdoContext(dbInfo.ConnectionString));
        }

        public async Task<List<CollectionRecordModal>> GetCollectionRecords(CollectionRecordRequestModal requestModal)
        {


            if (requestModal.PayMode == "")
            {
                SqlParameter[] p =
                    {
                new SqlParameter(SqlParameterConstrains.PARTYCODE, requestModal.PartyCode),
                 new SqlParameter(SqlParameterConstrains.BRANCHCODE, requestModal.BranchCode),
                 new SqlParameter(SqlParameterConstrains.DATEFROM, requestModal.DateFrom),
                 new SqlParameter(SqlParameterConstrains.DATETO, requestModal.DateTo)
                };
                var ds = _adoConnection.GetDataTable(StoreProcedureConstarins.SPGETCOLLECTIONRECORDDETAILSNOPARAMS, p);
                if (ds == null) return null;
                var res = ds?.ConvertDataTable<CollectionRecordModal>();
                return res.AsEnumerable().ToList();
            }
            else
            {
                if (requestModal.PayMode == "0")
                {
                    requestModal.PayMode = "";
                }

                SqlParameter[] p =
         {
                new SqlParameter(SqlParameterConstrains.PARTYCODE, requestModal.PartyCode),
                 new SqlParameter(SqlParameterConstrains.BRANCHCODE, requestModal.BranchCode),
                 new SqlParameter(SqlParameterConstrains.PAYMODE, requestModal.PayMode),
                 new SqlParameter(SqlParameterConstrains.DATEFROM, requestModal.DateFrom),
                  new SqlParameter(SqlParameterConstrains.DATETO, requestModal.DateTo)
            };
                var ds = _adoConnection.GetDataTable(StoreProcedureConstarins.SPGETCOLLECTIONRECORDDETAILS, p);
                if (ds == null) return null;
                var res = ds?.ConvertDataTable<CollectionRecordModal>();
                return res.AsEnumerable().ToList();
            }


        }

        public async Task<List<PayModeModal>> GetPayMode()
        {
            SqlParameter[] p =
                     {

                };
            var ds = _adoConnection.GetDataTable(StoreProcedureConstarins.SPGETPAYMODE, p);
            if (ds == null) return null;
            var res = ds?.ConvertDataTable<PayModeModal>();
            return res.AsEnumerable().ToList();
        }
    }
}
