using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PDFReader.Application.Dtos.ExractPdfDataCommand;
using PDFReader.Middleware;

namespace PDFReader.Controllers
{
    [Authorization]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    public class PDFController(IMediator mediator) : Controller
    {
        private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [HttpPost("extract")]
        public async Task<IActionResult> ExtractPdfData(IFormFile pdfFile)
        {
            var request = new ExtractPdfRequestDto { PdfFile = pdfFile };
            var pdfResponse = await _mediator.Send(request);
            return Ok(pdfResponse);
        }
    }
}
