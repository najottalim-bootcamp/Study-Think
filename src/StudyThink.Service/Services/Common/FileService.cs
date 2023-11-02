using Microsoft.AspNetCore.Http;
using StudyThink.Service.Interfaces.Common;
using StudyThink.Service.Interfaces.Common.Helpers;

namespace StudyThink.Service.Services.Common
{
    public class FileService : IFileService
    {
        private readonly string MEDIA = "media";
        private readonly string AVATARS = "avatars";
        private readonly string IMAGES = "images";
        private readonly string ROOTPATH;
        public FileService()
        {
            ROOTPATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        }

        public async Task<bool> DeleteImageAsync(string file)
        {
            string path = Path.Combine(ROOTPATH, file);
            if (File.Exists(path))
            {
                await Task.Run(() =>
                {
                    File.Delete(path);
                });
                return true;
            }
            return false;
        }

        public async Task<byte[]> GetImageAsync(string filepath)
        {
            string path = Path.Combine(ROOTPATH, filepath);
            byte[] imageBytes = await File.ReadAllBytesAsync(path);
            return imageBytes;
        }

        public async Task<string> UploadImageAsync(IFormFile file)
        {
            string newImageName = MediaHelper.MakeImageName(file.FileName.ToLower());
            string subPath = Path.Combine(MEDIA, IMAGES, newImageName);
            string path = Path.Combine(ROOTPATH, subPath);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
                return subPath;
            }
        }
    }
}
