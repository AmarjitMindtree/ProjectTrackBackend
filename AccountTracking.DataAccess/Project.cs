using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountTracking.DataAccess
{
    public class Project
    {
        public Project()
        {

        }

        [Key]
        public int Id { get; set; }
        public string ProjectDisplayId { get; set; }
        public string Description { get; set; }

    }
}
