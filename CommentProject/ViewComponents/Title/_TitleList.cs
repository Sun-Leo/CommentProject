using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CommentProject.ViewComponents.Title
{
    public class _TitleList:ViewComponent
    {
        private readonly ITitleService _titleService;

        public _TitleList(ITitleService titleService)
        {
            _titleService = titleService;
        }

        public IViewComponentResult Invoke()
        {
            var value= _titleService.TGetList();
            return View(value);
        }
    }
}
