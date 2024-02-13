using Microsoft.EntityFrameworkCore;
using MultiformRegister.ViewModel;

namespace MultiformRegister.DataModel
{
	public class RegisterModelDbContext : DbContext
	{
        public DbSet<PersonDataModel> People { get; set; }
        public DbSet<EducationDataModel> Education { get; set; } 

        public RegisterModelDbContext(DbContextOptions<RegisterModelDbContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<PersonDataModel>()
				.HasOne(a => a.EducationDataModel)
				.WithOne()
				.HasForeignKey<EducationDataModel>(f => f.PersonDataModelId);
		}
	}
}
