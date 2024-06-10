using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Entity.DTO;
using Product.Service.Service;

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly IManualLog manualLog;

        public LogController(IManualLog manualLog)
        {
            this.manualLog = manualLog;
        }
        [HttpPost(Name = "LogWrite")]
        public IActionResult LogWrite(ManualLogRequestDTO request)
        {
            var isSuccess = manualLog.Add(request);
            return Ok(isSuccess);

        }
    }
}
