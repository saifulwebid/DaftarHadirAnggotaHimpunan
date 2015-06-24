﻿using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using WinForms.Class;

namespace WinForms.Forms
{
    public partial class frmMain : Form
    {
        private BindingList<Anggota> _daftarAnggota;
        public BindingList<Anggota> DaftarAnggota
        {
            get { return _daftarAnggota; }
            set
            {
                _daftarAnggota = value;
                dgvDataAnggota.DataSource = _daftarAnggota;
            }
        }
        private Kegiatan _kegiatan;
        private string result;
        
        public frmMain()
        {
            InitializeComponent();
            DaftarAnggota = SQLiteDatabase.GetAllAnggota();
            dgvKehadiran.AutoGenerateColumns = false;
        }

        private void btnAddAnggota_Click(object sender, EventArgs e)
        {
            foreach (Anggota anggota in _daftarAnggota)
            {
                anggota.Save();
            }
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
            _kegiatan.PrepareKehadiran(_daftarAnggota);

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
            if (_kegiatan != null)
            {
                foreach (Anggota anggota in _daftarAnggota)
                {
                    if (anggota.NomorAnggota.Equals(txtNPA2.Text))
                    {
                        anggota.ProsesKehadiran(_kegiatan);
                        return;
                    }
                }
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
                while ( !found && i < DaftarAnggota.Count())
                {
                    if (DaftarAnggota[i].NomorAnggota == result )
                    {
                        found = true;
                        name = DaftarAnggota[i].Nama;
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
