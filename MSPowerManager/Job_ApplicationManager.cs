using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MSPowerInfo;
using MSPowerRepo;


namespace MSPowerManager
{
    public class Job_ApplicationManager
    {

         public Job_ApplicationRepo _jaRepo = null;

         public Job_ApplicationManager()
        {
            _jaRepo = new Job_ApplicationRepo();
        }

        public List<Job_ApplicationInfo> Get_Job_Applications(ref PaginationInfo Pager)
        {
            return _jaRepo.Get_Job_Applications(ref Pager);
        }

        public Job_ApplicationInfo Get_Job_Application_By_Id(int job_application_Id)
        {
            return _jaRepo.Get_Job_Application_By_Id(job_application_Id);
        }

        public int Insert_Job_Application(Job_ApplicationInfo job_application)
        {
            return _jaRepo.Insert_Job_Application(job_application);
        }

    }
}
