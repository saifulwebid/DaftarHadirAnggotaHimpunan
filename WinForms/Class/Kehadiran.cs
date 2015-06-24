using System;
using System.ComponentModel;

namespace WinForms.Class
{
    public class Kehadiran
    {
        public Kegiatan Kegiatan { get; set; }
        public Anggota Anggota { get; set; }
        public JenisKehadiran Status { get; set; }
        public DateTime JamDatang { get; set; }
        public DateTime JamPulang { get; set; }

        public static BindingList<Kehadiran> GetAll(Kegiatan kegiatan)
        {
            return SQLiteDatabase.GetAllKehadiran(kegiatan);
        }

        public void Save()
        {
            SQLiteDatabase.SaveKehadiran(this);
        }
    }
}
