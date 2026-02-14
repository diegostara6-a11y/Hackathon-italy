using Hackathon_Bologna.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hackathon_Bologna.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult feedback()
        {
            return View();
        }
        public IActionResult faq()
        {
            return View();
        }
        public IActionResult progetti()
        {
            return View();
        }
        public IActionResult contatti()
        {
            return View();
        }

        public IActionResult team()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult InviaMessaggio(string Nome, string Cognome, string Email, string Messaggio)
        {
            try
            {
                var mail = new System.Net.Mail.MailMessage();
                mail.From = new System.Net.Mail.MailAddress("info.hackathonitaly@gmail.com");
                mail.To.Add("info.hackathonitaly@gmail.com"); // o un'altra email di destinazione
                mail.Subject = "Messaggio dal sito";
                mail.Body = $"Nome: {Nome}\nCognome: {Cognome}\nEmail: {Email}\n\nMessaggio:\n{Messaggio}";

                var smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new System.Net.NetworkCredential("info.hackathonitaly@gmail.com", "zfdo sqib swzd qwly"),
                    EnableSsl = true
                };

                smtp.Send(mail);

                return View("ConfermaInvio"); // crea una view semplice di conferma
            }
            catch (Exception ex)
            {
                return Content("Errore durante l'invio: " + ex.Message);
            }
        }

    }
}
