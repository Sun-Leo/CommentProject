using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CommentProject.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly ITitleService _titleService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<AppUser> _userManager;

        public CommentController(ICommentService commentService, UserManager<AppUser> userManager, ITitleService titleService, ICategoryService categoryService)
        {
            _commentService = commentService;
            _userManager = userManager;
            _titleService = titleService;
            _categoryService = categoryService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<SelectListItem> value = (from x in _titleService.TGetList()
                                         select new SelectListItem
                                         {
                                             Text = x.TitleName,
                                             Value = x.TitleID.ToString()
                                         }).ToList();

            ViewBag.v = value;
            List<SelectListItem> value2 = (from x in _categoryService.TGetList()
                                          select new SelectListItem
                                          {
                                              Text = x.CategoryName,
                                              Value = x.CategoryID.ToString()
                                          }).ToList();
            ViewBag.ct=value2;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Comment comment)
        {
            comment.CommentStatus = true;
            comment.CommentDate=DateTime.Parse(DateTime.Now.ToShortDateString());
            var commentUserID = await _userManager.FindByNameAsync(User.Identity.Name);
            comment.AppUserID = commentUserID.Id;
            _commentService.TAdd(comment);
            return RedirectToAction("Index","Default");
        }
        public async Task<IActionResult> MyComments()
        {
            var commentUserId= await _userManager.FindByNameAsync(User.Identity.Name);
            var value = _commentService.TGetCommentsByUserWithTitle(commentUserId.Id);
            
            return View(value);

        }

            
      
    }
}
