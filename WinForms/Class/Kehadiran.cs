using System;

namespace WinForms.Class
{
    public class Kehadiran
    {
        public Kegiatan Kegiatan { get; set; }
        public Anggota Anggota { get; set; }
        public JenisKehadiran Status { get; set; }
        public DateTime JamDatang { get; set; }
        public DateTime JamPulang { get; set; }

        public void Save()
        {
            SQLiteDatabase.SaveKehadiran(this);
        }
    }
}
