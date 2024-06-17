using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank_ViewModels.RequestModal
{
    public class ChangePassword
    {
        public int UserID { get; set; }
        public string Password { get; set; }
    }
}
