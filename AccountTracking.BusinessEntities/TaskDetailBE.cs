using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountTracking.BusinessEntities
{
    public class TaskDetailBE
    {
        public int Id { get; set; }
        public DateTime EntryDate { get; set; }
        public string EmployeeId { get; set; }
        public int ProjectTrackId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TaskStatusId { get; set; }
        public int TaskQualityId { get; set; }        
    }
}
