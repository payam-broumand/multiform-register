using System.ComponentModel.DataAnnotations;

namespace MultiformRegister.ViewModel
{
	public class Account : BaseEntity
    {
        [Display(Name = "نام کاربری")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "نام کاربری را وارد نمایید")]
        public string UserName { get; set; }

		[Display(Name = "رمز عبور")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "رمز عبور را وارد نمایید")]
		public string Password { get; set; }
    }
}
