using BloodBank_ViewModels.RequestModal.CollectionRecord;
using BloodBank_ViewModels.ResponseModal.CollectionRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank_Interfaces.InterfacesResources
{
    public interface IDashboardRecord
    {
        Task<DashboardModal> GetCardCount(DashboardRequestModal recordRequestModal);
        Task< List<BranchDetail>> GetBranchDetail(DashboardRequestModal recordRequestModal);        
    }
}
