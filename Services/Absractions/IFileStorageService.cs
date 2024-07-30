namespace Lab4_Part2.Services.Absractions;

public interface IFileStorageService
{
    Task UploadFileAsync(IFormFile file, string containerName, string blobName);
    Task<byte[]> DownloadFileAsync(string containerName, string blobName);
}