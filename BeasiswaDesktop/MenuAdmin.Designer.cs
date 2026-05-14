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
            this.textSearch = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvBeasiswa = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.logOut = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBeasiswa)).BeginInit();
            this.SuspendLayout();
            // 
            // textSearch
            // 
            this.textSearch.Location = new System.Drawing.Point(24, 19);
            this.textSearch.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textSearch.Name = "textSearch";
            this.textSearch.Size = new System.Drawing.Size(1362, 31);
            this.textSearch.TabIndex = 7;
            this.textSearch.TextChanged += new System.EventHandler(this.SearchAutomatic);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1356, 806);
            this.button1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(220, 44);
            this.button1.TabIndex = 6;
            this.button1.Text = "Insert";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // dgvBeasiswa
            // 
            this.dgvBeasiswa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBeasiswa.Location = new System.Drawing.Point(24, 75);
            this.dgvBeasiswa.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dgvBeasiswa.Name = "dgvBeasiswa";
            this.dgvBeasiswa.RowHeadersWidth = 51;
            this.dgvBeasiswa.Size = new System.Drawing.Size(1552, 719);
            this.dgvBeasiswa.TabIndex = 5;
            this.dgvBeasiswa.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MenuAdmin_Load);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1124, 806);
            this.button3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(220, 44);
            this.button3.TabIndex = 9;
            this.button3.Text = "Update";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(892, 806);
            this.button4.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(220, 44);
            this.button4.TabIndex = 10;
            this.button4.Text = "Delete";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // logOut
            // 
            this.logOut.Location = new System.Drawing.Point(24, 806);
            this.logOut.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.logOut.Name = "logOut";
            this.logOut.Size = new System.Drawing.Size(220, 44);
            this.logOut.TabIndex = 11;
            this.logOut.Text = "Log Out";
            this.logOut.UseVisualStyleBackColor = true;
            this.logOut.Click += new System.EventHandler(this.logOut_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(636, 806);
            this.btnReset.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(244, 44);
            this.btnReset.TabIndex = 21;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnResetData_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(1408, 19);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(158, 25);
            this.lblTotal.TabIndex = 22;
            this.lblTotal.Text = "Total Beasiswa";
            // 
            // MenuAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1594, 869);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.logOut);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textSearch);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvBeasiswa);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "MenuAdmin";
            this.Text = "Dashboard Admin";
            this.Load += new System.EventHandler(this.MenuAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBeasiswa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textSearch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvBeasiswa;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button logOut;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblTotal;
    }
}