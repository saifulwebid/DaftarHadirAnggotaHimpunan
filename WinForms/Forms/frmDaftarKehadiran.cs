﻿using System;
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
            Anggota anggota = Anggota.GetAll().SingleOrDefault(x => x.NomorAnggota.Equals(txtNPA.Text));
            if (anggota != null)
            {
                anggota.ProsesKehadiran(this.kegiatan);
                txtNPA.Text = "";
                txtNPA.Focus();
            }
            else
            {
                MessageBox.Show("Anggota tidak ditemukan.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
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
                    if (MessageBox.Show("Apakah anda : " + name, "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        txtNPA.Text = form.GetData;
                        btnAbsen_Click(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("NPA dengan ID : " + form.GetData + " Tidak Ditemukan");
                    btnScan_Click(sender, e);
                }
            }
        }

        private void btnEkspor_Click(object sender, EventArgs e)
        {
            if (sfdSave.ShowDialog() == DialogResult.OK)
            {
                FileInfo newFile = new FileInfo(sfdSave.FileName);

                /* Jika file yang dimaksud sudah ada, maka hapus file tersebut.
                 * Hal ini untuk memastikan bahwa kita akan selalu membuat file baru.
                 */
                try
                {
                    if (newFile.Exists)
                    {
                        newFile.Delete();
                        newFile = new FileInfo(sfdSave.FileName);
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("File sedang dibuka oleh program lain.\n" +
                                    "Silakan coba simpan ke file yang lain.", "Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    return;
                }

                using (ExcelPackage package = new ExcelPackage(newFile))
                {
                    ExcelWorkbook workBook = package.Workbook;
                    ExcelWorksheet ws1 = workBook.Worksheets.Add("Report");

                    /* Header info kegiatan */
                    using (var rng = ws1.Cells["A1:A3"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(237, 237, 237));
                        rng.Style.Font.Size = 12;
                    }
                    ws1.Cells["A1"].Value = "Nama Kegiatan";
                    ws1.Cells["A2"].Value = "Jam Mulai";
                    ws1.Cells["A3"].Value = "Jam Selesai";
                    ws1.Column(1).Width = 17;

                    /* Detil info kegiatan */
                    ws1.Cells["B1"].Value = kegiatan.Nama;
                    ws1.Cells["B2"].Value = kegiatan.JamMulai;
                    ws1.Cells["B2"].Style.Numberformat.Format = "dd-mm-yyyy hh:mm:ss";
                    ws1.Cells["B3"].Value = kegiatan.JamSelesai;
                    ws1.Cells["B3"].Style.Numberformat.Format = "dd-mm-yyyy hh:mm:ss";
                    ws1.Column(2).Width = 25;

                    ws1.View.FreezePanes(4, 3);

                    /* Header list kehadiran */
                    using (var rng = ws1.Cells["C4:K4"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(237, 237, 237));
                        rng.Style.Font.Size = 12;
                    }
                    ws1.Cells["C4"].Value = "NPA";
                    ws1.Cells["D4"].Value = "NIM";
                    ws1.Cells["E4"].Value = "Nama";
                    ws1.Cells["F4"].Value = "Nama Bagus";
                    ws1.Cells["G4"].Value = "Kelas";
                    ws1.Cells["H4"].Value = "Jam Datang";
                    ws1.Cells["I4"].Value = "Jam Pulang";
                    ws1.Cells["J4"].Value = "Status";

                    ws1.Column(3).Width = 14;
                    ws1.Column(4).Width = 14;
                    ws1.Column(5).Width = 30;
                    ws1.Column(6).Width = 30;
                    ws1.Column(7).Width = 10;
                    ws1.Column(8).Width = 25;
                    ws1.Column(9).Width = 25;
                    ws1.Column(10).Width = 17;

                    /* Detil list kehadiran */
                    int row = 5;
                    foreach (var kehadiran in kegiatan.DaftarKehadiran)
                    {
                        ws1.Cells[row, 3].Value = kehadiran.Anggota.NomorAnggota;
                        ws1.Cells[row, 4].Value = kehadiran.Anggota.NomorMahasiswa;
                        ws1.Cells[row, 5].Value = kehadiran.Anggota.Nama;
                        ws1.Cells[row, 6].Value = kehadiran.Anggota.NamaBagus;
                        ws1.Cells[row, 7].Value = kehadiran.Anggota.Kelas;
                        if (!kehadiran.JamDatang.Equals(DateTime.MinValue))
                        {
                            ws1.Cells[row, 8].Value = kehadiran.JamDatang;
                            ws1.Cells[row, 8].Style.Numberformat.Format = "dd-mm-yyyy hh:mm:ss";
                        }
                        if (!kehadiran.JamPulang.Equals(DateTime.MinValue))
                        {
                            ws1.Cells[row, 9].Value = kehadiran.JamPulang;
                            ws1.Cells[row, 9].Style.Numberformat.Format = "dd-mm-yyyy hh:mm:ss";
                        }
                        ws1.Cells[row, 10].Value = kehadiran.Status;

                        row++;
                    }

                    try
                    {
                        package.Save();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    MessageBox.Show("Daftar kehadiran berhasil di-export.",
                        "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
