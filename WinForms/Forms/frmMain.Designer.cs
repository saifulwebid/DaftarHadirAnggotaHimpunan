namespace WinForms
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataAnggota)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKehadiran)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(12, 42);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(179, 20);
            this.txtNama.TabIndex = 0;
            this.txtNama.Text = "Nama";
            // 
            // txtNpa
            // 
            this.txtNpa.Location = new System.Drawing.Point(12, 68);
            this.txtNpa.Name = "txtNpa";
            this.txtNpa.Size = new System.Drawing.Size(100, 20);
            this.txtNpa.TabIndex = 1;
            this.txtNpa.Text = "NPA";
            // 
            // dgvDataAnggota
            // 
            this.dgvDataAnggota.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataAnggota.Location = new System.Drawing.Point(12, 100);
            this.dgvDataAnggota.Name = "dgvDataAnggota";
            this.dgvDataAnggota.Size = new System.Drawing.Size(507, 128);
            this.dgvDataAnggota.TabIndex = 2;
            this.dgvDataAnggota.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataAnggota_CellContentClick);
            // 
            // btnAddAnggota
            // 
            this.btnAddAnggota.Location = new System.Drawing.Point(421, 234);
            this.btnAddAnggota.Name = "btnAddAnggota";
            this.btnAddAnggota.Size = new System.Drawing.Size(98, 23);
            this.btnAddAnggota.TabIndex = 3;
            this.btnAddAnggota.Text = "Add Anggota";
            this.btnAddAnggota.UseVisualStyleBackColor = true;
            this.btnAddAnggota.Click += new System.EventHandler(this.btnAddAnggota_Click);
            // 
            // txtNamaKegiatan
            // 
            this.txtNamaKegiatan.Location = new System.Drawing.Point(12, 267);
            this.txtNamaKegiatan.Name = "txtNamaKegiatan";
            this.txtNamaKegiatan.Size = new System.Drawing.Size(100, 20);
            this.txtNamaKegiatan.TabIndex = 4;
            this.txtNamaKegiatan.Text = "Nama Kegiatan";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(118, 267);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 20);
            this.txtID.TabIndex = 5;
            this.txtID.Text = "ID";
            // 
            // dtpJamDatang
            // 
            this.dtpJamDatang.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpJamDatang.Location = new System.Drawing.Point(224, 267);
            this.dtpJamDatang.Name = "dtpJamDatang";
            this.dtpJamDatang.Size = new System.Drawing.Size(96, 20);
            this.dtpJamDatang.TabIndex = 6;
            // 
            // dtpJamPulang
            // 
            this.dtpJamPulang.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpJamPulang.Location = new System.Drawing.Point(326, 267);
            this.dtpJamPulang.Name = "dtpJamPulang";
            this.dtpJamPulang.Size = new System.Drawing.Size(96, 20);
            this.dtpJamPulang.TabIndex = 7;
            // 
            // dgvKehadiran
            // 
            this.dgvKehadiran.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKehadiran.Location = new System.Drawing.Point(12, 293);
            this.dgvKehadiran.Name = "dgvKehadiran";
            this.dgvKehadiran.Size = new System.Drawing.Size(507, 128);
            this.dgvKehadiran.TabIndex = 8;
            this.dgvKehadiran.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvKehadiran_CellFormatting);
            // 
            // btnAbsen
            // 
            this.btnAbsen.Location = new System.Drawing.Point(421, 427);
            this.btnAbsen.Name = "btnAbsen";
            this.btnAbsen.Size = new System.Drawing.Size(98, 23);
            this.btnAbsen.TabIndex = 9;
            this.btnAbsen.Text = "Fill";
            this.btnAbsen.UseVisualStyleBackColor = true;
            this.btnAbsen.Click += new System.EventHandler(this.btnAbsen_Click);
            // 
            // txtNPA2
            // 
            this.txtNPA2.Location = new System.Drawing.Point(315, 429);
            this.txtNPA2.Name = "txtNPA2";
            this.txtNPA2.Size = new System.Drawing.Size(100, 20);
            this.txtNPA2.TabIndex = 10;
            this.txtNPA2.Text = "NPA";
            // 
            // btnAddKegiatan
            // 
            this.btnAddKegiatan.Location = new System.Drawing.Point(428, 265);
            this.btnAddKegiatan.Name = "btnAddKegiatan";
            this.btnAddKegiatan.Size = new System.Drawing.Size(91, 23);
            this.btnAddKegiatan.TabIndex = 11;
            this.btnAddKegiatan.Text = "Add Kegiatan";
            this.btnAddKegiatan.UseVisualStyleBackColor = true;
            this.btnAddKegiatan.Click += new System.EventHandler(this.btnAddKegiatan_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(538, 455);
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
            this.Name = "frmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataAnggota)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKehadiran)).EndInit();
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
    }
}

