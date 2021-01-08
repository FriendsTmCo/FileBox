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
    }
}
