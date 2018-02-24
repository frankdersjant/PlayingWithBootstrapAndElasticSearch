
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PlayingWithBootstrap.ViewModels
{
    public class UserViewModel
    {
        [DisplayName("User Name")]
        public string UserName { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [UIHint("Boolean.cshtml")]
        public bool LikesMusic { get; set; }
    }
}