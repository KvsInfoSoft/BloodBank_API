using BloodBank_ViewModels.RequestModal.IssueRecordReqModal;
using BloodBank_ViewModels.ResponseModal.IssueRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank_Interfaces.InterfacesResources
{
    public interface IissueRecord
    {
        Task<List<IssueRecordModal>> GetIssueRecordsDetails(IssueRecordRequestModal requestModal);
        Task<List<IssueReasonModal>> GetIssueReasons();
    }
}
