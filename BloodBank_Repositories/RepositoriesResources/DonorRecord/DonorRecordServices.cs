using BloodBank_DBConfiguration.ConnectionServices;
using BloodBank_DBConfiguration.DatabaseContext;
using BloodBank_Interfaces.InterfacesResources;
using BloodBank_Utility.UtilityTools.Constrains;
using BloodBank_Utility.UtilityTools;
using BloodBank_ViewModels.RequestModal.DonorRecordRequest;
using BloodBank_ViewModels.ResponseModal.CollectionRecord;
using BloodBank_ViewModels.ResponseModal.DonorRecord;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BloodBank_DBConfiguration.DatabaseContext.DbInfo;

namespace BloodBank_Repositories.RepositoriesResources.DonorRecord
{
    public class DonorRecordServices : IDonorRecord
    {
        private readonly AdoConnectionReositery _adoConnection;
        public DonorRecordServices(BloodBankDbInfo dbInfo)
        {
            _adoConnection = new AdoConnectionReositery(new AdoContext(dbInfo.ConnectionString));
        }

        public async Task<List<DonationTypeModal>> GetDonationType()
        {
            SqlParameter[] p =
                     {

                };
            var ds = _adoConnection.GetDataTable(StoreProcedureConstarins.SPGETDONATIONTYPE, p);
            if (ds == null) return null;
            var res = ds?.ConvertDataTable<DonationTypeModal>();
            return res.AsEnumerable().ToList();
        }

        public async Task<List<DonorRecordModal>> GetDonorRecordsDetails(DonorRecordRequestModal requestModal)
        {
            if (requestModal.DonationType == "")
            {
                SqlParameter[] p =
                {
                new SqlParameter(SqlParameterConstrains.PARTYCODE, requestModal.PartyCode),
                 new SqlParameter(SqlParameterConstrains.BRANCHCODE, requestModal.BranchCode),                 
                 new SqlParameter(SqlParameterConstrains.DATEFROM, requestModal.DateFrom),
                 new SqlParameter(SqlParameterConstrains.DATETO, requestModal.DateTo)
                };
                var ds = _adoConnection.GetDataTable(StoreProcedureConstarins.SPGETDONORRECORDDETAILSNOPARAMS, p);
                if (ds == null) return null;
                var res = ds?.ConvertDataTable<DonorRecordModal>();
                return res.AsEnumerable().ToList();

            }
            else
            {
                if (requestModal.DonationType == "0")
                {
                    requestModal.DonationType = "";
                }
                SqlParameter[] p =
                {
                new SqlParameter(SqlParameterConstrains.PARTYCODE, requestModal.PartyCode),
                 new SqlParameter(SqlParameterConstrains.BRANCHCODE, requestModal.BranchCode),
                 new SqlParameter(SqlParameterConstrains.DONATIONTYPE, requestModal.DonationType),                 
                 new SqlParameter(SqlParameterConstrains.DATEFROM, requestModal.DateFrom),
                 new SqlParameter(SqlParameterConstrains.DATETO, requestModal.DateTo)
                 };
                var ds = _adoConnection.GetDataTable(StoreProcedureConstarins.SPGETDONORRECORDDETAILS, p);
                if (ds == null) return null;
                var res = ds?.ConvertDataTable<DonorRecordModal>();
                return res.AsEnumerable().ToList();
            }

        }
    }
}
