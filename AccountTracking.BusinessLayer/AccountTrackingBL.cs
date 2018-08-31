using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AccountTracking.BusinessEntities;
using AccountTracking.DataAccess;
using AccountTracking.Map;
using AccountTracking.Repository;

namespace AccountTracking.BusinessLayer
{
    
    public class AccountTrackingBL : IAccountTrackingBL
    {
        IRepository<Project> projectRepository;
        IRepository<ProjectTrack> projectTrackRepository;
        IRepository<TaskQuality> taskQualityRepository;
        IRepository<DataAccess.TaskStatus> taskStatusRepository;
        IRepository<TaskDetail> taskDetailRepository;

        IMapper<Project, ProjectBE> projectMapper;
        IMapper<ProjectTrack, ProjectTrackBE> projectTrackMapper;
        IMapper<TaskQuality, TaskQualityBE> taskQualityMapper;
        IMapper<DataAccess.TaskStatus, TaskStatusBE> taskStatusMapper;
        IMapper<TaskDetailBE, TaskDetail> taskDetailMapper;
        IMapper<TaskDetail, TaskDetailBE> taskDetailsBEMapper;

        public AccountTrackingBL()
        {
            projectRepository = new Repository<Project>();
            projectTrackRepository = new Repository<ProjectTrack>();
            taskQualityRepository = new Repository<TaskQuality>();
            taskStatusRepository = new Repository<DataAccess.TaskStatus>();
            taskDetailRepository = new Repository<TaskDetail>();

            projectMapper = new Mapper<Project, ProjectBE>();
            projectTrackMapper = new Mapper<ProjectTrack, ProjectTrackBE>();
            taskQualityMapper = new Mapper<TaskQuality, TaskQualityBE>();
            taskStatusMapper = new Mapper<DataAccess.TaskStatus, TaskStatusBE>();
            taskDetailMapper = new Mapper<TaskDetailBE, TaskDetail>();
            taskDetailsBEMapper = new Mapper<TaskDetail, TaskDetailBE>();

        }
        public MasterDataBE GetMasterData()
        {
            var projects = projectRepository.GetAll().ToList();
            var projectTracks = projectTrackRepository.GetAll().ToList();
            var taskQualityList = taskQualityRepository.GetAll().ToList();
            var taskStatusList = taskStatusRepository.GetAll().ToList();

            var projectsBEList = projectMapper.Convert(projects);
            var projectTrackBEList = projectTrackMapper.Convert(projectTracks);
            var taskQualityBEList = taskQualityMapper.Convert(taskQualityList);
            var taskStatusBEList = taskStatusMapper.Convert(taskStatusList);

            if(projectsBEList != null)
            {
                foreach (var projectBE in projectsBEList)
                {
                    projectBE.ProjectTrackList = projectTrackBEList.Where(a => a.ProjectId == projectBE.Id).ToList();
                }
            }

            var masterData = new MasterDataBE() { Projects = projectsBEList, TaskQualityList = taskQualityBEList, TaskStatusList = taskStatusBEList };
            return masterData;
        }

        public ResponseFromDBBE SaveFormData(TaskDetailBE taskDetailBE)
        {
            try
            {
                 var taskDetail = taskDetailMapper.Convert(taskDetailBE);
                
                if(CheckTodaysEntry(taskDetail.EmployeeId, taskDetail.EntryDate).Status == true)
                {
                    return new ResponseFromDBBE()
                    {
                        Message = "You have already entered data for today.",
                        Status = false,
                        StatusCode = HttpStatusCode.BadRequest
                    };
                }
                 taskDetailRepository.Add(taskDetail);
                 return new ResponseFromDBBE()
                 {
                     Message = "Data submitted successfully",
                     Status = true,
                     StatusCode = HttpStatusCode.OK
                 };
            }
            catch(Exception ex)
            {
                return new ResponseFromDBBE()
                {
                    Message = ex.Message,
                    Status = false,
                    StatusCode = HttpStatusCode.BadRequest
                };
            }
        }

        public ResponseFromDBBE CheckTodaysEntry(string employeeId, DateTime entryDate)
        {
            Expression<Func<TaskDetail, bool>> expression = u => u.EmployeeId == employeeId && DateTime.Compare(u.EntryDate, entryDate) == 0; 
            IEnumerable<TaskDetail> data = taskDetailRepository.Find(expression);
            if(data.Count() == 0)
            {
                var lastSavedData = LastSavedData(employeeId);
                return new ResponseFromDBBE()
                {
                    Message = "Data not found",
                    Status = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    ResponseData = lastSavedData
                };
            }
            else
            {
                return new ResponseFromDBBE()
                {
                    Message = "Data found",
                    Status = true,
                    StatusCode = HttpStatusCode.OK
                };
            }
        }

        public TaskDetailBE LastSavedData(string employeeId)
        {
            Expression<Func<TaskDetail, bool>> expression = u => u.EmployeeId == employeeId;
            try
            {
                var  lastDetail = taskDetailsBEMapper.Convert(taskDetailRepository.Find(expression).Reverse().First());
                return lastDetail;
            }
            catch(Exception)
            {
                return null;
            }
        }
    }
}
