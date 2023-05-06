using CommentProject.Models.AppUserViewModels;
using CommentProject.Models.MailViewModels;
using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MimeKit;
using System.Web;



namespace CommentProject.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Index(RegisterViewModel registerViewModel)
        {
            Random rnd= new Random();
            var sayı= rnd.Next(100,1000);
            registerViewModel.ConfirmCode=sayı.ToString();
            var appUser = new AppUser()
            {
                Name = registerViewModel.Name,
                Surname = registerViewModel.Surname,
                Email = registerViewModel.UserMail,
                UserName = registerViewModel.UserName,
                AppConfirmCode=registerViewModel.ConfirmCode,
                Image="Test"
                

            };
            if (registerViewModel.UserPassword == registerViewModel.ConfirmPassword)
            {
                var result= await _userManager.CreateAsync(appUser, registerViewModel.UserPassword);
                if(result.Succeeded)
                {
                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "commentproject.34@gmail.com");
                    mimeMessage.From.Add(mailboxAddressFrom);
                    MailboxAddress mailboxAddressTo = new MailboxAddress("", registerViewModel.UserMail);
                    mimeMessage.To.Add(mailboxAddressTo);

                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = "Kodu İlgili Alana Giriniz";
                    bodyBuilder.TextBody = appUser.AppConfirmCode;
                    mimeMessage.Body = bodyBuilder.ToMessageBody();
                    mimeMessage.Subject = "Email Doğrulama";

                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Connect("smtp.gmail.com", 587, false);
                    smtpClient.Authenticate("commentproject.34@gmail.com", "zgrdswyjaainnyyh");
                    smtpClient.Send(mimeMessage);
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Şifreler Uyuşmadı");
            }
            return View();
        }
    }
}
