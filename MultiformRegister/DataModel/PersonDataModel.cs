using MultiformRegister.ViewModel;

namespace MultiformRegister.DataModel
{
	public class PersonDataModel : BaseEntity
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNumber { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }

        public EducationDataModel EducationDataModel { get; set; }
    }
}
