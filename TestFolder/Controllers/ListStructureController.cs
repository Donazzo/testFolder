using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TestFolder.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestFolder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListStructureController : ControllerBase
    {
        private readonly FolderContext _FolderContext = new FolderContext();

        [HttpGet("{id}")]
        public string Get(string id)
        {
            string pathFolder = recursiveFolder(id,0);
            return pathFolder;
        }

        public string recursiveFolder(string id, int level)
        {
            List<FolderItem> listFolder = _FolderContext.Folders.Where(f => f.ParentFolder.NameFolder.Contains(id)).ToList();

            if(listFolder.Count() == 0)
            {
                //The Folder have no child. Return itself.
                return id;
            } else
            {
                string pathFolder = level + ":";
                level++;
                foreach(FolderItem folder in listFolder)
                {
                    pathFolder +=  recursiveFolder(folder.NameFolder, level) + ",";
                }
                return pathFolder;
            }
        }

    }
}
