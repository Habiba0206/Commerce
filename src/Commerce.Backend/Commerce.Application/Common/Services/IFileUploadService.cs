using Microsoft.AspNetCore.Http;

namespace Commerce.Application.Common.Services;

public interface IFileUploadService
{
    ValueTask<string> UploadImageAsync(IFormFile file);
}
