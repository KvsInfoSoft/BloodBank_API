using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank_DBConfiguration.DatabaseContext
{
    public class AdoContext
    {
        public string ConnectionString { get; set; }

        public AdoContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        /// <summary>
        /// Globally connection get
        /// </summary>
        /// <returns></returns>
        public SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

    }
}
