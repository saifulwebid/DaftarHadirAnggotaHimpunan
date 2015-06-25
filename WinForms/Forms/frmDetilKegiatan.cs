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
    public partial class frmDetilKegiatan : Form
    {
        public Kegiatan kegiatan { get; private set; }
        
        public frmDetilKegiatan()
        {
            InitializeComponent();
            this.kegiatan = null;
            this.Text = "Kegiatan Baru";
        }

        public frmDetilKegiatan(Kegiatan kegiatan)
        {
            InitializeComponent();
            this.kegiatan = kegiatan;
            this.Text = "Ubah Kegiatan";
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (this.kegiatan == null) // Kegiatan baru
            {
                this.kegiatan = new Kegiatan();
                this.kegiatan.ID = Kegiatan.GetNextID();
                this.kegiatan.PrepareEmptyKehadiran(Anggota.GetAll());
            }

            this.kegiatan.Nama = txtNama.Text;
            this.kegiatan.JamMulai = dtpMulai.Value;
            this.kegiatan.JamSelesai = dtpSelesai.Value;
            this.kegiatan.Save();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
