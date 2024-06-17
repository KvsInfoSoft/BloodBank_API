using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank_ViewModels.RequestModal.CollectionRecord
{
    public class CollectionRecordRequestModal
    {
        public int PartyCode { get; set; }
        public int BranchCode { get; set; }
        public string? PayMode { get; set; }
        public string? DateTo { get; set; }
        public string? DateFrom { get; set; }
    }
}
