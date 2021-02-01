using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FreeTime.Web.Controllers
{
    [Route("api/images")]
    public class ImagesController : BaseController
    {
        [Authorize]
        public async Task<IActionResult> Post(IFormFile file)
        {
            var imageUrl = await SaveImageAsync("files", file);
            return Ok(new { location = Path.Combine("\\files", imageUrl) });
        }


        private async Task<string> SaveImageAsync(string targetPath, IFormFile file)
        {
            const int megabyte = 1024 * 1024;

            if (!file.ContentType.StartsWith("image/"))
            {
                throw new InvalidOperationException("Invalid MIME content type.");
            }

            var extension = Path.GetExtension(file.FileName.ToLowerInvariant());
            string[] extensions = { ".gif", ".jpg", ".png", ".svg", ".webp" };
            if (!extensions.Contains(extension))
            {
                throw new InvalidOperationException("Invalid file extension.");
            }

            if (file.Length > (8 * megabyte))
            {
                throw new InvalidOperationException("Image size limit exceeded.");
            }

            var fileName = $"{Guid.NewGuid()}{extension}";
            var baseFolder = "wwwroot";
            var path = Path.Combine(Directory.GetCurrentDirectory(), baseFolder, targetPath, fileName);

            if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), baseFolder, targetPath)))
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), baseFolder, targetPath));
            using (Stream fileStream = new FileStream(path, FileMode.Create))
                await file.CopyToAsync(fileStream);

            return fileName;
        }

    }
}
