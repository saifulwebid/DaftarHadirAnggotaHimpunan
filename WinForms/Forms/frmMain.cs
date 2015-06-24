﻿using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using WinForms.Class;
using System.Data.SQLite;

namespace WinForms.Forms
{
    public partial class frmMain : Form
    {
        private BindingList<Anggota> _daftarAnggota = new BindingList<Anggota>();
        private Kegiatan _kegiatan;
        private string result;
        
        public frmMain()
        {
            InitializeComponent();
            dgvDataAnggota.DataSource = _daftarAnggota;
            dgvKehadiran.AutoGenerateColumns = false;

            SQLiteConnection con = new SQLiteConnection("Data Source=Database/data.db");
            SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM anggota", con);

            con.Open();
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

                    _daftarAnggota.Add(anggota);
                }
            }

            con.Close();
        }

        private void btnAddAnggota_Click(object sender, EventArgs e)
        {
            Anggota anggota = new Anggota();
            anggota.NomorAnggota = txtNpa.Text;
            anggota.Nama = txtNama.Text;
            
            _daftarAnggota.Add(anggota);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            SetTableKehadiran();
        }

        private void btnAddKegiatan_Click(object sender, EventArgs e)
        {
            _kegiatan = new Kegiatan();
            _kegiatan.ID = Convert.ToInt16(txtID.Text);
            _kegiatan.Nama = txtNamaKegiatan.Text;
            _kegiatan.JamMulai = dtpJamDatang.Value;
            _kegiatan.JamSelesai = dtpJamPulang.Value;

            foreach (Anggota anggota in _daftarAnggota)
            {
                Kehadiran kehadiran = new Kehadiran();
                kehadiran.Kegiatan = _kegiatan;
                kehadiran.Anggota = anggota;
                kehadiran.Status = JenisKehadiran.Alpa;

                _kegiatan.Kehadiran.Add(kehadiran);
            }

            dgvKehadiran.DataSource = _kegiatan.Kehadiran;
        }

        public void SetTableKehadiran()
        {
            dgvKehadiran.AutoGenerateColumns = false;

            dgvKehadiran.Columns.Add("NIMAnggota", "NIM");
            dgvKehadiran.Columns.Add("NamaAnggota", "Nama");
            dgvKehadiran.Columns.Add("JamDatang", "Jam Datang");
            dgvKehadiran.Columns.Add("JamPulang", "Jam Pulang");

            dgvKehadiran.Columns["NIMAnggota"].DataPropertyName = "Anggota.NomorAnggota";
            dgvKehadiran.Columns["NamaAnggota"].DataPropertyName = "Anggota.Nama";
            dgvKehadiran.Columns["JamDatang"].DataPropertyName = "JamDatang";
            dgvKehadiran.Columns["JamPulang"].DataPropertyName = "JamPulang";

            DataGridViewComboBoxColumn statusColumn = new DataGridViewComboBoxColumn();
            statusColumn.HeaderText = "Status Kehadiran";
            statusColumn.DataSource = Enum.GetValues(typeof (JenisKehadiran));
            statusColumn.DataPropertyName = "Status";

            dgvKehadiran.Columns.Add(statusColumn);
        }

        private void btnAbsen_Click(object sender, EventArgs e)
        {
            
            /* Masih Bugs */
            if (_kegiatan != null)
            {
                foreach (Kehadiran x in _kegiatan.Kehadiran)
                {
                    if (x.Anggota.NomorAnggota == txtNPA2.Text)
                    {
                        if (x.Status == JenisKehadiran.Alpa)
                        {
                            x.JamDatang = DateTime.Now;

                            if (x.JamDatang <= _kegiatan.JamMulai)
                            {
                                x.Status = JenisKehadiran.Hadir;
                            }
                            else
                            {
                                x.Status = JenisKehadiran.Telat;
                            }
                        }
                        else if (x.Status == JenisKehadiran.Hadir || x.Status == JenisKehadiran.Telat)
                        {
                            x.JamPulang = DateTime.Now;
                        }
                    }
                }
                
                _kegiatan.Kehadiran.ResetBindings();
            }
        }

        private void dgvKehadiran_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            DataGridViewRow row = grid.Rows[e.RowIndex];
            DataGridViewColumn col = grid.Columns[e.ColumnIndex];

            if (row.DataBoundItem != null && col.DataPropertyName.Contains("."))
            {
                string[] props = col.DataPropertyName.Split('.');
                PropertyInfo propInfo = row.DataBoundItem.GetType().GetProperty(props[0]);
                object val = propInfo.GetValue(row.DataBoundItem, null);
                for (int i = 1; i < props.Length; i++)
                {
                    propInfo = val.GetType().GetProperty(props[i]);
                    try
                    {
                        val = propInfo.GetValue(val, null);
                    }
                    catch
                    {
                        return;
                    }
                }
                e.Value = val;
            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            result = GetData();
            if (result != null)
            {
                int i = 0;
                bool found = false;
                string name = null;
                while ( !found && i < _daftarAnggota.Count())
                {
                    if (_daftarAnggota[i].NomorAnggota == result )
                    {
                        found = true;
                        name = _daftarAnggota[i].Nama;
                    }
                    else i++;
                }
                if (found)
                {
                    //Validasi kesesuaian data dari qr code
                    if (MessageBox.Show("Apakah anda : " + name, "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        txtNPA2.Text = result;
                        //Update selanjutnya : langsung mengisi daftar hadir
                    }
                }
                else
                {
                    MessageBox.Show("NPA dengan ID : " + result + " Tidak Ditemukan");
                    //Update selanjutnya : langsung buka webcam lagi untuk scan qr code
                }
                
            }

        }

        /*Membuka Form Scan dan Mengambil Isi dari Qr Code*/
        private string GetData()
        {
            frmScan FrmScan = new frmScan();
            FrmScan.ShowDialog();
            return FrmScan.GetData;
        }
    }
}
