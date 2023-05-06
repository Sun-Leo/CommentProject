using CommentProject.Models.MailViewModels;
using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace CommentProject.Controllers
{
    
    public class MailController : Controller
    {
       
        [HttpGet]
        public IActionResult SendMail()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMail(SendMailViewModel sendMailViewModel)
        {
          
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress(sendMailViewModel.Name, "commentproject.34@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", sendMailViewModel.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder= new BodyBuilder();
            bodyBuilder.TextBody= sendMailViewModel.Body;
            mimeMessage.Body=bodyBuilder.ToMessageBody();
            mimeMessage.Subject=sendMailViewModel.Subject;  

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("commentproject.34@gmail.com", "pjdwdofmuuciegil");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);
            return RedirectToAction("Index", "WriterDashboard");
        }
    }
}
