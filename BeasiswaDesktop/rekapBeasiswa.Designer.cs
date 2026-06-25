namespace BeasiswaDesktop
{
    partial class rekapBeasiswa
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnCetak = new System.Windows.Forms.Button();
            this.thnMasuk = new System.Windows.Forms.Label();
            this.jenjang = new System.Windows.Forms.Label();
            this.dtpTanggalMasuk = new System.Windows.Forms.DateTimePicker();
            this.cmbJenjang = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnLoad = new System.Windows.Forms.Button();
            this.kategori = new System.Windows.Forms.Label();
            this.cmbKategori = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(462, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 29);
            this.label1.TabIndex = 15;
            this.label1.Text = "REKAP DATA BEASISWA";
            // 
            // btnCetak
            // 
            this.btnCetak.Location = new System.Drawing.Point(1108, 864);
            this.btnCetak.Name = "btnCetak";
            this.btnCetak.Size = new System.Drawing.Size(153, 41);
            this.btnCetak.TabIndex = 14;
            this.btnCetak.Text = "Cetak";
            this.btnCetak.UseVisualStyleBackColor = true;
            this.btnCetak.Click += new System.EventHandler(this.btnCetak_Click);
            // 
            // thnMasuk
            // 
            this.thnMasuk.AutoSize = true;
            this.thnMasuk.Location = new System.Drawing.Point(566, 104);
            this.thnMasuk.Name = "thnMasuk";
            this.thnMasuk.Size = new System.Drawing.Size(137, 25);
            this.thnMasuk.TabIndex = 13;
            this.thnMasuk.Text = "Bulan Masuk";
            // 
            // jenjang
            // 
            this.jenjang.AutoSize = true;
            this.jenjang.Location = new System.Drawing.Point(80, 104);
            this.jenjang.Name = "jenjang";
            this.jenjang.Size = new System.Drawing.Size(88, 25);
            this.jenjang.TabIndex = 12;
            this.jenjang.Text = "Jenjang";
            // 
            // dtpTanggalMasuk
            // 
            this.dtpTanggalMasuk.Location = new System.Drawing.Point(768, 104);
            this.dtpTanggalMasuk.Name = "dtpTanggalMasuk";
            this.dtpTanggalMasuk.Size = new System.Drawing.Size(200, 31);
            this.dtpTanggalMasuk.TabIndex = 11;
            // 
            // cmbJenjang
            // 
            this.cmbJenjang.FormattingEnabled = true;
            this.cmbJenjang.Location = new System.Drawing.Point(217, 104);
            this.cmbJenjang.Name = "cmbJenjang";
            this.cmbJenjang.Size = new System.Drawing.Size(281, 33);
            this.cmbJenjang.TabIndex = 10;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(85, 217);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1111, 625);
            this.dataGridView1.TabIndex = 9;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(1105, 104);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(156, 46);
            this.btnLoad.TabIndex = 8;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // kategori
            // 
            this.kategori.AutoSize = true;
            this.kategori.Location = new System.Drawing.Point(80, 168);
            this.kategori.Name = "kategori";
            this.kategori.Size = new System.Drawing.Size(104, 25);
            this.kategori.TabIndex = 17;
            this.kategori.Text = "Kaategori";
            // 
            // cmbKategori
            // 
            this.cmbKategori.FormattingEnabled = true;
            this.cmbKategori.Location = new System.Drawing.Point(217, 168);
            this.cmbKategori.Name = "cmbKategori";
            this.cmbKategori.Size = new System.Drawing.Size(281, 33);
            this.cmbKategori.TabIndex = 16;
            // 
            // rekapBeasiswa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1273, 917);
            this.Controls.Add(this.kategori);
            this.Controls.Add(this.cmbKategori);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCetak);
            this.Controls.Add(this.thnMasuk);
            this.Controls.Add(this.jenjang);
            this.Controls.Add(this.dtpTanggalMasuk);
            this.Controls.Add(this.cmbJenjang);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnLoad);
            this.Name = "rekapBeasiswa";
            this.Text = "rekapBeasiswa";
            this.Load += new System.EventHandler(this.rekapBeasiswa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCetak;
        private System.Windows.Forms.Label thnMasuk;
        private System.Windows.Forms.Label jenjang;
        private System.Windows.Forms.DateTimePicker dtpTanggalMasuk;
        private System.Windows.Forms.ComboBox cmbJenjang;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label kategori;
        private System.Windows.Forms.ComboBox cmbKategori;
    }
}