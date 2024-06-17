using BloodBank_ViewModels.RequestModal;
using BloodBank_ViewModels.ResponseModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank_Interfaces.InterfacesResources
{
    public interface ILoginInterface
    {
        Task<ResponseLoginModal> GetUsersLogin(ReqLoginModal reqLoginModal);
        Task<string> changePassword(ChangePassword changePassword);
    }
}
