using Microsoft.AspNetCore.Components.Forms;

namespace Helper
{
#pragma warning disable CS0436 // Type conflicts with imported type
    public class FileUpload : IFileUpload
#pragma warning restore CS0436 // Type conflicts with imported type
    {
        private readonly IWebHostEnvironment _environment;
        public IConfiguration Configuration { get; }
        public FileUpload(IWebHostEnvironment env, IConfiguration configuration)
        {

            _environment = env;
            Configuration = configuration;
        }
        public async Task UploadSingleFileAsync(IBrowserFile selectedFile, string Filename)
        {
            var imageFolderPath = Configuration["ImageFolderPath"];
            var fileName =  Path.GetExtension(Filename);
            var filePath = Path.Combine(imageFolderPath, fileName);
            try
            {
                if (selectedFile != null)
                {
                    var path = Path.Combine(_environment.ContentRootPath, "wwwroot\\Upload", Filename);

                    var dircotry = Path.Combine(_environment.ContentRootPath, "wwwroot\\Upload");

                    bool exists = System.IO.Directory.Exists(dircotry);

                    if (!exists)
                        System.IO.Directory.CreateDirectory(dircotry);

                    bool FiLEexists = System.IO.Directory.Exists(path);
                    if (FiLEexists)
                    {
                        System.IO.Directory.Delete(path);
                    }

                    using (Stream stream = selectedFile.OpenReadStream())
                    {

                        FileStream fs = File.Create(path);
                        await stream.CopyToAsync(fs);
                        stream.Close();
                        fs.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                string Message = ex.Message;
            }
        }
        public async Task UploadMultipleAsync(IReadOnlyList<IBrowserFile> selectedFiles)
        {

            try
            {
                if (selectedFiles.Count > 0)
                {
                    foreach (var file in selectedFiles)
                    {
                        var path = Path.Combine(_environment.ContentRootPath, "wwwroot\\Upload", file.Name);
                        using (Stream stream = file.OpenReadStream())
                        {

                            FileStream fs = File.Create(path);
                            await stream.CopyToAsync(fs);
                            stream.Close();
                            fs.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string Message = ex.Message;
            }
        }
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task DeleteIDImage(string  FileName)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            var path = Path.Combine(_environment.ContentRootPath, "wwwroot\\Upload", FileName);
            bool FiLEexists = System.IO.Directory.Exists(path);
            if (FiLEexists)
            {
                System.IO.Directory.Delete(path);
            }
        }
        public async Task UploadSFSFileAsync(IFormFile selectedFile, string Filename)
        {

            try
            {
                if (selectedFile != null)
                {
                    var path = Path.Combine(_environment.ContentRootPath, "wwwroot\\Upload", Filename);

                    var dircotry = Path.Combine(_environment.ContentRootPath, "wwwroot\\Upload");

                    bool exists = System.IO.Directory.Exists(dircotry);

                    if (!exists)
                        System.IO.Directory.CreateDirectory(dircotry);

                    bool FiLEexists = System.IO.Directory.Exists(path);
                    if (FiLEexists)
                    {
                        System.IO.Directory.Delete(path);
                    }

                    using (Stream stream = selectedFile.OpenReadStream())
                    {

                        FileStream fs = File.Create(path);
                        await stream.CopyToAsync(fs);
                        stream.Close();
                        fs.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                string Message = ex.Message;
            }
        }
    }
}
