using System.ComponentModel.DataAnnotations;

namespace MultiformRegister.ViewModel
{
	public class Education : BaseEntity
    {
		[Display(Name = "نام دانشگاه")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "نام دانشگاه را وارد نمایید")]
        public string UniversityName { get; set; }

		[Display(Name = "مقطع تحصیلی")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "مقطع تحصیلی را انتخاب نمایید")]
		[RegularExpression(@"^[0-9]$", ErrorMessage = "مقطع تحصیلی را انتخاب نمایید")]
        public int DegreeId { get; set; }

		public Degree Degree { get; set; }

		[Display(Name = "معدل")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "معدل را وارد کنید")]
		[RegularExpression(@"^([1-9]|1[0-9]|20)$", ErrorMessage = "عددی بین 1 تا 20 وارد نمایید")]
		public double Average { get; set; }

    }


	public enum Degree
	{
		دیپلم,
		کاردانی,
		کارشناسی,
		ارشد,
		دکترا
	}
}
