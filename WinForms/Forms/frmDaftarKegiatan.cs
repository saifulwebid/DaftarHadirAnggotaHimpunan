using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForms.Class;

namespace WinForms.Forms
{
    public partial class frmDaftarKegiatan : Form
    {
        private BindingList<Kegiatan> daftarKegiatan = Kegiatan.GetAll();
 
        public frmDaftarKegiatan()
        {
            InitializeComponent();

            dgvKegiatan.AutoGenerateColumns = false;

            dgvKegiatan.Columns.Add("ID", "ID");
            dgvKegiatan.Columns.Add("Nama", "Nama");
            dgvKegiatan.Columns.Add("JamMulai", "Waktu Mulai");
            dgvKegiatan.Columns.Add("JamSelesai", "Waktu Selesai");

            dgvKegiatan.Columns["ID"].DataPropertyName = "ID";
            dgvKegiatan.Columns["Nama"].DataPropertyName = "Nama";
            dgvKegiatan.Columns["JamMulai"].DataPropertyName = "JamMulai";
            dgvKegiatan.Columns["JamSelesai"].DataPropertyName = "JamSelesai";

            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "";
            buttonColumn.Text = "Lihat Kehadiran";
            buttonColumn.UseColumnTextForButtonValue = true;

            dgvKegiatan.Columns.Add(buttonColumn);

            dgvKegiatan.DataSource = daftarKegiatan;
        }

        private void dgvKegiatan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (((DataGridView) sender).Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                throw new NotImplementedException();
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            frmDetilKegiatan form = new frmDetilKegiatan();
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
            {
                daftarKegiatan.Add(form.kegiatan);
            }
        }
    }
}
