using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;

namespace CityInfo.Api.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;

        public FilesController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
        {
            _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider;
        }

        [HttpGet("{fileId}")]
        public ActionResult GetFile(string fileId)
        {
            string filePath = "ProfilePhoto.rar";

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var bytes = System.IO.File.ReadAllBytes(filePath);

            if(!_fileExtensionContentTypeProvider.TryGetContentType(filePath , out var contentType))
            {
                contentType = "application/octet-stream";
            }


            return File(bytes, contentType, Path.GetFileName(filePath));

        }
    }
}
