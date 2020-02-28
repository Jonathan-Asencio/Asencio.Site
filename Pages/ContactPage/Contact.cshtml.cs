using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Asencio.WebSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Asencio.WebSite
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public ContactFormModel Contact { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            return RedirectToPage("Success");
        }
        private void SendMail(string mailbody)
        {
            using (var message = new MailMessage(Contact.Email, "jonathan.r.asencio@outlook.com"))
            {
                message.To.Add(new MailAddress("jonathan.r.asencio@outlook.com"));
                message.From = new MailAddress(Contact.Email);
                message.Subject = "New E-Mail from my website";
                message.Body = mailbody;
                using (var smtpClient = new SmtpClient("jonathan.r.asencio@outlook.com"))
                {
                    smtpClient.Send(message);
                }
            }
        }

        public void OnGet()
        {

        }
    }
}