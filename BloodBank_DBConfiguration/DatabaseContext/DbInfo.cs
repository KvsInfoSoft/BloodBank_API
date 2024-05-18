using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank_DBConfiguration.DatabaseContext
{
    public class DbInfo
    {
        /// <summary>
        /// add multiple db connection as per your requirent.
        /// </summary>
        public class BloodBankDbInfo
        {
            public string ConnectionString { get; }
            public BloodBankDbInfo(string connectionString) => ConnectionString = connectionString;
        }
    }
}
