namespace WinForms.Class
{
    class Anggota
    {
        private string _nip;
        private string _nama;

        public Anggota()
        {
        }

        public Anggota(string nip,string nama)
        {
            Nip = nip;
            Nama = nama;
        }
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
