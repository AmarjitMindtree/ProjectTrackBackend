using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountTracking.BusinessEntities
{
    public class ProjectBE
    {
        public int Id { get; set; }        
        public string Description { get; set; }

        public IList<ProjectTrackBE> ProjectTrackList { get; set; }
    }
}
