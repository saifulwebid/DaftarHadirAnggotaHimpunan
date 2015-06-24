using System;
using System.ComponentModel;

namespace WinForms.Class
{
    public class Kegiatan
    {
        public int ID { get; set; }
        public string Nama { get; set; }
        public DateTime JamMulai { get; set; }
        public DateTime JamSelesai { get; set; }
        public BindingList<Kehadiran> Kehadiran { get; private set; }

        /** Constructor **/
        public Kegiatan()
        {
            Kehadiran = new BindingList<Kehadiran>();
        }

        public void PrepareKehadiran(BindingList<Anggota> listAnggota)
        {
            this.Kehadiran.Clear();
            
            foreach (Anggota anggota in listAnggota)
            {
                Kehadiran kehadiran = new Kehadiran();
                kehadiran.Kegiatan = this;
                kehadiran.Anggota = anggota;
                kehadiran.Status = JenisKehadiran.Alpa;

                this.Kehadiran.Add(kehadiran);
            }
        }
    }
}
