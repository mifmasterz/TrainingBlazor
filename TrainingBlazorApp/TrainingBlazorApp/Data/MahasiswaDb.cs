using Microsoft.EntityFrameworkCore;
using TrainingBlazorApp.Models;

namespace TrainingBlazorApp.Data
{
    public class MahasiswaDb : DbContext
    {
        public DbSet<Mahasiswa> Mahasiswas { get; set; }

        public string DbPath { get; }

        public MahasiswaDb()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);

            DbPath = System.IO.Path.Join(path, "/mahasiswa");
            if (!Directory.Exists(DbPath))
                Directory.CreateDirectory(DbPath);
            DbPath = System.IO.Path.Join(DbPath, "/mahasiswa.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
   
}
