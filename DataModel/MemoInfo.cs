using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DailyAPP.WebAPI.DataModel
{
    [Table("MemoInfo")]
    public class MemoInfo
    {
        [Key]
        public int MemoId { get; set; }
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
