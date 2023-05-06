using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CommentProject.Controllers
{
    public class TitleController : Controller
    {
        private readonly ITitleService _titleService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<AppUser> _userManager;
        

        public TitleController(ITitleService titleService, ICategoryService categoryService, UserManager<AppUser> userManager)
        {
            _titleService = titleService;
            _categoryService = categoryService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var value = _titleService.TGetList();
            return View(value);
        }
        [HttpGet]
        public async Task< IActionResult> AddTitle()
        {
            List<SelectListItem> list = (from x in _categoryService.TGetList()
                                         select new SelectListItem
                                         {
                                             Text = x.CategoryName,
                                             Value = x.CategoryID.ToString()
                                         }).ToList();
            ViewBag.v = list;
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddTitle(Title title)
        {
            var titleCreateUser = await _userManager.FindByNameAsync(User.Identity.Name);
            title.AppUserID = titleCreateUser.Id;
            _titleService.TAdd(title);
            return RedirectToAction("Index");
        }
    }
}
