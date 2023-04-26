namespace Nite.API.Services
{
    public interface IFileServiceModel
    {
        Tuple<int, string> SaveImage(IFormFile imageFile);
    }
}
