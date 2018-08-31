using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountTracking.BusinessEntities
{
    public class MasterDataBE
    {
        public IList<TaskStatusBE> TaskStatusList { get; set; }
        public IList<TaskQualityBE> TaskQualityList { get; set; }
        public IList<ProjectBE> Projects { get; set; }
    }
}
