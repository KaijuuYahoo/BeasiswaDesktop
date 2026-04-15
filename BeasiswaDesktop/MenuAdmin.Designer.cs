namespace BeasiswaDesktop
{
    partial class MenuAdmin
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
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvBeasiswa = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.logOut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBeasiswa)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(713, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Search";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 10);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(695, 20);
            this.textBox1.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(678, 419);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Insert";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // dgvBeasiswa
            // 
            this.dgvBeasiswa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBeasiswa.Location = new System.Drawing.Point(12, 39);
            this.dgvBeasiswa.Name = "dgvBeasiswa";
            this.dgvBeasiswa.RowHeadersWidth = 51;
            this.dgvBeasiswa.Size = new System.Drawing.Size(776, 374);
            this.dgvBeasiswa.TabIndex = 5;
            this.dgvBeasiswa.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MenuAdmin_Load);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(562, 419);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(110, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Update";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(446, 419);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(110, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "Delete";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // logOut
            // 
            this.logOut.Location = new System.Drawing.Point(12, 419);
            this.logOut.Name = "logOut";
            this.logOut.Size = new System.Drawing.Size(110, 23);
            this.logOut.TabIndex = 11;
            this.logOut.Text = "Log Out";
            this.logOut.UseVisualStyleBackColor = true;
            // 
            // MenuAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.logOut);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvBeasiswa);
            this.Name = "MenuAdmin";
            this.Text = "MenuAdmin";
            this.Load += new System.EventHandler(this.MenuAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBeasiswa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvBeasiswa;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button logOut;
    }
}