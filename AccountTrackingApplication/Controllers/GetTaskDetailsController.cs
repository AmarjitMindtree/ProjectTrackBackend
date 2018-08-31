using AccountTracking.BusinessEntities;
using AccountTracking.BusinessLayer;
using AccountTracking.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AccountTrackingApplication.Controllers
{    
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class GetTaskDetailsController : ApiController
    {
        private IAccountTrackingBL _accountTrackingBLObject;
        public GetTaskDetailsController()
        {
            _accountTrackingBLObject = new AccountTrackingBL();
        }

        [HttpGet]
        [ActionName("MasterData")]
        public MasterDataBE GetMasterData()
        {
            return _accountTrackingBLObject.GetMasterData();
        }

        [HttpPost]
        [ActionName("SaveData")]
        public ResponseFromDBBE SaveData([FromBody] TaskDetailBE taskDetailBE)
        {
           return _accountTrackingBLObject.SaveFormData(taskDetailBE);
        }

        [HttpGet]
        [ActionName("CheckTodaysEntry")]
        public ResponseFromDBBE CheckTodaysData(string employeeId, string entryDate)
        {
            // converting the date comming in string format
            DateTime entryDateConverted = Convert.ToDateTime(entryDate);
            return _accountTrackingBLObject.CheckTodaysEntry(employeeId, entryDateConverted);
        }
    }
}
