using Dietary.Base;
using System.ComponentModel.DataAnnotations.Schema;
using Dietary.DataAccess.Extensions;
using Dietary.Helpers;

namespace Dietary.DataAccess.Entities
{
    public class FoodDiary : BaseEntity
    {
        public Guid IdUser { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public DateTime AddedAt { get; set; }
        public string Status { get; set; }
        public double Calories { get; set; }
        public double MaDailyCalorie { get; set; }
        public string Feedback { get; set; }
        public string FilePath
        {
            get => _filePath;
            set => _filePath = _filePath == null ? $"{IdUser}/{File.SetFileName(value)}" : value;
        }
        [ForeignKey(nameof(IdUser))]
        public User User { get; set; }
    }
}
