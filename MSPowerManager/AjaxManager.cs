using MSPowerInfo;
using MSPowerRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPowerManager
{
    public class AjaxManager
    {
        public AjaxRepo _ajaxRepo;

        public AjaxManager()
        {
            _ajaxRepo = new AjaxRepo();
        }

        public long Insert_Attachment(AttachmentsInfo attachment)
        {
            return _ajaxRepo.Insert_Attachment(attachment);
        }

        public void Delete_Attachment_By_Id(long attachment_Id)
        {
            _ajaxRepo.Delete_Attachment_By_Id(attachment_Id);
        }

        public List<AttachmentsInfo> Get_Attachments_By_Ref_Type_Ref_Id(int ref_Type, int ref_Id)
        {
            return _ajaxRepo.Get_Attachments_By_Ref_Type_Ref_Id(ref_Type, ref_Id);
        }

        public AttachmentsInfo Get_Attachment_By_Id(long attachment_Id)
        {
            return _ajaxRepo.Get_Attachment_By_Id(attachment_Id);
        }
    }
}
