using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms.Class
{
    class SQLiteDatabase
    {
        private static SQLiteConnection con = new SQLiteConnection("Data Source=Database/data.db");

        public static BindingList<Anggota> GetAllAnggota()
        {
            BindingList<Anggota> result = new BindingList<Anggota>();
            con.Open();

            SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM anggota", con);
            using (SQLiteDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    Anggota anggota = new Anggota();
                    anggota.NomorAnggota = dr["NomorAnggota"].ToString();
                    anggota.NomorMahasiswa = dr["NomorMahasiswa"].ToString();
                    anggota.Kelas = dr["Kelas"].ToString();
                    anggota.Nama = dr["Nama"].ToString();
                    anggota.NomorHandphone = dr["NomorHandphone"].ToString();
                    anggota.NamaBagus = dr["NamaBagus"].ToString();
                    anggota.Departemen = dr["Departemen"].ToString();

                    result.Add(anggota);
                }
            }

            con.Dispose();
            return result;
        }

        public static void SaveAnggota(Anggota anggota)
        {
            con.Open();

            string command = "SELECT COUNT(*) AS count FROM anggota WHERE NomorAnggota=?";
            SQLiteCommand cmd = new SQLiteCommand(command, con);

            if ((int) cmd.ExecuteScalar() == 1) // data ditemukan, lakukan perubahan
            {
                command = "UPDATE anggota SET NomorMahasiswa=?, Kelas=?, Nama=?, NomorHandphone=?, " +
                    "NamaBagus=?, Departemen=? WHERE NomorAnggota=?";

                cmd = new SQLiteCommand(command, con);
                cmd.Parameters.Add(anggota.NomorMahasiswa);
                cmd.Parameters.Add(anggota.Kelas);
                cmd.Parameters.Add(anggota.Nama);
                cmd.Parameters.Add(anggota.NomorHandphone);
                cmd.Parameters.Add(anggota.NamaBagus);
                cmd.Parameters.Add(anggota.Departemen);
                cmd.Parameters.Add(anggota.NomorAnggota);

                cmd.ExecuteNonQuery();
            }
            else // data tidak ditemukan, buat data baru
            {
                command = "INSERT INTO anggota (NomorAnggota, NomorMahasiswa, Kelas, Nama, " +
                    "NomorHandphone, NamaBagus, Departemen) VALUES (?, ?, ?, ?, ?, ?, ?)";

                cmd = new SQLiteCommand(command, con);
                cmd.Parameters.Add(anggota.NomorAnggota);
                cmd.Parameters.Add(anggota.NomorMahasiswa);
                cmd.Parameters.Add(anggota.Kelas);
                cmd.Parameters.Add(anggota.Nama);
                cmd.Parameters.Add(anggota.NomorHandphone);
                cmd.Parameters.Add(anggota.NamaBagus);
                cmd.Parameters.Add(anggota.Departemen);

                cmd.ExecuteNonQuery();
            }

            con.Dispose();
        }
    }
}
