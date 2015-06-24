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
        public BindingList<Kehadiran> DaftarKehadiran { get; private set; }

        /** Constructor **/
        public Kegiatan()
        {
            DaftarKehadiran = new BindingList<Kehadiran>();
        }

        public static BindingList<Kegiatan> GetAll()
        {
            return SQLiteDatabase.GetAllKegiatan();
        }

        public void PrepareEmptyKehadiran(BindingList<Anggota> listAnggota)
        {
            this.DaftarKehadiran.Clear();
            
            foreach (Anggota anggota in listAnggota)
            {
                Kehadiran kehadiran = new Kehadiran();
                kehadiran.Kegiatan = this;
                kehadiran.Anggota = anggota;
                kehadiran.Status = JenisKehadiran.Alpa;

                this.DaftarKehadiran.Add(kehadiran);
            }
        }

        public void PrepareKehadiranFromDatabase()
        {
            this.DaftarKehadiran = Kehadiran.GetAll(this);
        }

        public void Save()
        {
            SQLiteDatabase.SaveKegiatan(this);

            foreach (Kehadiran kehadiran in DaftarKehadiran)
            {
                kehadiran.Save();
            }
        }
    }
}
