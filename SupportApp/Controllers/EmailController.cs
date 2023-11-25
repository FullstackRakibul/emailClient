using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupportApp.Helper;
using SupportApp.Service;

namespace SupportApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService emailService;

        public EmailController(IEmailService service) {
            this.emailService = service;
        }

        [HttpPost("sendMail")]
        public async Task<IActionResult> SendMail() {
            try {
                var mailrequest = new Mailrequest();
                mailrequest.ToEmail = "tamal.it@hameemgroup.com";
                mailrequest.Subject = "Test mail 01";
                mailrequest.Body = "This is a test mail body 01";

                if (emailService != null)
                {
                    await emailService.SendEmailAsync(mailrequest);
                    return Ok();
                }
                else {
                    return BadRequest("a Bad request");
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
