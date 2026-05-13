namespace BeasiswaDesktop
{
    partial class BeasiswaRead
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
            this.components = new System.ComponentModel.Container();
            this.dgvBeasiswa = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.textSearch = new System.Windows.Forms.TextBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBeasiswa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBeasiswa
            // 
            this.dgvBeasiswa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBeasiswa.Location = new System.Drawing.Point(12, 42);
            this.dgvBeasiswa.Name = "dgvBeasiswa";
            this.dgvBeasiswa.RowHeadersWidth = 51;
            this.dgvBeasiswa.Size = new System.Drawing.Size(776, 374);
            this.dgvBeasiswa.TabIndex = 0;
            this.dgvBeasiswa.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BeasiswaRead_Load);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(678, 421);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Login_Click);
            // 
            // textSearch
            // 
            this.textSearch.Location = new System.Drawing.Point(12, 12);
            this.textSearch.Name = "textSearch";
            this.textSearch.Size = new System.Drawing.Size(777, 20);
            this.textSearch.TabIndex = 3;
            this.textSearch.TextChanged += new System.EventHandler(this.LiveSearch);
            // 
            // BeasiswaRead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 450);
            this.Controls.Add(this.textSearch);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvBeasiswa);
            this.Name = "BeasiswaRead";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.BeasiswaRead_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBeasiswa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBeasiswa;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textSearch;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}

