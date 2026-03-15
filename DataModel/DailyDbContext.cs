using Microsoft.EntityFrameworkCore;

namespace DailyAPP.WebAPI.DataModel
{
    /// <summary>
    /// 数据库上下文
    /// </summary>
    public class DailyDbContext : DbContext
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="options"></param>
        public DailyDbContext(DbContextOptions<DailyDbContext> options) : base(options)
        {

        }


        public virtual DbSet<AccountInfo> AccountInfo {  get; set; }
        public virtual DbSet<MenuInfo> MenuInfos {  get; set; }
        public virtual DbSet<WaitInfo> WaitInfos {  get; set; }
        public virtual DbSet<MemoInfo> MemoInfos {  get; set; }




    }
}
