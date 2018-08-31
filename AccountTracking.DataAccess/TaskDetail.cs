using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountTracking.DataAccess
{
    public class TaskDetail
    {
        public TaskDetail()
        {

        }

        [Key]
        public int Id { get; set; }
        public DateTime EntryDate { get; set; }
        public string EmployeeId { get; set; }                
        public int ProjectTrackId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TaskStatusId { get; set; }
        public int TaskQualityId { get; set; }

        [ForeignKey("ProjectTrackId")]
        public ProjectTrack ProjectTrack { get; set; }

        [ForeignKey("TaskStatusId")]
        public TaskStatus TaskStatus { get; set; }

        [ForeignKey("TaskQualityId")]
        public TaskQuality TaskQuality { get; set; }
    }
}
