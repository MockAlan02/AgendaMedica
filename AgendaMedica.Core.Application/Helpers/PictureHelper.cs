﻿using Microsoft.AspNetCore.Http;

namespace AgendaMedica.Core.Application.Helpers
{
    public static class PictureHelper
    {
        public static string UploadFile(IFormFile file, int id, string directoryName)
        {
          
            string basePath = $"/Images/{directoryName}/{id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            //create folder if not exist
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            Guid guid = Guid.NewGuid();
            var fileinfo = new FileInfo(file.FileName);
            string filename = guid + fileinfo.Extension;
            string filenameWithPath = Path.Combine(path, filename);

            using var stream = new FileStream(filenameWithPath, FileMode.Create);
            file.CopyTo(stream);

            return $"{basePath}/{filename}";
        }
    }
}
