using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DailyAPP.WebAPI.DataModel
{
    [Table("WaitInfo")]
    public class WaitInfo
    {
        [Key]
        public int WaitId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        /// <summary>
        /// 0-待办 1-已办
        /// </summary>
        public int Status { get; set; }

        public int AccountId { get; set; }

        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
