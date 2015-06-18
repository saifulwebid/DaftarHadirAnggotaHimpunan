using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class frmMain : Form
    {
        BindingList<Anggota> dataAnggota = new BindingList<Anggota>();
        List<Kehadiran> dataHadir = new List<Kehadiran>();
        
        Kegiatan kegiatan;
        
        public frmMain()
        {
            InitializeComponent();
            dgvDataAnggota.DataSource = dataAnggota;
        }

        private void btnAddAnggota_Click(object sender, EventArgs e)
        {
            Kehadiran hadir = new Kehadiran();
            Anggota anggota = new Anggota(txtNpa.Text, txtNama.Text);
            dataAnggota.Add(anggota);
            hadir.Anggota = anggota;
            hadir.Status = JenisKehadiran.Alpa;
            dataHadir.Add(hadir);
           
        }

        private void dgvDataAnggota_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            SetTableKehadiran();
        }

        private void btnAddKegiatan_Click(object sender, EventArgs e)
        {
            kegiatan = new Kegiatan(Convert.ToInt16(txtID.Text), txtNamaKegiatan.Text);
        }

        public void SetTableKehadiran()
        {
            dgvKehadiran.ColumnCount = 4;
            dgvKehadiran.Columns[0].Name = "Anggota";
            dgvKehadiran.Columns[1].Name = "Jam Datang";
            dgvKehadiran.Columns[2].Name = "Jam Pulang";
            dgvKehadiran.Columns[3].Name = "Status";
        }

        private void btnAbsen_Click(object sender, EventArgs e)
        {
            
            /* Masih Bugs */
            foreach (Kehadiran x in dataHadir)
            {
                if (x.Status == JenisKehadiran.Alpa)
                {
                    if (x.Anggota.Nip == txtNPA2.Text)
                    {
                        x.Kegiatan = kegiatan;
                        x.JamDatang = dtpJamDatang.Value;
                        x.JamPulang = dtpJamPulang.Value;
                        x.Status = JenisKehadiran.Hadir;
                    }
                }
            }

            PrintTable();
        }

        public void PrintTable()
        {
            dgvKehadiran.Rows.Clear();
            int i = 0;
            foreach (Kehadiran x in dataHadir)
            {
                dgvKehadiran.Rows.Add();
                dgvKehadiran.Rows[i].Cells[0].Value = x.Anggota.Nama;
                dgvKehadiran.Rows[i].Cells[1].Value = x.JamDatang.TimeOfDay.ToString();
                dgvKehadiran.Rows[i].Cells[2].Value = x.JamPulang.TimeOfDay.ToString();
                dgvKehadiran.Rows[i].Cells[3].Value = x.Status.ToString();
                i++;

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
