using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using MSPowerInfo;
using MSPowerRepo;


namespace MSPowerManager
{
    public class Job_OpeningManager
    {

        public Job_OpeningRepo _joRepo = null;

        public Job_OpeningManager()
        {
            _joRepo = new Job_OpeningRepo();
        }

        public List<Job_OpeningInfo> Get_Job_Openings(ref PaginationInfo Pager)
        {
            return _joRepo.Get_Job_Openings(ref Pager);
        }

        public Job_OpeningInfo Get_Job_Opening_By_Id(int job_opening_Id)
        {
            return _joRepo.Get_Job_Opening_By_Id(job_opening_Id);
        }

        public int Insert_Job_Opening(Job_OpeningInfo job_opening)
        {
            return _joRepo.Insert_Job_Opening(job_opening);
        }

        public void Update_Job_Opening(Job_OpeningInfo job_opening)
        {
            _joRepo.Update_Job_Opening(job_opening);
        }

    }
}
