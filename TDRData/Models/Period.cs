using TDR.Models;

namespace TDRData.Models
{
    public class Period : BaseModelEnum
    {
        public Period()
        {
            Users = new List<User>();
            Menus = new List<Menu>();
        }

        public ICollection<User> Users { get; set; }

        public ICollection<Menu> Menus { get; set; }
    }
}
