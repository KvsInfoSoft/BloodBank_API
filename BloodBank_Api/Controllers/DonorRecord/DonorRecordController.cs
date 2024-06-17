using BloodBank_Interfaces.InterfacesResources;
using BloodBank_Utility.UtilityTools.APIResponse;
using BloodBank_Utility.UtilityTools.Constrains;
using BloodBank_ViewModels.RequestModal.DonorRecordRequest;
using BloodBank_ViewModels.ResponseModal.CollectionRecord;
using BloodBank_ViewModels.ResponseModal.DonorRecord;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BloodBank_Api.Controllers.DonorRecord
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorRecordController : ControllerBase
    {
        private readonly IDonorRecord _donorRecord;
        public DonorRecordController(IDonorRecord donorRecord)
        {
            _donorRecord= donorRecord;
        }

        [HttpGet("GetDonationType")]
        public async Task<IActionResult> GetDonationType()
        {
            ListResponse<DonationTypeModal> listResponse = new ListResponse<DonationTypeModal>();
            var res = await _donorRecord.GetDonationType();
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

        [HttpPost("DonorRecordDetails")]
        public async Task<IActionResult> GetDonorRecordDetails(DonorRecordRequestModal requestModal)
        {
            ListResponse<DonorRecordModal> listResponse = new ListResponse<DonorRecordModal>();
            var res = await _donorRecord.GetDonorRecordsDetails(requestModal);
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
