using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AlpinePdf.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PdfController : ControllerBase
    {
        private readonly ILogger<PdfController> _log;

        public PdfController(ILogger<PdfController> log)
        {
            _log = log;
        }

        public IActionResult Index()
        {
            _log.LogWarning("Start to generate PDF");
            return new OkObjectResult("Successfully generated pdf");
        }
    }
}