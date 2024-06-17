using BloodBank_Interfaces.InterfacesResources;
using BloodBank_Utility.UtilityTools.APIResponse;
using BloodBank_Utility.UtilityTools.Constrains;
using BloodBank_ViewModels.RequestModal.CollectionRecord;
using BloodBank_ViewModels.ResponseModal.CollectionRecord;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BloodBank_Api.Controllers.CollectionRecord
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionRecordController : ControllerBase
    {
        public readonly ICollectionRecord _collectionRecord;
        public CollectionRecordController(ICollectionRecord collectionRecord)
        {
            _collectionRecord = collectionRecord;
        }

        [HttpGet("GetPayMode")]
        public async Task<IActionResult> GetPayMode()
        {
            ListResponse<PayModeModal> listResponse = new ListResponse<PayModeModal>();
            var res = await _collectionRecord.GetPayMode();
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



        [HttpPost("GetCollectionRecord")]
        public async Task<IActionResult> GetCollectionRecord(CollectionRecordRequestModal collectionRecord)
        {
            ListResponse<CollectionRecordModal> listResponse = new ListResponse<CollectionRecordModal>();
            var res = await _collectionRecord.GetCollectionRecords(collectionRecord);
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
