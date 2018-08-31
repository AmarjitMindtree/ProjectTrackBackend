using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountTracking.BusinessEntities;
using AccountTracking.DataAccess;
using AutoMapper;

namespace AccountTracking.Map
{
    public class Mapper<TSource, TDestination> : IMapper<TSource, TDestination>
    {
        IMapper mapper;
        public Mapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Project, ProjectBE>().ForSourceMember(a => a.ProjectDisplayId, opt => opt.Ignore());
                cfg.CreateMap<ProjectTrack, ProjectTrackBE>();
                cfg.CreateMap<DataAccess.TaskStatus, TaskStatusBE>();
                cfg.CreateMap<TaskQuality, TaskQualityBE>();
                cfg.CreateMap<TaskDetailBE, TaskDetail>().ForMember(dest => dest.ProjectTrack, opt => opt.Ignore())
                                                         .ForMember(dest => dest.TaskQuality, opt => opt.Ignore())
                                                         .ForMember(dest => dest.TaskStatus, opt => opt.Ignore());
            });

            mapper = config.CreateMapper();
            
           
        }

        public TDestination Convert(TSource model)
        {            
            return mapper.Map<TSource, TDestination>(model);
        }

        public IList<TDestination> Convert(IList<TSource> model)
        {
            return mapper.Map<IList<TSource>, IList<TDestination>>(model);
        }
    }
}
