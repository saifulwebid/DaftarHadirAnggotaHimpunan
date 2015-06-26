using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using OfficeOpenXml.Style;
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
            FileInfo newFile = new FileInfo(@"D:\m\DaftarHadir" + DateTime.Now.ToString("ddMMyyssmmhh") + ".xlsx");
            using (ExcelPackage package = new ExcelPackage(newFile))
            {
                ExcelWorkbook workBook = package.Workbook;
                ExcelWorksheet ws1 = workBook.Worksheets.Add("1");
                using (var rng = ws1.Cells["B4:B7"])
                {

                    rng.Style.Font.Bold = true;

                    rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(237, 237, 237));
                    rng.Style.Font.Size = 12;

                }

                ws1.View.FreezePanes(9, 4);

                ws1.Cells["B4"].Value = "ID";
                ws1.Cells["B5"].Value = "Nama Kegiatan";
                ws1.Cells["B5"].AutoFitColumns();
                ws1.Cells["B6"].Value = "Jam Mulai";
                ws1.Cells["B7"].Value = "Jam Selesai";

                ws1.Column(2).Width = 17;

                ws1.Cells["C4"].Value = kegiatan.ID;
                ws1.Cells["C5"].Value = kegiatan.Nama;
                ws1.Cells["C6"].Value = kegiatan.JamMulai;
                ws1.Cells["C6"].Style.Numberformat.Format = "dd-mm-yyyy hh:mm:ss";
                ws1.Cells["C7"].Value = kegiatan.JamSelesai;
                ws1.Cells["C7"].Style.Numberformat.Format = "dd-mm-yyyy hh:mm:ss";

                ws1.Column(3).Width = 25;
                using (var rng = ws1.Cells["D8:L8"])
                {

                    rng.Style.Font.Bold = true;


                    rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(237, 237, 237));
                    rng.Style.Font.Size = 12;

                }

                ws1.Cells["D8"].Value = "Nomor Anggota";
                ws1.Cells["E8"].Value = "Nomor Mahasiswa";
                ws1.Cells["F8"].Value = "Nama";
                ws1.Cells["G8"].Value = "Nama Bagus";
                ws1.Cells["H8"].Value = "Kelas";
                ws1.Cells["I8"].Value = "Kontak";
                ws1.Cells["J8"].Value = "Jam Datang";
                ws1.Cells["K8"].Value = "Jam Pulang";
                ws1.Cells["L8"].Value = "Status";

                ws1.Column(4).Width = 20;
                ws1.Column(5).Width = 20;
                ws1.Column(6).Width = 30;
                ws1.Column(7).Width = 30;
                ws1.Column(8).Width = 10;
                ws1.Column(9).Width = 20;
                ws1.Column(10).Width = 25;
                ws1.Column(11).Width = 25;
                ws1.Column(12).Width = 17;
                int row = 9;
                foreach (var kehadiran in kegiatan.DaftarKehadiran)
                {
                    ws1.Cells[row, 4].Value = kehadiran.Anggota.NomorAnggota;
                    ws1.Cells[row, 5].Value = kehadiran.Anggota.NomorMahasiswa;
                    ws1.Cells[row, 6].Value = kehadiran.Anggota.Nama;
                    ws1.Cells[row, 7].Value = kehadiran.Anggota.NamaBagus;
                    ws1.Cells[row, 8].Value = kehadiran.Anggota.Kelas;
                    ws1.Cells[row, 9].Value = kehadiran.Anggota.NomorHandphone;
                    ws1.Cells[row, 10].Value = kehadiran.JamDatang;
                    ws1.Cells[row, 10].Style.Numberformat.Format = "dd-mm-yyyy hh:mm:ss";
                    ws1.Cells[row, 11].Value = kehadiran.JamPulang;
                    ws1.Cells[row, 11].Style.Numberformat.Format = "dd-mm-yyyy hh:mm:ss";
                    ws1.Cells[row, 12].Value = kehadiran.Status;

                    row++;
                }

                package.Save();
            }
            newFile = new FileInfo("D:\\");
        }
    }
}
