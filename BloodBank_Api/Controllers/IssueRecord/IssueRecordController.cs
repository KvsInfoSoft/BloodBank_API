using BloodBank_Interfaces.InterfacesResources;
using BloodBank_Utility.UtilityTools.APIResponse;
using BloodBank_Utility.UtilityTools.Constrains;
using BloodBank_ViewModels.RequestModal.DonorRecordRequest;
using BloodBank_ViewModels.RequestModal.IssueRecordReqModal;
using BloodBank_ViewModels.ResponseModal.DonorRecord;
using BloodBank_ViewModels.ResponseModal.IssueRecord;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BloodBank_Api.Controllers.IssueRecord
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueRecordController : ControllerBase
    {
        private readonly IissueRecord _iissueRecord;
        public IssueRecordController(IissueRecord iissueRecord)
        {   
            _iissueRecord = iissueRecord;

        }

        [HttpGet("GetIssueReason")]
        public async Task<IActionResult> GetIssueReason()
        {
            ListResponse<IssueReasonModal> listResponse = new ListResponse<IssueReasonModal>();
            var res = await _iissueRecord.GetIssueReasons();
            if(res != null)
            {
                listResponse.Result = ResponseConstrains.RESULT_SUCCESS;
                listResponse.Message = ResponseConstrains.MSG_SUCCESS;
                listResponse.Data = res;
                listResponse.TotalRecords = res.Count;
                listResponse.StatusCode = (int)HttpStatusCode.OK;
            }

            return Ok(listResponse);
        }


        [HttpPost("IissueRecordDetails")]
        public async Task<IActionResult> GetIissueRecordDetails(IssueRecordRequestModal requestModal)
        {
            ListResponse<IssueRecordModal> listResponse = new ListResponse<IssueRecordModal>();
            var res = await _iissueRecord.GetIssueRecordsDetails(requestModal);
            if (res != null)
            {
                listResponse.Result = ResponseConstrains.RESULT_SUCCESS;
                listResponse.Message = ResponseConstrains.MSG_SUCCESS;
                listResponse.Data = res;
                listResponse.TotalRecords = res.Count;
                listResponse.StatusCode = (int)HttpStatusCode.OK;
            }
            return Ok(listResponse);
        }
    }
}
