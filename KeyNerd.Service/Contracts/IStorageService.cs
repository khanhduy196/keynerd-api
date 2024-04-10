using Microsoft.AspNetCore.Http;

namespace KeyNerd.Service.Contracts
{
    public interface IStorageService
    {
        Task<string> UploadFile(string bucketName, IFormFile file);
        Task<IEnumerable<string>> UploadFiles(string bucketName, IEnumerable<IFormFile> files);
    }
}
