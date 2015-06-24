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

            con.Close();
            return result;
        }

        public static void SaveAnggota(Anggota anggota)
        {
            con.Open();

            string command = "SELECT COUNT(*) AS count FROM anggota WHERE NomorAnggota=@NomorAnggota";
            SQLiteCommand cmd = new SQLiteCommand(command, con);
            cmd.Parameters.AddWithValue("NomorAnggota", anggota.NomorAnggota);

            if (Convert.ToInt32(cmd.ExecuteScalar()) == 1) // data ditemukan, lakukan perubahan
            {
                command = "UPDATE anggota SET NomorMahasiswa=@NomorMahasiswa, Kelas=@Kelas, Nama=@Nama, " +
                          "NomorHandphone=@NomorHandphone, NamaBagus=@NamaBagus, Departemen=@Departemen " +
                          "WHERE NomorAnggota=@NomorAnggota";
            }
            else // data tidak ditemukan, buat data baru
            {
                command = "INSERT INTO anggota (NomorAnggota, NomorMahasiswa, Kelas, Nama, " +
                          "NomorHandphone, NamaBagus, Departemen) VALUES (@NomorAnggota, @NomorMahasiswa, " +
                          "@Kelas, @Nama, @NomorHandphone, @NamaBagus, @Departemen)";
            }

            cmd = new SQLiteCommand(command, con);
            cmd.Parameters.AddWithValue("NomorAnggota", anggota.NomorAnggota);
            cmd.Parameters.AddWithValue("NomorMahasiswa", anggota.NomorMahasiswa);
            cmd.Parameters.AddWithValue("Kelas", anggota.Kelas);
            cmd.Parameters.AddWithValue("Nama", anggota.Nama);
            cmd.Parameters.AddWithValue("NomorHandphone", anggota.NomorHandphone);
            cmd.Parameters.AddWithValue("NamaBagus", anggota.NamaBagus);
            cmd.Parameters.AddWithValue("Departemen", anggota.Departemen);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        public static void SaveKegiatan(Kegiatan kegiatan)
        {
            con.Open();

            string command = "SELECT COUNT(*) AS count FROM kegiatan WHERE ID=@ID";
            SQLiteCommand cmd = new SQLiteCommand(command, con);
            cmd.Parameters.AddWithValue("ID", kegiatan.ID);

            if (Convert.ToInt32(cmd.ExecuteScalar()) == 1) // data ditemukan, lakukan perubahan
            {
                command = "UPDATE kegiatan SET Nama=@Nama, JamMulai=@JamMulai, JamSelesai=@JamSelesai " +
                          "WHERE ID=@ID";
            }
            else // data tidak ditemukan, buat data baru
            {
                command = "INSERT INTO kegiatan (ID, Nama, JamMulai, JamSelesai) VALUES (@ID, @Nama, " +
                          "@JamMulai, @JamSelesai)";
            }

            cmd = new SQLiteCommand(command, con);
            cmd.Parameters.AddWithValue("ID", kegiatan.ID);
            cmd.Parameters.AddWithValue("Nama", kegiatan.Nama);
            cmd.Parameters.AddWithValue("JamMulai", kegiatan.JamMulai);
            cmd.Parameters.AddWithValue("JamSelesai", kegiatan.JamSelesai);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        public static BindingList<Kehadiran> GetAllKehadiran(Kegiatan kegiatan)
        {
            BindingList<Kehadiran> result = new BindingList<Kehadiran>();
            BindingList<Anggota> anggota = GetAllAnggota();
            con.Open();

            SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM kehadiran WHERE Kegiatan=@Kegiatan", con);
            cmd.Parameters.AddWithValue("Kegiatan", kegiatan.ID);
            using (SQLiteDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    Kehadiran kehadiran = new Kehadiran();
                    kehadiran.Kegiatan = kegiatan;
                    kehadiran.Anggota = anggota.SingleOrDefault(a => a.NomorAnggota.Equals(dr["Anggota"]));
                    kehadiran.Status = (JenisKehadiran)Convert.ToInt32(dr["Status"]);
                    kehadiran.JamDatang = Convert.ToDateTime(dr["JamDatang"]);
                    kehadiran.JamPulang = Convert.ToDateTime(dr["JamPulang"]);

                    result.Add(kehadiran);
                }
            }

            con.Close();
            return result;
        }

        public static void SaveKehadiran(Kehadiran kehadiran)
        {
            con.Open();

            string command = "SELECT COUNT(*) AS count FROM kehadiran WHERE Kegiatan=@Kegiatan AND " +
                             "Anggota=@NomorAnggota";
            SQLiteCommand cmd = new SQLiteCommand(command, con);
            cmd.Parameters.AddWithValue("Kegiatan", kehadiran.Kegiatan.ID);
            cmd.Parameters.AddWithValue("NomorAnggota", kehadiran.Anggota.NomorAnggota);

            if (Convert.ToInt32(cmd.ExecuteScalar()) == 1) // data ditemukan, lakukan perubahan
            {
                command = "UPDATE kehadiran SET Status=@Status, JamDatang=@JamDatang, " +
                          "JamPulang=@JamPulang WHERE Kegiatan=@Kegiatan AND NomorAnggota=@NomorAnggota";
            }
            else // data tidak ditemukan, buat data baru
            {
                command = "INSERT INTO kehadiran (Kegiatan, Anggota, Status, JamDatang, JamPulang) " +
                          "VALUES (@Kegiatan, @Anggota, @Status, @JamDatang, @JamPulang)";
            }

            cmd = new SQLiteCommand(command, con);
            cmd.Parameters.AddWithValue("Kegiatan", kehadiran.Kegiatan.ID);
            cmd.Parameters.AddWithValue("Anggota", kehadiran.Anggota.NomorAnggota);
            cmd.Parameters.AddWithValue("Status", kehadiran.Status);
            cmd.Parameters.AddWithValue("JamDatang", kehadiran.JamDatang);
            cmd.Parameters.AddWithValue("JamPulang", kehadiran.JamPulang);

            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}
