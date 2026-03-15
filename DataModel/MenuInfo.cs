using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DailyAPP.WebAPI.DataModel
{
    [Table("MenuInfo")]
    public class MenuInfo
    {
        [Key]
        public int Id { get; set; }

        public string MenuIconName { get; set; }
        public string MenuName { get; set; }
        public string ViewName { get; set; }
    }
}
