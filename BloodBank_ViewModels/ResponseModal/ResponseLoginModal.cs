using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank_ViewModels.ResponseModal
{
    public class ResponseLoginModal
    {
        public int Code { get; set; }
        public int Year { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? MobileNo { get; set; }
        public string? EmailId { get; set; }
        public string? ProductName { get; set; }
        public string? UserId { get; set; }
        public string? Password { get; set; }
    }
}
