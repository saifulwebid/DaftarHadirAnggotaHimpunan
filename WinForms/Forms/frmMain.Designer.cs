namespace WinForms.Forms
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtNama = new System.Windows.Forms.TextBox();
            this.txtNpa = new System.Windows.Forms.TextBox();
            this.dgvDataAnggota = new System.Windows.Forms.DataGridView();
            this.btnAddAnggota = new System.Windows.Forms.Button();
            this.txtNamaKegiatan = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.dtpJamDatang = new System.Windows.Forms.DateTimePicker();
            this.dtpJamPulang = new System.Windows.Forms.DateTimePicker();
            this.dgvKehadiran = new System.Windows.Forms.DataGridView();
            this.btnAbsen = new System.Windows.Forms.Button();
            this.txtNPA2 = new System.Windows.Forms.TextBox();
            this.btnAddKegiatan = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aplikasiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.daftarAnggotaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.daftarKegiatanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.keluarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataAnggota)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKehadiran)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(141, 70);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(179, 20);
            this.txtNama.TabIndex = 0;
            this.txtNama.Text = "Nama";
            // 
            // txtNpa
            // 
            this.txtNpa.Location = new System.Drawing.Point(141, 96);
            this.txtNpa.Name = "txtNpa";
            this.txtNpa.Size = new System.Drawing.Size(100, 20);
            this.txtNpa.TabIndex = 1;
            this.txtNpa.Text = "NPA";
            // 
            // dgvDataAnggota
            // 
            this.dgvDataAnggota.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataAnggota.Location = new System.Drawing.Point(141, 128);
            this.dgvDataAnggota.Name = "dgvDataAnggota";
            this.dgvDataAnggota.Size = new System.Drawing.Size(507, 128);
            this.dgvDataAnggota.TabIndex = 2;
            // 
            // btnAddAnggota
            // 
            this.btnAddAnggota.Location = new System.Drawing.Point(550, 262);
            this.btnAddAnggota.Name = "btnAddAnggota";
            this.btnAddAnggota.Size = new System.Drawing.Size(98, 23);
            this.btnAddAnggota.TabIndex = 3;
            this.btnAddAnggota.Text = "Add Anggota";
            this.btnAddAnggota.UseVisualStyleBackColor = true;
            this.btnAddAnggota.Click += new System.EventHandler(this.btnAddAnggota_Click);
            // 
            // txtNamaKegiatan
            // 
            this.txtNamaKegiatan.Location = new System.Drawing.Point(141, 295);
            this.txtNamaKegiatan.Name = "txtNamaKegiatan";
            this.txtNamaKegiatan.Size = new System.Drawing.Size(100, 20);
            this.txtNamaKegiatan.TabIndex = 4;
            this.txtNamaKegiatan.Text = "Nama Kegiatan";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(247, 295);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 20);
            this.txtID.TabIndex = 5;
            this.txtID.Text = "ID";
            // 
            // dtpJamDatang
            // 
            this.dtpJamDatang.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpJamDatang.Location = new System.Drawing.Point(353, 295);
            this.dtpJamDatang.Name = "dtpJamDatang";
            this.dtpJamDatang.Size = new System.Drawing.Size(96, 20);
            this.dtpJamDatang.TabIndex = 6;
            // 
            // dtpJamPulang
            // 
            this.dtpJamPulang.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpJamPulang.Location = new System.Drawing.Point(455, 295);
            this.dtpJamPulang.Name = "dtpJamPulang";
            this.dtpJamPulang.Size = new System.Drawing.Size(96, 20);
            this.dtpJamPulang.TabIndex = 7;
            // 
            // dgvKehadiran
            // 
            this.dgvKehadiran.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKehadiran.Location = new System.Drawing.Point(141, 321);
            this.dgvKehadiran.Name = "dgvKehadiran";
            this.dgvKehadiran.Size = new System.Drawing.Size(507, 128);
            this.dgvKehadiran.TabIndex = 8;
            this.dgvKehadiran.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvKehadiran_CellFormatting);
            // 
            // btnAbsen
            // 
            this.btnAbsen.Location = new System.Drawing.Point(550, 455);
            this.btnAbsen.Name = "btnAbsen";
            this.btnAbsen.Size = new System.Drawing.Size(98, 23);
            this.btnAbsen.TabIndex = 9;
            this.btnAbsen.Text = "Fill";
            this.btnAbsen.UseVisualStyleBackColor = true;
            this.btnAbsen.Click += new System.EventHandler(this.btnAbsen_Click);
            // 
            // txtNPA2
            // 
            this.txtNPA2.Location = new System.Drawing.Point(444, 457);
            this.txtNPA2.Name = "txtNPA2";
            this.txtNPA2.Size = new System.Drawing.Size(100, 20);
            this.txtNPA2.TabIndex = 10;
            this.txtNPA2.Text = "NPA";
            // 
            // btnAddKegiatan
            // 
            this.btnAddKegiatan.Location = new System.Drawing.Point(557, 293);
            this.btnAddKegiatan.Name = "btnAddKegiatan";
            this.btnAddKegiatan.Size = new System.Drawing.Size(91, 23);
            this.btnAddKegiatan.TabIndex = 11;
            this.btnAddKegiatan.Text = "Add Kegiatan";
            this.btnAddKegiatan.UseVisualStyleBackColor = true;
            this.btnAddKegiatan.Click += new System.EventHandler(this.btnAddKegiatan_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(141, 454);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 12;
            this.btnExport.Text = "Export ke Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(222, 454);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(88, 23);
            this.btnScan.TabIndex = 13;
            this.btnScan.Text = "Scan ID Card";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aplikasiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(664, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aplikasiToolStripMenuItem
            // 
            this.aplikasiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.daftarAnggotaToolStripMenuItem,
            this.daftarKegiatanToolStripMenuItem,
            this.toolStripSeparator1,
            this.keluarToolStripMenuItem});
            this.aplikasiToolStripMenuItem.Name = "aplikasiToolStripMenuItem";
            this.aplikasiToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.aplikasiToolStripMenuItem.Text = "&Aplikasi";
            // 
            // daftarAnggotaToolStripMenuItem
            // 
            this.daftarAnggotaToolStripMenuItem.Name = "daftarAnggotaToolStripMenuItem";
            this.daftarAnggotaToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.daftarAnggotaToolStripMenuItem.Text = "Daftar &Anggota...";
            this.daftarAnggotaToolStripMenuItem.Click += new System.EventHandler(this.daftarAnggotaToolStripMenuItem_Click);
            // 
            // daftarKegiatanToolStripMenuItem
            // 
            this.daftarKegiatanToolStripMenuItem.Name = "daftarKegiatanToolStripMenuItem";
            this.daftarKegiatanToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.daftarKegiatanToolStripMenuItem.Text = "Daftar &Kegiatan...";
            this.daftarKegiatanToolStripMenuItem.Click += new System.EventHandler(this.daftarKegiatanToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
            // 
            // keluarToolStripMenuItem
            // 
            this.keluarToolStripMenuItem.Name = "keluarToolStripMenuItem";
            this.keluarToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.keluarToolStripMenuItem.Text = "K&eluar";
            this.keluarToolStripMenuItem.Click += new System.EventHandler(this.keluarToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 493);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnAddKegiatan);
            this.Controls.Add(this.txtNPA2);
            this.Controls.Add(this.btnAbsen);
            this.Controls.Add(this.dgvKehadiran);
            this.Controls.Add(this.dtpJamPulang);
            this.Controls.Add(this.dtpJamDatang);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtNamaKegiatan);
            this.Controls.Add(this.btnAddAnggota);
            this.Controls.Add(this.dgvDataAnggota);
            this.Controls.Add(this.txtNpa);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Aplikasi Kehadiran Anggota Himpunan";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataAnggota)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKehadiran)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.TextBox txtNpa;
        private System.Windows.Forms.DataGridView dgvDataAnggota;
        private System.Windows.Forms.Button btnAddAnggota;
        private System.Windows.Forms.TextBox txtNamaKegiatan;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.DateTimePicker dtpJamDatang;
        private System.Windows.Forms.DateTimePicker dtpJamPulang;
        private System.Windows.Forms.DataGridView dgvKehadiran;
        private System.Windows.Forms.Button btnAbsen;
        private System.Windows.Forms.TextBox txtNPA2;
        private System.Windows.Forms.Button btnAddKegiatan;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aplikasiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem daftarAnggotaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem daftarKegiatanToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem keluarToolStripMenuItem;
    }
}

