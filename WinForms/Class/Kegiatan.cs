using System;
using System.ComponentModel;

namespace WinForms
{
    class Kegiatan
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
    }
}
