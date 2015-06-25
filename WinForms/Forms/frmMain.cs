using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using WinForms.Class;

namespace WinForms.Forms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void keluarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void daftarAnggotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDaftarAnggota form = new frmDaftarAnggota();
            form.MdiParent = this;
            form.Show();
        }

        private void daftarKegiatanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDaftarKegiatan form = new frmDaftarKegiatan();
            form.MdiParent = this;
            form.Show();
        }
    }
}
