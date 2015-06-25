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
using WinForms.Class;

namespace WinForms.Forms
{
    public partial class frmDaftarKehadiran : Form
    {
        private Kegiatan kegiatan;
        private BindingList<Anggota> daftarAnggota = Anggota.GetAll(); 

        public frmDaftarKehadiran()
        {
            InitializeComponent();
        }

        public frmDaftarKehadiran(Kegiatan kegiatan)
        {
            InitializeComponent();
            this.kegiatan = kegiatan;

            dgvKehadiran.AutoGenerateColumns = false;

            dgvKehadiran.Columns.Add("NIMAnggota", "NPA");
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

            dgvKehadiran.DataSource = this.kegiatan.DaftarKehadiran;
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

        private void btnAbsen_Click(object sender, EventArgs e)
        {
            foreach (Anggota anggota in Anggota.GetAll())
            {
                if (anggota.NomorAnggota.Equals(txtNPA.Text))
                {
                    anggota.ProsesKehadiran(this.kegiatan);
                    return;
                }
            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            frmScan form = new frmScan();
            form.ShowDialog();

            if (form.GetData != null)
            {
                int i = 0;
                bool found = false;
                string name = null;
                while (!found && i < daftarAnggota.Count())
                {
                    if (daftarAnggota[i].NomorAnggota == form.GetData)
                    {
                        found = true;
                        name = daftarAnggota[i].Nama;
                    }
                    else i++;
                }
                if (found)
                {
                    //Validasi kesesuaian data dari qr code
                    if (MessageBox.Show("Apakah anda : " + name, "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        txtNPA.Text = form.GetData;
                        //Update selanjutnya : langsung mengisi daftar hadir
                    }
                }
                else
                {
                    MessageBox.Show("NPA dengan ID : " + form.GetData + " Tidak Ditemukan");
                    //Update selanjutnya : langsung buka webcam lagi untuk scan qr code
                }
            }
        }

        private void btnEkspor_Click(object sender, EventArgs e)
        {

        }
    }
}
