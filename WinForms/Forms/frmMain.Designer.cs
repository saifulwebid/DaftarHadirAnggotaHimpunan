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
            this.mstMain = new System.Windows.Forms.MenuStrip();
            this.aplikasiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.daftarAnggotaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.daftarKegiatanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.keluarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mstMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mstMain
            // 
            this.mstMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aplikasiToolStripMenuItem});
            this.mstMain.Location = new System.Drawing.Point(0, 0);
            this.mstMain.Name = "mstMain";
            this.mstMain.Size = new System.Drawing.Size(664, 24);
            this.mstMain.TabIndex = 15;
            this.mstMain.Text = "menuStrip1";
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
            this.Controls.Add(this.mstMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mstMain;
            this.Name = "frmMain";
            this.Text = "Aplikasi Kehadiran Anggota Himpunan";
            this.mstMain.ResumeLayout(false);
            this.mstMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mstMain;
        private System.Windows.Forms.ToolStripMenuItem aplikasiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem daftarAnggotaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem daftarKegiatanToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem keluarToolStripMenuItem;
    }
}

