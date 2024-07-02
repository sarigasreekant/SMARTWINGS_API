using Microsoft.AspNetCore.Components.Forms;

namespace Helper
{
    public interface IFileUpload
    {

        Task UploadSingleFileAsync(IBrowserFile selectedFile, string Filename);
        Task UploadMultipleAsync(IReadOnlyList<IBrowserFile> selectedFiles);
        Task DeleteIDImage(string FileName);
        Task UploadSFSFileAsync(IFormFile selectedFile, string Filename);
    }
}
