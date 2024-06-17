using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank_ViewModels.RequestModal.StockRecordReqModal
{
    public class StockRecordReqestModal
    {
        public int PartyCode { get; set; }
        public int BranchCode { get; set; }
        public string? Component { get; set; }
       
    }
}
