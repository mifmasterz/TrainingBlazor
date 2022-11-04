using Microsoft.EntityFrameworkCore;
using TrainingBlazorApp.Models;

namespace TrainingBlazorApp.Data
{
    public class MahasiswaService
    {
        MahasiswaDb db;
        public MahasiswaService(MahasiswaDb db)
        {
            this.db = db;
        }

        public List<Mahasiswa> GetAllData()
        {
            return db.Mahasiswas.ToList();
        }
        
        public IQueryable<Mahasiswa> GetAllDataQueryable()
        {
            return db.Mahasiswas.AsQueryable();
        }

        public Mahasiswa GetByNIM(string NIM)
        {
            return db.Mahasiswas.Where(x => x.NIM == NIM).FirstOrDefault();
        }

        public bool Delete(string NIM)
        {
            try
            {
                var item = db.Mahasiswas.Where(x => x.NIM == NIM).FirstOrDefault();
                db.Remove(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {ex}");
            }
            return false;
        }
        
        public bool Update(Mahasiswa data)
        {
            try
            {
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {ex}");
            }
            return false;
        }
        
        public bool Add(Mahasiswa data)
        {
            try
            {
                db.Add(data);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {ex}");
            }
            return false;
        }

        
    }
}
