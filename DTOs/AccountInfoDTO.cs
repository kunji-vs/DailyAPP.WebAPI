namespace DailyAPP.WebAPI.DTOs
{
    /// <summary>
    /// 账号DTO（用来接收注册信息）
    /// </summary>
    public class AccountInfoDTO
    {
        public int AccountId { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd { get; set; }
    }
}
