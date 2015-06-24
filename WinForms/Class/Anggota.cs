using System;

namespace WinForms.Class
{
    public class Anggota
    {
        public string NomorAnggota { get; set; }
        public string NomorMahasiswa { get; set; }
        public string Kelas { get; set; }
        public string Nama { get; set; }
        public string NomorHandphone { get; set; }
        public string NamaBagus { get; set; }
        public string Departemen { get; set; }

        public void Save()
        {
            SQLiteDatabase.SaveAnggota(this);
        }

        public void ProsesKehadiran(Kegiatan kegiatan)
        {
            foreach (Kehadiran x in kegiatan.Kehadiran)
            {
                if (x.Anggota.NomorAnggota.Equals(this.NomorAnggota))
                {
                    if (x.Status == JenisKehadiran.Alpa)
                    {
                        x.JamDatang = DateTime.Now;

                        if (x.JamDatang <= kegiatan.JamMulai)
                        {
                            x.Status = JenisKehadiran.Hadir;
                        }
                        else
                        {
                            x.Status = JenisKehadiran.Telat;
                        }
                    }
                    else if (x.Status == JenisKehadiran.Hadir || x.Status == JenisKehadiran.Telat)
                    {
                        x.JamPulang = DateTime.Now;
                    }
                }
            }

            kegiatan.Kehadiran.ResetBindings();
        }
    }
}
