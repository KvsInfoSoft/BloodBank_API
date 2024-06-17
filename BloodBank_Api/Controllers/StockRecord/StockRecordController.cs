using BloodBank_Interfaces.InterfacesResources;
using BloodBank_Utility.UtilityTools.APIResponse;
using BloodBank_Utility.UtilityTools.Constrains;
using BloodBank_ViewModels.RequestModal.IssueRecordReqModal;
using BloodBank_ViewModels.RequestModal.StockRecordReqModal;
using BloodBank_ViewModels.ResponseModal.IssueRecord;
using BloodBank_ViewModels.ResponseModal.StockRecord;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BloodBank_Api.Controllers.StockRecord
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockRecordController : ControllerBase
    {
        private readonly IStockRecord _stockRecord;

        public StockRecordController(IStockRecord stockRecord)
        {
             _stockRecord= stockRecord;
        }

        [HttpGet("GetComponent")]
        public async Task<IActionResult> GetComponent()
        {
            ListResponse<ComponentModal> listResponse = new ListResponse<ComponentModal>();
            var res = await _stockRecord.GetComponent();
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

        [HttpPost("StockRecordDetails")]
        public async Task<IActionResult> GetStockRecordDetails(StockRecordReqestModal requestModal)
        {
            ListResponse<StockRecordModal> listResponse = new ListResponse<StockRecordModal>();
            var res = await _stockRecord.GetStockRecords(requestModal);
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
