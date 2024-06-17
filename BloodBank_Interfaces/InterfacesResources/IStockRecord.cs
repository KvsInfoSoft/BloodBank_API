using BloodBank_ViewModels.RequestModal.StockRecordReqModal;
using BloodBank_ViewModels.ResponseModal.StockRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank_Interfaces.InterfacesResources
{
    public interface IStockRecord
    {
        Task<List<StockRecordModal>> GetStockRecords(StockRecordReqestModal stockRecordReqest);
        Task<List<ComponentModal>> GetComponent();
    }
}
