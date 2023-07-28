using System.IO;
using Microsoft.AspNetCore.Http;

namespace CoreWeb.Utils
{
    public class FileHelper
    {
        public static string FileLoader(IFormFile formFile, string filePath = "/Image/")
        {
            var fileName = "";

            if (formFile != null && formFile.Length > 0)
            {
                fileName = formFile.FileName;
                string directory = Directory.GetCurrentDirectory() + "/wwwroot" + filePath + fileName;

                using (var stream = new FileStream(directory, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
            }

            return fileName;
        }

        public static bool FileTerminator(string fileName, string filePath = "/Image/")
        {
            string deletedFile = Directory.GetCurrentDirectory() + "/wwwroot" + filePath + fileName;

            if (File.Exists(deletedFile))
            {
                File.Delete(deletedFile);
                return true;
            }

            return false;
        }
    }
}
