using Microsoft.AspNetCore.Mvc;
using MultiformRegister.DataModel;
using MultiformRegister.InMemoryCache;
using MultiformRegister.ViewModel;

namespace MultiformRegister.Controllers
{
	public class HomeController : Controller
	{
		private readonly IPersonMemoryCache _personMemoryCache;
		private readonly IEducationMemoryCache _eduMemoryCache;
		private readonly IAccountMemoryCache _accountMemoryCache;
		private readonly RegisterModelDbContext _context;

		public HomeController(
			IPersonMemoryCache personMemoryCache,
			IEducationMemoryCache eduMemoryCache,
			IAccountMemoryCache accountMemoryCache,
			RegisterModelDbContext context)
		{
			_personMemoryCache = personMemoryCache;
			_eduMemoryCache = eduMemoryCache;
			_accountMemoryCache = accountMemoryCache;
			_context = context;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult AddPerson()
		{ 
			Person? person = _personMemoryCache.Get("AddPerson");
			return View(person ?? new Person());
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult AddPerson(Person model)
		{
			if (!ModelState.IsValid) return View(model);
			 
			_personMemoryCache.Set("AddPerson", model);
			return RedirectToAction(nameof(AddEducate));
		}

		public IActionResult AddEducate()
		{ 
			Education? education = _eduMemoryCache.Get("AddEdu");
			return View(education ?? new Education());
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult AddEducate(Education model)
		{
			if (!ModelState.IsValid) return View(model);
			 
			_eduMemoryCache.Set("AddEdu", model);
			return RedirectToAction(nameof(AddAccount));
		}

		public IActionResult AddAccount()
		{ 
			Account? account = _accountMemoryCache.Get("AddAccount");
			return View(account ?? new Account());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AddAccount(Account model)
		{
			if (!ModelState.IsValid) return View(model);

			await Submit(model);
			return RedirectToAction(nameof(Index));
		}


		public async Task Submit(Account model)
		{
			_accountMemoryCache.Set("AddAccount", model);

			Person? person = _personMemoryCache.Get("AddPerson");
			Account? account = _accountMemoryCache.Get("AddAccount");

			PersonDataModel personDataModel = new()
			{
				FirstName = person?.FirstName ?? "",
				LastName = person.LastName,
				PhoneNumber = person.PhoneNumber,
				UserName = account.UserName,
				Password = account.Password
			};
			_context.People.Add(personDataModel);
			await _context.SaveChangesAsync();

			Education? education = _eduMemoryCache.Get("AddEdu");

			EducationDataModel educationDataModel = new()
			{
				UniversityName = education?.UniversityName ?? "",
				Degree = education?.Degree ?? Degree.دیپلم,
				Average = education.Average,
				PersonDataModelId = personDataModel.Id
			};

			_context.Education.Add(educationDataModel);
			_context.SaveChanges(); 
		}


	}
}
