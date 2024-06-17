using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank_ViewModels.ResponseModal.StockRecord
{
    public class StockRecordModal
    {
        public long PartyCode { get; set; }
        public string? BranchName { get; set; }
        public string? Component { get; set; }
        public string? BloodGroup { get; set; }
        public double Qty { get; set; }
    }
}
