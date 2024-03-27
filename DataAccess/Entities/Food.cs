using Dietary.Base;
using System.ComponentModel.DataAnnotations.Schema;
using Dietary.DataAccess.Extensions;
using Dietary.Helpers;

namespace Dietary.DataAccess.Entities
{
    public class Food : BaseEntity
    {
        public string Name { get; set; }
        public Guid IdFatSecret { get; set; }
        [ForeignKey(nameof(IdFatSecret))]
        public FatSecretFood FatSecretData { get; set; }
    }
}
