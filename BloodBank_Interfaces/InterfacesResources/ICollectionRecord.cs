using BloodBank_ViewModels.RequestModal.CollectionRecord;
using BloodBank_ViewModels.ResponseModal.CollectionRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank_Interfaces.InterfacesResources
{
    public interface ICollectionRecord
    {
        Task<List<CollectionRecordModal>> GetCollectionRecords(CollectionRecordRequestModal requestModal);
        Task<List<PayModeModal>> GetPayMode();
    }
}
