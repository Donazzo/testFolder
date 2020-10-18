using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestFolder.Models;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestFolder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListContentController : ControllerBase
    {
        private readonly FolderContext _FolderContext = new FolderContext();

        [HttpGet("{id}")]
        public string Get(string id)
        {
            FolderItem cFolder = _FolderContext.Folders.Find(id);
            if(cFolder != null)
            {
                List<FileItem> listFiles = _FolderContext.Files.Where(f => f.Folder.NameFolder.Contains(id)).ToList();
                List<FolderItem> listFolder = _FolderContext.Folders.Where(f => f.ParentFolder.NameFolder.Contains(id)).ToList();
                string jsonFiles = JsonSerializer.Serialize(listFiles);
                string jsonFolder = JsonSerializer.Serialize(listFolder);
                return JsonSerializer.Serialize<FolderItem>(cFolder);
            } else
            {
                return JsonSerializer.Serialize("problem with retrieve the current folder");
            }
        }
    }
}
