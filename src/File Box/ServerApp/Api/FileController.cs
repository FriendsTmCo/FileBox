using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Repository;
using Services.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        #region ::Dependency::

        /// <summary>
        /// File Services 
        /// </summary>
        private readonly IFileRepository _file;

        public FileController(FilesServices file)
        {
            _file = file;
        }

        #endregion

        [HttpGet]
        [Route("UserFiles")]
        public async Task<IActionResult> UserFiles(int skip = 10, int take = 10)
        {
            IEnumerable<Files> files = await _file.GetUserFilesAsync(HttpContext.Request.Headers);
            return (files.Any()) ?
                Ok(new
                {
                    Id = 0,
                    Title = "Success",
                    Result = new
                    {
                        AllCount = files.Count(),
                        Response = files.Skip(skip).Take(take)
                    }
                }) :
                Ok(new
                {
                    Id = -1,
                    Title = "Not Found File Or User",
                    Result = new { }
                });
        }

        [HttpPost]
        [Route("NewFile")]
        public async Task<IActionResult> NewFile(FileviewModel file)
        {
            int result = await _file.UploadNewFileAsync(file, HttpContext.Request.Headers);

            switch (result)
            {
                case (int)FileResult.Success:
                    return Ok(new
                    {
                        Id = 0,
                        Title = "Success",
                        Result = new { }
                    });

                case (int)FileResult.Exceptions:
                    return Ok(new
                    {
                        Id = -2,
                        Title = "Exception",
                        Result = new { }
                    });

                case (int)FileResult.NullRefrenceBase64:
                    return Ok(new
                    {
                        Id = -3,
                        Title = "Null Refrence Base 64",
                        Result = new { }
                    });

                case (int)FileResult.UserNotFound:
                    return Ok(new
                    {
                        Id = -1,
                        Title = "User Not Found",
                        Result = new { }
                    });

                default:
                    goto case (int)FileResult.Exceptions;
            }
        }

        [HttpGet]
        [Route("DlFile")]
        public async Task<IActionResult> DownloadFile(string dlLink)
        {
            DownloadFileViewModel file = await _file.GetFileByDownloadLinkAsync(dlLink);
            return Ok(new
            {
                Id = 0,
                Title = "Success",
                Result = file
            });
        }
    }
}
