using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountTracking.Map
{
    public interface IMapper<TSource, TDestination>
    {
        TDestination Convert(TSource model);
        IList<TDestination> Convert(IList<TSource> model);
    }
}
