using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Repository
{
    public interface IFileRepository
    {
        Task<Files> GetFileByDownloadLinkAsync(string downloadLink);
        Task<int> UploadNewFileAsync(FileviewModel fileviewModel,IHeaderDictionary headers);
    }
}
