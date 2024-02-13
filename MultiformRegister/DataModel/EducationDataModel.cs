using MultiformRegister.ViewModel;

namespace MultiformRegister.DataModel
{
	public class EducationDataModel : BaseEntity
	{
		public string UniversityName { get; set; }
		public Degree Degree { get; set; }
		public double Average { get; set; }

        public long PersonDataModelId { get; set; }
    }
}
