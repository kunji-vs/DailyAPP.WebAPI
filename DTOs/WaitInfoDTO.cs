namespace DailyAPP.WebAPI.DTOs
{
    public class WaitInfoDTO
    {
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
