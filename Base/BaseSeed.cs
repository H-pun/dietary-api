using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Dietary.Helpers.FileHelper;

namespace Dietary.Base
{
    public interface IBaseSeed<TSeed> where TSeed : BaseEntity
    {
        List<TSeed> GetSeeder();
    }
}
