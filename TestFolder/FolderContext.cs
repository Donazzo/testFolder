using Microsoft.EntityFrameworkCore;
using TestFolder.Models;

namespace TestFolder
{
    public class FolderContext : DbContext
    {
        public DbSet<FolderItem> Folders { get; set; }
        public DbSet<FileItem> Files { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Data Source=folders.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FolderItem>().HasKey(f => f.NameFolder);
            modelBuilder.Entity<FolderItem>().HasOne(f => f.ParentFolder);

            modelBuilder.Entity<FileItem>().HasKey(f => f.NameFile);
            modelBuilder.Entity<FileItem>().HasOne(f => f.Folder);
        }

    }
}
