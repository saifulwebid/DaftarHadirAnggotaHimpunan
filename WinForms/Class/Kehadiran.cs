using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms
{
    class Kehadiran
    {        
        public DateTime JamDatang { get; set; }
        public DateTime JamPulang { get; set; }
        public Anggota Anggota { get; set; }
        public JenisKehadiran Status { get; set; }
        public Kegiatan Kegiatan { get; set; }

        public Kehadiran(Kegiatan kegiatan, Anggota anggota, DateTime jamDatang, DateTime jamPulang, JenisKehadiran status)
        {
            Kegiatan = kegiatan;
            Anggota = anggota;
            JamDatang = jamDatang;
            JamPulang = jamPulang;
            Status = status;
        }
        public Kehadiran() { }


    }
}
