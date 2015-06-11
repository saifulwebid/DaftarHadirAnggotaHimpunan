using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms
{
    class Anggota
    {
        private string _nip;
        private string _nama;

        public string Nip
        {
            get { return _nip; }
            set { _nip = value; }
        }

        public string Nama
        {
            get { return _nama; }
            set { _nama = value; }
        }
    }
}
