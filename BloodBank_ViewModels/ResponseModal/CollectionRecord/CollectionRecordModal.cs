using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank_ViewModels.ResponseModal.CollectionRecord
{
    public class CollectionRecordModal
    {
        public long PartyCode { get; set; }
        public string? BranchName { get; set; }
        public string? CollectionDate { get; set; }
        public string? PayMode { get; set; }
        public double BillAmount { get; set; }
        public double PaidAmount { get; set; }
        public double BalanceAmount { get; set; }
    }
}
