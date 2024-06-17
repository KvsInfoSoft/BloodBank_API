using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank_ViewModels.ResponseModal.DonorRecord
{
    public class DonorRecordModal
    {
        public long PartyCode { get; set; }
        public string? BranchName { get; set; }
        public string? DonationDate { get; set; }
        public string? DonationType { get; set; }
        public double DonationQty { get; set; }
        
    }
}
