using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank_ViewModels.RequestModal
{
    public class ReqLoginModal
    {
        public string? UserID { get; set; }
        public string? Password { get; set; }
        public string? CaptchaId { get; set; }
        public string? CaptchaText { get; set; }

    }
}
