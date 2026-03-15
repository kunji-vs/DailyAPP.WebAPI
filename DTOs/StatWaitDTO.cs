namespace DailyAPP.WebAPI.DTOs
{
    public class StatWaitDTO
    {
        public int TotalCount { get; set; }

        public int FinishCount { get; set; }

        public string FinishPercent { get
            {
                if(FinishCount ==0 )
                    return "0.00%";
                return $"{(FinishCount * 100.00 / TotalCount).ToString("f2")}%";
            }
        }
    }
}
