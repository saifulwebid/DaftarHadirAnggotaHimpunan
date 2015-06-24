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
    }
}
