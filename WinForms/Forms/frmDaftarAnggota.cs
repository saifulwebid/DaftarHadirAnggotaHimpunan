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
    public partial class frmDaftarAnggota : Form
    {
        private BindingList<Anggota> daftarAnggota = Anggota.GetAll(); 
        
        public frmDaftarAnggota()
        {
            InitializeComponent();

            dgvAnggota.DataSource = daftarAnggota;
            dgvAnggota.Columns[0].HeaderText = "NPA";
            dgvAnggota.Columns[1].HeaderText = "NIM";
            dgvAnggota.Columns[2].HeaderText = "Kelas";
            dgvAnggota.Columns[3].HeaderText = "Nama Lengkap";
            dgvAnggota.Columns[4].HeaderText = "Nomor Handphone";
            dgvAnggota.Columns[5].HeaderText = "Nama Bagus";
            dgvAnggota.Columns[6].HeaderText = "Departemen";
        }

        private void dgvAnggota_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvAnggota.IsCurrentRowDirty)
            {
                ((Anggota)dgvAnggota.Rows[e.RowIndex].DataBoundItem).Save();
            }
        }
    }
}
