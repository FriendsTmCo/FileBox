using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Repository
{
    public interface IFileRepository
    {
        Task<DownloadFileViewModel> GetFileByDownloadLinkAsync(string downloadLink);
        Task<int> UploadNewFileAsync(FileviewModel fileviewModel,IHeaderDictionary headers);
        Task<int> UploadNewFileAsync(FileviewModel fileviewModel,IRequestCookieCollection cookies);

        Task<IEnumerable<Files>> GetUserFilesAsync(IHeaderDictionary header);
        Task<IEnumerable<Files>> GetUserFilesAsync(IRequestCookieCollection cookies);
    }
}
