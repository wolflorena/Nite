namespace Nite.API.Services
{
    public class FileServiceModel : IFileServiceModel
    {
        private readonly IWebHostEnvironment environment;
        public FileServiceModel(IWebHostEnvironment env)
        {
            environment = env;
        }

        public Tuple<int, string> SaveImage(IFormFile imageFile)
        {
            try
            {
                var contentPath = environment.ContentRootPath;

                var path = Path.Combine(contentPath, "Uploads/Images");

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                var ext = Path.GetExtension(imageFile.FileName);
                var allowedExtensions = new string[] { ".jpg", ".png", ".jpeg" };

                if (!allowedExtensions.Contains(ext))
                {
                    string msg = string.Format("Only {0} extensions are allowed", string.Join(",", allowedExtensions));
                    return new Tuple<int, string>(0, msg);
                }

                var newFileName = imageFile.FileName;
                var fileWithPath = Path.Combine(path, newFileName);
                var stream = new FileStream(fileWithPath, FileMode.Create);
                imageFile.CopyTo(stream);
                stream.Close();

                return new Tuple<int, string>(1, newFileName);
            }
            catch
            {
                return new Tuple<int, string>(0, "Error has occured");
            }
        }
    }
}
