using BloodBank_DBConfiguration.ConnectionServices;
using BloodBank_DBConfiguration.DatabaseContext;
using BloodBank_Interfaces.InterfacesResources;
using BloodBank_Utility.UtilityTools;
using BloodBank_Utility.UtilityTools.Constrains;
using BloodBank_ViewModels.RequestModal;
using BloodBank_ViewModels.ResponseModal;
using CypherUtility;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BloodBank_DBConfiguration.DatabaseContext.DbInfo;

namespace BloodBank_Repositories.RepositoriesResources
{
    public class LoginServices : ILoginInterface
    {
        #region Varibles
        private readonly AdoConnectionReositery _adoDBContext;
        #endregion

        public LoginServices(BloodBankDbInfo dbInfo)
        {
            _adoDBContext = new AdoConnectionReositery(new AdoContext(dbInfo.ConnectionString));
        }

        public async Task<string> changePassword(ChangePassword changePassword)
        {
            SqlParameter[] p =
           {
                new SqlParameter(SqlParameterConstrains.USERID,changePassword.UserID) ,
                new SqlParameter(SqlParameterConstrains.PASSWORD, Cypher.Encrypt(changePassword.Password))
            };
            var ds = _adoDBContext.GetDataTable(StoreProcedureConstarins.SPCHANGEPASSWORD, p);
            var res = "";
            if (ds != null)
            {
                res = ds.Rows[0].ItemArray[0].ToString();
            }
            return res;
        }

        public async Task<ResponseLoginModal> GetUsersLogin(ReqLoginModal reqLoginModal)
        {
            SqlParameter[] p =
           {
                new SqlParameter(SqlParameterConstrains.USERID,reqLoginModal.UserID)
            };
            var ds = _adoDBContext.GetDataTable(StoreProcedureConstarins.SPGETUSERDETAIL, p);
            if (ds == null) return null;
            var res = ds.ConvertDataTable<ResponseLoginModal>();
            return res.FirstOrDefault();
        }
    }
}
