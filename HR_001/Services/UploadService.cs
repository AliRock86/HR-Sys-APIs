using HR_001.Entities;

namespace HR_001.Services
{
    public class UploadService
    {
        HrDbContext context = new HrDbContext();
         public void AddAttachData(int EmpId ,int TypeId ,string Desc,string Url)
         {
             var attachment = new Attachment
             {
                 AttachmentTypeId = TypeId,
                 EmployeeId = EmpId,
                 AttachmentUrl = Url,
                 Description = Desc,
                 CreatedDate = DateTime.UtcNow,
                 UpdatedDate = DateTime.UtcNow,
             };
             context.Attachments.Add(attachment);
             context.SaveChanges();
         }

        public void UpdateAttachData(int AttId ,int EmpId, int TypeId, string Desc, string Url)
        {
            if (AttId != null)
            {

                var attachment = context.Attachments.Where(a => a.Id == 1).First();

                if (attachment != null)
                {
                    attachment.AttachmentTypeId = TypeId;
                    attachment.EmployeeId = EmpId;
                    attachment.AttachmentUrl = Url;
                    attachment.Description = Desc;
                    attachment.UpdatedDate = DateTime.UtcNow;

                };
                context.SaveChanges();
            }
        }

    }
}
