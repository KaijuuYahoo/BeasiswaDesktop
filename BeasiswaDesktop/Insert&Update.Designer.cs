namespace BeasiswaDesktop
{
    partial class Insert_Update
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.deskripsi = new System.Windows.Forms.RichTextBox();
            this.namaB = new System.Windows.Forms.TextBox();
            this.link = new System.Windows.Forms.TextBox();
            this.dtpBuka = new System.Windows.Forms.DateTimePicker();
            this.dtpTutup = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.namaJ = new System.Windows.Forms.ComboBox();
            this.namaK = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nama Beasiswa ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Jenjang";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Kategori";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Deskripsi";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(405, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tanggal Tutup";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(405, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tanggal Buka";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(405, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Link Beasiswa";
            // 
            // deskripsi
            // 
            this.deskripsi.Location = new System.Drawing.Point(33, 225);
            this.deskripsi.Name = "deskripsi";
            this.deskripsi.Size = new System.Drawing.Size(731, 179);
            this.deskripsi.TabIndex = 7;
            this.deskripsi.Text = "";
            // 
            // namaB
            // 
            this.namaB.Location = new System.Drawing.Point(126, 40);
            this.namaB.Name = "namaB";
            this.namaB.Size = new System.Drawing.Size(273, 20);
            this.namaB.TabIndex = 8;
            // 
            // link
            // 
            this.link.Location = new System.Drawing.Point(486, 115);
            this.link.Name = "link";
            this.link.Size = new System.Drawing.Size(278, 20);
            this.link.TabIndex = 11;
            // 
            // dtpBuka
            // 
            this.dtpBuka.Location = new System.Drawing.Point(486, 40);
            this.dtpBuka.Name = "dtpBuka";
            this.dtpBuka.Size = new System.Drawing.Size(278, 20);
            this.dtpBuka.TabIndex = 12;
            // 
            // dtpTutup
            // 
            this.dtpTutup.Location = new System.Drawing.Point(486, 79);
            this.dtpTutup.Name = "dtpTutup";
            this.dtpTutup.Size = new System.Drawing.Size(278, 20);
            this.dtpTutup.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(646, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Insert";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(518, 415);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Update";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // namaJ
            // 
            this.namaJ.FormattingEnabled = true;
            this.namaJ.Location = new System.Drawing.Point(126, 79);
            this.namaJ.Name = "namaJ";
            this.namaJ.Size = new System.Drawing.Size(273, 21);
            this.namaJ.TabIndex = 16;
            this.namaJ.SelectedIndexChanged += new System.EventHandler(this.namaJ_SelectedIndexChanged);
            // 
            // namaK
            // 
            this.namaK.FormattingEnabled = true;
            this.namaK.Location = new System.Drawing.Point(126, 115);
            this.namaK.Name = "namaK";
            this.namaK.Size = new System.Drawing.Size(273, 21);
            this.namaK.TabIndex = 17;
            this.namaK.SelectedIndexChanged += new System.EventHandler(this.namaK_SelectedIndexChanged);
            // 
            // Insert_Update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.namaK);
            this.Controls.Add(this.namaJ);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtpTutup);
            this.Controls.Add(this.dtpBuka);
            this.Controls.Add(this.link);
            this.Controls.Add(this.namaB);
            this.Controls.Add(this.deskripsi);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Insert_Update";
            this.Text = "Insert_Update";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox deskripsi;
        private System.Windows.Forms.TextBox namaB;
        private System.Windows.Forms.TextBox link;
        private System.Windows.Forms.DateTimePicker dtpBuka;
        private System.Windows.Forms.DateTimePicker dtpTutup;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox namaJ;
        private System.Windows.Forms.ComboBox namaK;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}