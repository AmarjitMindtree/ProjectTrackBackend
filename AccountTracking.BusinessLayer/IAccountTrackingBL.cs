using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountTracking.BusinessEntities;

namespace AccountTracking.BusinessLayer
{
    public interface IAccountTrackingBL
    {
        MasterDataBE GetMasterData();
        ResponseFromDBBE SaveFormData(TaskDetailBE taskDetailBE);
        ResponseFromDBBE CheckTodaysEntry(string empployeeId, DateTime entryDate);
        TaskDetailBE LastSavedData(string employeeId);
    }
}
