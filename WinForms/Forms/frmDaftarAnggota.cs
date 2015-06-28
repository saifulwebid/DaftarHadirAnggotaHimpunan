using OfficeOpenXml;
using OfficeOpenXml.Style;
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
using System.IO;

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

        Anggota anggota = new Anggota();
        private void btnImport_Click(object sender, EventArgs e)
        {
            if (tbFile.Text == null)
            {
                MessageBox.Show("Masukkan alamat file!!!");
                /*Jika tbFIle belum terisi*/
            }
            else{
                FileInfo newFile = new FileInfo(tbFile.Text);
                if (newFile != null)
                {
                    using (ExcelPackage package = new ExcelPackage(newFile))
                    {
                        ExcelWorkbook workBook = package.Workbook;
                        if (workBook != null)
                        {
                            ExcelWorksheet worksheet = workBook.Worksheets[1];

                            for (int i = 5; i <= worksheet.Dimension.End.Row; i++)
                            {
                                anggota.NomorAnggota = worksheet.Cells[i, 3].Text;
                                anggota.NomorMahasiswa = worksheet.Cells[i, 4].Text;
                                anggota.Nama = worksheet.Cells[i, 5].Text;
                                anggota.NamaBagus = worksheet.Cells[i, 6].Text;
                                anggota.Kelas = worksheet.Cells[i, 7].Text;
                                anggota.Departemen = worksheet.Cells[i, 8].Text;
                                anggota.NomorHandphone = worksheet.Cells[i, 9].Text;
                            }
                                try
                                {
                                    package.Save();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }

                            MessageBox.Show("Data anggota berhasil di-import.",
                                "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }
    }
}
