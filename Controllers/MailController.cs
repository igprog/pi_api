using api.Data;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/mail")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMail _repository;

        public MailController(IMail repository)
        {
            _repository = repository;
        }
 
        [Route("~/api/mail/init")]
        [HttpGet]
        public ActionResult InitMail()
        {
            var x = new Mail();
            x.Resp = new Response();
            return Ok(x);
        }

        [Route("~/api/mail/send")]
        [HttpPost]
        public ActionResult SendMail([FromBody] Mail msg)
        {
            var x = _repository.SendMail(msg);
            return Ok(x);
        }

    }

}