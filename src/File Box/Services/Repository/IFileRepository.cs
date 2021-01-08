using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Repository
{
    public interface IFileRepository
    {
        Task<Files> GetFileByDownloadLinkAsync(string downloadLink);
    }
}
