using Framework.Shared.Enums;
using Framework.Shared.Models.File;
using Microsoft.AspNetCore.Http;

namespace Framework.Shared.Services.FileService
{
    public interface IFileService
    {
        Task<List<FileModel>> Create(List<IFormFile> files, long? maxFileSize = null, string[]? allowedExtensions = null, FileStoreOption option = FileStoreOption.Database);
        Task<FileModel> Create(IFormFile formFile, long? maxFileSize = null, string[]? allowedExtensions = null, FileStoreOption option = FileStoreOption.Database);
        Task Delete(int fileId);
        //Task Edit(int fileId, IFormFile file);
        Task<FileModel> Get(int fileId);
    }
}
