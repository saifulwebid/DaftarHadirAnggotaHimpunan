namespace WinForms.Forms
{
    partial class frmDaftarKehadiran
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
            this.dgvKehadiran = new System.Windows.Forms.DataGridView();
            this.btnEkspor = new System.Windows.Forms.Button();
            this.btnAbsen = new System.Windows.Forms.Button();
            this.txtNPA = new System.Windows.Forms.TextBox();
            this.btnScan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKehadiran)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvKehadiran
            // 
            this.dgvKehadiran.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKehadiran.Location = new System.Drawing.Point(12, 41);
            this.dgvKehadiran.Name = "dgvKehadiran";
            this.dgvKehadiran.Size = new System.Drawing.Size(691, 366);
            this.dgvKehadiran.TabIndex = 0;
            this.dgvKehadiran.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvKehadiran_CellFormatting);
            // 
            // btnEkspor
            // 
            this.btnEkspor.Location = new System.Drawing.Point(12, 12);
            this.btnEkspor.Name = "btnEkspor";
            this.btnEkspor.Size = new System.Drawing.Size(75, 23);
            this.btnEkspor.TabIndex = 1;
            this.btnEkspor.Text = "Ekspor";
            this.btnEkspor.UseVisualStyleBackColor = true;
            this.btnEkspor.Click += new System.EventHandler(this.btnEkspor_Click);
            // 
            // btnAbsen
            // 
            this.btnAbsen.Location = new System.Drawing.Point(628, 12);
            this.btnAbsen.Name = "btnAbsen";
            this.btnAbsen.Size = new System.Drawing.Size(75, 23);
            this.btnAbsen.TabIndex = 2;
            this.btnAbsen.Text = "&Absen";
            this.btnAbsen.UseVisualStyleBackColor = true;
            this.btnAbsen.Click += new System.EventHandler(this.btnAbsen_Click);
            // 
            // txtNPA
            // 
            this.txtNPA.Location = new System.Drawing.Point(522, 14);
            this.txtNPA.Name = "txtNPA";
            this.txtNPA.Size = new System.Drawing.Size(100, 20);
            this.txtNPA.TabIndex = 3;
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(441, 12);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(75, 23);
            this.btnScan.TabIndex = 4;
            this.btnScan.Text = "&Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // frmDaftarKehadiran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 419);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.txtNPA);
            this.Controls.Add(this.btnAbsen);
            this.Controls.Add(this.btnEkspor);
            this.Controls.Add(this.dgvKehadiran);
            this.Name = "frmDaftarKehadiran";
            this.Text = "Daftar Kehadiran";
            ((System.ComponentModel.ISupportInitialize)(this.dgvKehadiran)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKehadiran;
        private System.Windows.Forms.Button btnEkspor;
        private System.Windows.Forms.Button btnAbsen;
        private System.Windows.Forms.TextBox txtNPA;
        private System.Windows.Forms.Button btnScan;
    }
}