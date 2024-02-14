using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TutorManagementSystem.Models;
using TutorManagementSystem.Models.Contact;

namespace TutorManagementSystem.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactDBContext context;

        public ContactController(ContactDBContext _Context) {
            context = _Context;
        }
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact(Contactinfo coninfo)
        {
            try
            {
                await context.Contactinfos.AddAsync(coninfo);
                await context.SaveChangesAsync();
                ModelState.Clear();
                ViewBag.SuccessMessage = "Your message has been sent. Thank you!";
               

            } catch (Exception ex) 
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
