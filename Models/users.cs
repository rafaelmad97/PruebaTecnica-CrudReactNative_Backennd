using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsApi.Models
{   
    [Table("users")]
    public class users
    {
        [Key]
        public long id { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string password { get; set; }
        public string username { get; set; }
        public string email { get; set; }

    }
}
