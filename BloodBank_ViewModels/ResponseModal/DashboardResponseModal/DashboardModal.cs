using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank_ViewModels.ResponseModal.CollectionRecord
{
    public class DashboardModal
    {
        public double TotalCollectionRecord { get; set; }
        public double TotalDonerRecord { get; set; }
        public double TotalIssuedRecord { get; set; }
        public double TotalStockRecord { get; set; }
    }

    public class BranchDetail
    {
        public string? Code { get; set; }
        public string? BranchName { get; set; }
    }
}
