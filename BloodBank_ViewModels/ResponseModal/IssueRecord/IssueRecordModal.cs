using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank_ViewModels.ResponseModal.IssueRecord
{
    public class IssueRecordModal
    {
        public long PartyCode { get; set; }
        public string? BranchName { get; set; }
        public string? IssueDate { get; set; }
        public string? IssueComponent { get; set; }
        public string? IssueBloodGroup { get; set; }
        public string? IssueReason { get; set; }
        public double IssueQty { get; set; }

        
    }
}
