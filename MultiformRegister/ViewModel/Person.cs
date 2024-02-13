using System.ComponentModel.DataAnnotations;

namespace MultiformRegister.ViewModel
{
	public class Person : BaseEntity
	{
        [Display(Name = "نام")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "نام را وارد نمایید")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "نام خانوادگی را وارد نمایید")]
        public string LastName { get; set; }
        
        [Display(Name = "شماره تماس")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "شماره تماس را وارد نمایید")]
        public string PhoneNumber { get; set; }
    } 
}
