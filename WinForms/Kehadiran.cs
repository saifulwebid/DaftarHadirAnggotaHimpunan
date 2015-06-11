using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms
{
    class Kehadiran
    {
        private int _id;
        private string _nama;
        private DateTime _jammulai;
        private DateTime _jamselesai;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nama
        {
            get { return _nama; }
            set { _nama = value; }
        }

        public DateTime JamMulai
        {
            get { return _jammulai; }
            set { _jammulai = value; }
        }

        public DateTime JamSelesai
        {
            get { return _jamselesai; }
            set { _jamselesai = value; }
        }
    }
}
