using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;



namespace TestFolder.Models
{
    public class FolderItem
    {
        
        public string NameFolder { get; set; } 
        public FolderItem ParentFolder { get; set; } 
    }
}
