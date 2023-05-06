using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CommentProject.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ICategoryService _categoryService;

		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		public IActionResult Index()
		{
			var value = _categoryService.TGetList();
			return View(value);
		}
		[HttpGet]
		public IActionResult AddCategory()
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddCategory(Category category)
		{
			_categoryService.TAdd(category);
			return RedirectToAction("Index");
		}
	}
}
