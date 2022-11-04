using System.ComponentModel.DataAnnotations;

namespace TrainingBlazorApp.Models
{
    public class Mahasiswa
    {
        public string Nama { get; set; }
        public DateTime TanggalLahir { get; set; }
        [Key]
        public string NIM { get; set; }
        public JenisKelamin Kelamin { get; set; }
        public float IPK { get; set; }
    }

    public enum JenisKelamin { Perempuan, Laki}
}
