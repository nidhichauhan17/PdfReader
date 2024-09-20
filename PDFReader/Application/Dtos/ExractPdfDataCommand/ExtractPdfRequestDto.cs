using MediatR;
using Microsoft.AspNetCore.Http;

namespace PDFReader.Application.Dtos.ExractPdfDataCommand
{
    public class ExtractPdfRequestDto : IRequest<ExtractPdfResponseDto>
    {
        public IFormFile? PdfFile { get; set; }
    }
}
