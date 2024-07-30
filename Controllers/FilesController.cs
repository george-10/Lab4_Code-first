using Lab4_Part2.Models;
using Lab4_Part2.Services.Absractions;
using Microsoft.AspNetCore.Mvc;

namespace Lab4_Part2.Controllers;


[Route("api/[controller]")]
[ApiController]
public class FilesController : ControllerBase
{
    private readonly IFileStorageService _fileStorageService;

    public FilesController(IFileStorageService fileStorageService)
    {
        _fileStorageService = fileStorageService;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadFile([FromForm] UploadFileDto request)
    {
        if (request.file == null || request.file.Length == 0)
            return BadRequest("File is empty or not selected");

        await _fileStorageService.UploadFileAsync(request.file,request.containerName, request.blobName);
        return Ok("File uploaded successfully");
    }

    [HttpGet("download")]
    public async Task<IActionResult> DownloadFile([FromQuery] string containerName, [FromQuery] string blobName)
    {
        byte[] fileBytes = await _fileStorageService.DownloadFileAsync(containerName, blobName);
        return File(fileBytes, "application/octet-stream", blobName);
    }
}