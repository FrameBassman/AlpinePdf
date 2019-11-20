using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AlpinePdf.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PdfController : ControllerBase
    {
        private readonly ILogger<PdfController> _log;
        private readonly IConverter _converter;

        public PdfController(ILogger<PdfController> log, IConverter converter)
        {
            _log = log;
            _converter = converter;
        }

        public IActionResult Index()
        {
            _log.LogWarning("Prepare Html for Pdf");
            var html = new HtmlToPdfDocument()
            {
                GlobalSettings =
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4
                },
                Objects =
                {
                    new ObjectSettings()
                    {
                        PagesCount = true,
                        HtmlContent = "<div>Hi!</div>",
                        WebSettings = {DefaultEncoding = "utf-8"},
                        HeaderSettings = {FontSize = 9, Right = "Page [page] of [toPage]", Line = true, Spacing = 2.812}
                    }
                }
            };
            _log.LogWarning("Start to generate PDF");
            var pdfBytes = _converter.Convert(html);
            return new OkObjectResult("Successfully generated pdf");
        }
    }
}