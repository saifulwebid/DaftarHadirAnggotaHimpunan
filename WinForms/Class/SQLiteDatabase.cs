﻿using System;
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
