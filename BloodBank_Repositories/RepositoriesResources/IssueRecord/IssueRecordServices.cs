using BloodBank_DBConfiguration.ConnectionServices;
using BloodBank_DBConfiguration.DatabaseContext;
using BloodBank_Interfaces.InterfacesResources;
using BloodBank_Utility.UtilityTools.Constrains;
using BloodBank_Utility.UtilityTools;
using BloodBank_ViewModels.RequestModal.IssueRecordReqModal;
using BloodBank_ViewModels.ResponseModal.DonorRecord;
using BloodBank_ViewModels.ResponseModal.IssueRecord;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BloodBank_DBConfiguration.DatabaseContext.DbInfo;

namespace BloodBank_Repositories.RepositoriesResources.IssueRecord
{
    public class IssueRecordServices : IissueRecord
    {
        private readonly AdoConnectionReositery _adoConnection;
        public IssueRecordServices(BloodBankDbInfo dbInfo)
        {
            _adoConnection = new AdoConnectionReositery(new AdoContext(dbInfo.ConnectionString));
        }

        public async Task<List<IssueReasonModal>> GetIssueReasons()
        {
            SqlParameter[] p =
                     {

                };
            var ds = _adoConnection.GetDataTable(StoreProcedureConstarins.SPGETISSUEREASON, p);
            if (ds == null) return null;
            var res = ds?.ConvertDataTable<IssueReasonModal>();
            return res.AsEnumerable().ToList();

        }

        public async Task<List<IssueRecordModal>> GetIssueRecordsDetails(IssueRecordRequestModal requestModal)
        {
            if (requestModal.IssueReason == "")
            {
                SqlParameter[] p =
               {
                new SqlParameter(SqlParameterConstrains.PARTYCODE, requestModal.PartyCode),
                 new SqlParameter(SqlParameterConstrains.BRANCHCODE, requestModal.BranchCode),
                 new SqlParameter(SqlParameterConstrains.DATEFROM, requestModal.DateFrom),
                 new SqlParameter(SqlParameterConstrains.DATETO, requestModal.DateTo)

                 };
                var ds = _adoConnection.GetDataTable(StoreProcedureConstarins.SPGETISSUERECORDDETAILSNOPARAMS, p);
                if (ds == null) return null;
                var res = ds?.ConvertDataTable<IssueRecordModal>();
                return res.AsEnumerable().ToList();
            }
            else
            {
                if (requestModal.IssueReason == "0")
                {
                    requestModal.IssueReason = "";
                }
                SqlParameter[] p =
               {
                new SqlParameter(SqlParameterConstrains.PARTYCODE, requestModal.PartyCode),
                 new SqlParameter(SqlParameterConstrains.BRANCHCODE, requestModal.BranchCode),
                 new SqlParameter(SqlParameterConstrains.ISSUEREASON, requestModal.IssueReason),
                new SqlParameter(SqlParameterConstrains.DATEFROM, requestModal.DateFrom),
                 new SqlParameter(SqlParameterConstrains.DATETO, requestModal.DateTo)
                 };
                var ds = _adoConnection.GetDataTable(StoreProcedureConstarins.SPGETISSUERECORDDETAILS, p);
                if (ds == null) return null;
                var res = ds?.ConvertDataTable<IssueRecordModal>();
                return res.AsEnumerable().ToList();
            }

        }
    }
}
