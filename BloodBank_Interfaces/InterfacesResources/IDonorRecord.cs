using BloodBank_ViewModels.RequestModal.CollectionRecord;
using BloodBank_ViewModels.RequestModal.DonorRecordRequest;
using BloodBank_ViewModels.ResponseModal.CollectionRecord;
using BloodBank_ViewModels.ResponseModal.DonorRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank_Interfaces.InterfacesResources
{
    public interface IDonorRecord
    {
        Task<List<DonorRecordModal>> GetDonorRecordsDetails(DonorRecordRequestModal requestModal);
        Task<List<DonationTypeModal>> GetDonationType();
    }
}
