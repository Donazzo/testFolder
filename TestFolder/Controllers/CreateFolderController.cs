using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestFolder.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestFolder.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CreateFolderController : ControllerBase
    {
        private readonly FolderContext _FolderContext = new FolderContext();

        [HttpPost]
        public void Post([FromForm] string parentFolder, [FromForm] string nameFolder)
        {
            //check if parent exist
            
            FolderItem pFolder = _FolderContext.Folders.Find(parentFolder);
            if (pFolder != null)
            {
                FolderItem nFolder = new FolderItem
                {
                    NameFolder = nameFolder,
                    ParentFolder = pFolder
                };
                _FolderContext.Folders.Add(nFolder);
                _FolderContext.SaveChanges();
            }
            else
            {
                if (parentFolder == "/")
                {
                    pFolder = new FolderItem
                    {
                        NameFolder = "/",
                        ParentFolder = null
                    };
                    _FolderContext.Folders.Add(pFolder);
                    _FolderContext.SaveChanges();
                }

            } 
        }
    }
}
