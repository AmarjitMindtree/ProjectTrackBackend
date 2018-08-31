using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountTracking.DataAccess
{
    public class ProjectTrack
    {
        public ProjectTrack()
        {

        }

        [Key]
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Description { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
    }
}
