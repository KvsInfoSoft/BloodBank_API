using BloodBank_Interfaces.InterfacesResources;
using BloodBank_Utility.UtilityTools.APIResponse;
using BloodBank_Utility.UtilityTools.Constrains;
using BloodBank_ViewModels.RequestModal;
using BloodBank_ViewModels.ResponseModal;
using CypherUtility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;

namespace BloodBank_Api.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        #region variable
        private readonly ILoginInterface _loginInterface;
        private IConfiguration _config;
        #endregion

        #region Constructor
        public LoginController(ILoginInterface loginInterface, IConfiguration config)
        {
            _loginInterface = loginInterface;
            _config = config;
        }
        #endregion

        #region Login
        [HttpPost("UserLogin")]
        public async Task<IActionResult> GetUserLogin(ReqLoginModal userLogin)
        {
            SingleResponse<ResponseLoginModal> userLoginDetailModel = new SingleResponse<ResponseLoginModal>();

            if (ModelState.IsValid)
            {
                var res = await _loginInterface.GetUsersLogin(userLogin);
                if (res != null)
                {
                    if (userLogin.UserID == res.UserId && userLogin.Password == Cypher.Decrypt(res.Password))
                    {
                        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                        var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
                          _config["Jwt:Issuer"],
                          null,
                          expires: DateTime.Now.AddMinutes(120),
                          signingCredentials: credentials);

                        var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);    
                        
                        if(res.Password == "123")
                        {
                            userLoginDetailModel.ChangePassword = 1;
                        }

                        userLoginDetailModel.Result = ResponseConstrains.RESULT_SUCCESS;
                        userLoginDetailModel.Message = "Login Successfull!";
                        userLoginDetailModel.Data = res;
                        userLoginDetailModel.Token = token;
                        userLoginDetailModel.StatusCode = (int)HttpStatusCode.OK;

                    }
                    else
                    {
                        userLoginDetailModel.Result = ResponseConstrains.RESULT_FAIL;
                        userLoginDetailModel.Message = "UserID and Password not correct!";
                        userLoginDetailModel.StatusCode = (int)HttpStatusCode.NoContent;
                    }
                }
                else
                {
                    userLoginDetailModel.Result = ResponseConstrains.RESULT_FAIL;
                    userLoginDetailModel.Message = "UserID and Password not correct!";
                    userLoginDetailModel.StatusCode = (int)HttpStatusCode.NoContent;
                }

            }

            return Ok(userLoginDetailModel);
        }
        #endregion
        
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> GetChangePassword( ChangePassword changePassword)
        {
            SingleResponse<ChangePassword> response = new SingleResponse<ChangePassword>();
            var res = await _loginInterface.changePassword(changePassword);
            if (res != null)
            {
                response.Result = ResponseConstrains.RESULT_SUCCESS;
                response.Message = res;
                response.StatusCode = (int)HttpStatusCode.OK;
            }
            return Ok(response);           
        }

    }
}
