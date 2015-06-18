using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class frmMain : Form
    {
        private BindingList<Anggota> _daftarAnggota = new BindingList<Anggota>();
        private Kegiatan _kegiatan;
        
        public frmMain()
        {
            InitializeComponent();
            dgvDataAnggota.DataSource = _daftarAnggota;
            dgvKehadiran.AutoGenerateColumns = false;
        }

        private void btnAddAnggota_Click(object sender, EventArgs e)
        {
            _daftarAnggota.Add(new Anggota(txtNpa.Text, txtNama.Text));
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

            foreach (Anggota anggota in _daftarAnggota)
            {
                Kehadiran kehadiran = new Kehadiran();
                kehadiran.Kegiatan = _kegiatan;
                kehadiran.Anggota = anggota;
                kehadiran.Status = JenisKehadiran.Alpa;

                _kegiatan.Kehadiran.Add(kehadiran);
            }

            dgvKehadiran.DataSource = _kegiatan.Kehadiran;
            //SetTableKehadiran();
        }

        public void SetTableKehadiran()
        {
            dgvKehadiran.AutoGenerateColumns = false;

            dgvKehadiran.Columns.Add("NIMAnggota", "NIM");
            dgvKehadiran.Columns.Add("NamaAnggota", "Nama");
            dgvKehadiran.Columns.Add("JamDatang", "Jam Datang");
            dgvKehadiran.Columns.Add("JamPulang", "Jam Pulang");
            dgvKehadiran.Columns.Add("Status", "Status");

            dgvKehadiran.Columns["NIMAnggota"].DataPropertyName = "Anggota.Nip";
            dgvKehadiran.Columns["NamaAnggota"].DataPropertyName = "Anggota.Nama";
            dgvKehadiran.Columns["JamDatang"].DataPropertyName = "JamDatang";
            dgvKehadiran.Columns["JamPulang"].DataPropertyName = "JamPulang";
            dgvKehadiran.Columns["Status"].DataPropertyName = "Status";
        }

        private void btnAbsen_Click(object sender, EventArgs e)
        {
            
            /* Masih Bugs */
            if (_kegiatan != null)
            {
                foreach (Kehadiran x in _kegiatan.Kehadiran)
                {
                    if (x.Status == JenisKehadiran.Alpa)
                    {
                        if (x.Anggota.Nip == txtNPA2.Text)
                        {
                            x.Kegiatan = _kegiatan;
                            x.JamDatang = dtpJamDatang.Value;
                            x.JamPulang = dtpJamPulang.Value;
                            x.Status = JenisKehadiran.Hadir;
                        }
                    }
                }
            }

            //PrintTable();
        }

        public void PrintTable()
        {
            dgvKehadiran.Rows.Clear();
            int i = 0;

            if (_kegiatan != null)
            {
                foreach (Kehadiran x in _kegiatan.Kehadiran)
                {
                    dgvKehadiran.Rows.Add();
                    dgvKehadiran.Rows[i].Cells[0].Value = x.Anggota.Nama;
                    dgvKehadiran.Rows[i].Cells[1].Value = x.JamDatang.TimeOfDay.ToString();
                    dgvKehadiran.Rows[i].Cells[2].Value = x.JamPulang.TimeOfDay.ToString();
                    dgvKehadiran.Rows[i].Cells[3].Value = x.Status.ToString();
                    i++;
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


    }
}
