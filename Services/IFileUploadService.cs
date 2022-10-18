namespace Assignment_12._1.Services
{
    public interface IFileUploadService
    {
        Task<bool> UploadFile (IFormFile file);
        string FileName { get; set; }
    }
    public class FileUploadService : IFileUploadService
    {
        public string? FileName
            { get; set; }
        public async Task<bool> UploadFile (IFormFile file)
        {
            string path = "";
            try
            {
                if(file.Length > 0)
                {
                    path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "wwwroot/images"));
                    using (var fileStream = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                        this.FileName = file.FileName;
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("File copy failed", ex); 
            }
        }
    }
}
