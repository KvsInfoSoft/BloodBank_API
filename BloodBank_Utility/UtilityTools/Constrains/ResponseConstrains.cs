using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank_Utility.UtilityTools.Constrains
{
    public class ResponseConstrains
    {
        public const string RESULT_SUCCESS = "Success";
        public const string RESULT_FAIL = "Fail";

        public const string MSG_SUCCESS = "Records get successfully.";
        public const string MSG_ADD_SUCCESS = "Records add successfully.";
        public const string MSG_DELETE = "Records deleted successfully.";
        public const string MSG_DUPLICATE = "Records already exists.";
        public const string MSG_NO_DATA_FOUND = "No data found.";
        public const string UNAUTHORIZED = "unauthorized";
        public const string REQUIREDTOKENKEY = "requiredtokenkey";
        public const string REQUIRED = "Please Enter all Required field!";
    }
}
