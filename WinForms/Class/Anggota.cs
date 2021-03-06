﻿using System;
using System.ComponentModel;

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

        public static BindingList<Anggota> GetAll()
        {
            return SQLiteDatabase.GetAllAnggota();
        }

        public void Save()
        {
            SQLiteDatabase.SaveAnggota(this);
        }

        public void ProsesKehadiran(Kegiatan kegiatan)
        {
            foreach (Kehadiran x in kegiatan.DaftarKehadiran)
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
                            x.Status = JenisKehadiran.Terlambat;
                        }
                    }
                    else if (x.Status == JenisKehadiran.Hadir || x.Status == JenisKehadiran.Terlambat)
                    {
                        x.JamPulang = DateTime.Now;
                    }
                }
            }

            kegiatan.DaftarKehadiran.ResetBindings();
        }
    }
}
