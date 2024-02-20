using Microsoft.AspNetCore.Http;
using Dietary.Base;
using Dietary.DataAccess.Entities;
using Dietary.Helpers;

namespace Dietary.DataAccess.Models
{
    public class DetailUserDataResponse : BaseModel
    {
        public Guid Id { get; set; }
    }
}
