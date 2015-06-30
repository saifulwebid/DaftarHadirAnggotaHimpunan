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
            if (tbFile.Text == "")
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

                           
                            for (int i = 5; i < worksheet.Dimension.End.Row - 1; i++)
                            {
                                

                                anggota.NomorAnggota = worksheet.Cells[i, 3].Value.ToString();
                                anggota.NomorMahasiswa = worksheet.Cells[i, 4].Value.ToString();
                                anggota.Nama = worksheet.Cells[i, 5].Value.ToString();
                                anggota.NamaBagus = worksheet.Cells[i, 6].Value.ToString();
                                anggota.Kelas = worksheet.Cells[i, 7].Value.ToString();
                                anggota.Departemen = worksheet.Cells[i, 8].Value.ToString();
                                anggota.NomorHandphone = worksheet.Cells[i, 9].Value.ToString();

                                MessageBox.Show("" + anggota.Nama);
                                //massage box untuk membuktikan bahwa sebenarnya data di excel sudah terbaca
                                daftarAnggota.Add(anggota);
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
