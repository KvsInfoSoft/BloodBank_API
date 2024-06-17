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
    public class DashbaordController : ControllerBase
    {
        #region variable
        private readonly IDashboardRecord _collectionRecord;
        private IConfiguration _config;
        #endregion

        #region Constructor
        public DashbaordController(IDashboardRecord collectionRecord, IConfiguration config)
        {
           _collectionRecord= collectionRecord;
            _config = config;
        }
        #endregion


        [HttpPost("GetBranchDetail")]
        public async Task<IActionResult> GetBranchDetail(DashboardRequestModal recordRequestModal)
        {
            ListResponse<BranchDetail> response = new ListResponse<BranchDetail>();

            var res = await _collectionRecord.GetBranchDetail(recordRequestModal);
            if (res != null)
            {
                response.Result = ResponseConstrains.RESULT_SUCCESS;
                response.Message = ResponseConstrains.MSG_SUCCESS;
                response.Data = res;
                response.StatusCode = (int)HttpStatusCode.OK;
            }
            return Ok(response);

        }


        #region DashboardCardCount
        [HttpPost("DashboardCardCount")]
        public async Task<IActionResult> GetDashboardCardCount(DashboardRequestModal recordRequestModal)
        {
            SingleResponse<DashboardModal> response = new SingleResponse<DashboardModal>();

            var res = await _collectionRecord.GetCardCount(recordRequestModal);
            if (res != null)
            {
                response.Result = ResponseConstrains.RESULT_SUCCESS;
                response.Message = ResponseConstrains.MSG_SUCCESS;
                response.Data = res;
                response.StatusCode = (int)HttpStatusCode.OK;
            }
            return Ok(response);
        } 
        #endregion


    }
}
