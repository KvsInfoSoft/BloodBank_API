using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank_ViewModels.RequestModal.IssueRecordReqModal
{
    public class IssueRecordRequestModal
    {
        public int PartyCode { get; set; }
        public int BranchCode { get; set; }
        public string? IssueReason { get; set; }
        public string? DateTo { get; set; }
        public string? DateFrom { get; set; }
    }
}
