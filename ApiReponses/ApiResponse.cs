namespace DailyAPP.WebAPI.ApiReponses
{
    public class ApiResponse
    {
        /// <summary>
        /// 结果编码
        /// </summary>
        public int ResultCode { get; set; }
        /// <summary>
        /// 结果信息
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 数据结果
        /// </summary>
        public object ResultData { get; set; }
    }
}
