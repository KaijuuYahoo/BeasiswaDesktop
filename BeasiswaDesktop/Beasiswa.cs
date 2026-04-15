using System;

namespace BeasiswaDesktop
{
    public class Beasiswa
    {
        public int id { get; set; }
        public int nama_jenjang { get; set; } 
        public int nama_kategori { get; set; } 
        public string nama_beasiswa { get; set; }
        public string deskripsi { get; set; }
        public string jenis { get; set; }
        public DateTime tgl_buka { get; set; }
        public DateTime tgl_tutup { get; set; }
        public string link_beasiswa { get; set; }
    }
}
