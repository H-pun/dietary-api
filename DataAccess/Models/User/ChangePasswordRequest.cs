using Dietary.Base;

namespace Dietary.DataAccess.Models
{
    public class ChangePasswordRequest : BaseModel
    {
        public Guid IdUser { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
