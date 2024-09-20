using Azure.AI.FormRecognizer.DocumentAnalysis;
using Azure;
using MediatR;
using PDFReader.Application.Dtos.ExractPdfDataCommand;

namespace PDFReader.Application.Command.ExtractPdfDataCommand
{
    public class ExtractPdfDataHandler : IRequestHandler<ExtractPdfRequestDto, ExtractPdfResponseDto>
    {
        public ExtractPdfDataHandler()
        {
            
        }
        public async Task<ExtractPdfResponseDto> Handle(ExtractPdfRequestDto request, CancellationToken cancellationToken)
        {
            string endpoint = "<endpoint>";
            string apiKey = "<apiKey>";
            AzureKeyCredential credential = new AzureKeyCredential(apiKey);
            DocumentAnalysisClient client = new DocumentAnalysisClient(new Uri(endpoint), credential);

            string modelId = "<modelId>";
            Uri fileUri = new Uri("<fileUri>");

            AnalyzeDocumentOperation operation = await client.AnalyzeDocumentFromUriAsync(WaitUntil.Completed, modelId, fileUri);
            AnalyzeResult result = operation.Value;
            var response = new ExtractPdfResponseDto();
            return response;
        }
    }
}
