using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank_Interfaces.InterfacesResources
{
    public interface IADOConnectionRepository
    {
        int ExecuteData(string spName, params SqlParameter[] sqlParameters);
        DataSet GetData(string spName, params SqlParameter[] sqlParameters);
        DataTable GetDataTable(string spName, params SqlParameter[] sqlParameters);
        DataTable GetDataById(string spName, params SqlParameter[] sqlParameters);
        string GetSingleCell(string spName, params SqlParameter[] sqlParameters);
        ArrayList ExecuteDataWithOutPut(string spName, params SqlParameter[] sqlParameters);
        public Task ExecuteStoreProcedureAsync(string spName, SqlParameter[] parameters);
        public Task ExecuteStoreProcedureAsync(string spName, SqlParameter[] parameters, string connnectionString);

        public Task<List<T>> ExecuteStoreProcedureReturnListObjectAsync<T>(string storeprocedure, SqlParameter[] parameters);
        public Task<T> ExecuteStoreProcedureAndReturnObjectAsync<T>(string storeProcedure, SqlParameter[] parameters);
        public Task<DataTable> DataTableExecuteStoreProcedureAndReturnDataTableObjectAsync<T>(string storeProcedure, SqlParameter[] parameters);

    }
}
