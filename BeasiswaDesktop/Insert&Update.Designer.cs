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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Insert_Update));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.deskripsi = new System.Windows.Forms.RichTextBox();
            this.beasiswaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.beasiswaDBDataSet = new BeasiswaDesktop.beasiswaDBDataSet();
            this.namaB = new System.Windows.Forms.TextBox();
            this.link = new System.Windows.Forms.TextBox();
            this.dtpBuka = new System.Windows.Forms.DateTimePicker();
            this.dtpTutup = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.namaJ = new System.Windows.Forms.ComboBox();
            this.jenjangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.namaK = new System.Windows.Forms.ComboBox();
            this.kategoriBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.beasiswaTableAdapter = new BeasiswaDesktop.beasiswaDBDataSetTableAdapters.BeasiswaTableAdapter();
            this.jenjangTableAdapter = new BeasiswaDesktop.beasiswaDBDataSetTableAdapters.JenjangTableAdapter();
            this.kategoriTableAdapter = new BeasiswaDesktop.beasiswaDBDataSetTableAdapters.KategoriTableAdapter();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSQLi = new System.Windows.Forms.Button();
            this.btnImpEx = new System.Windows.Forms.Button();
            this.btnImpDb = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.beasiswaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beasiswaDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jenjangBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kategoriBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 123);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nama Beasiswa ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 198);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Jenjang";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 277);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Kategori";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 369);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Deskripsi";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(820, 198);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tanggal Tutup";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(820, 123);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tanggal Buka";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(820, 277);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 25);
            this.label7.TabIndex = 6;
            this.label7.Text = "Link Beasiswa";
            // 
            // deskripsi
            // 
            this.deskripsi.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.beasiswaBindingSource, "deskripsi", true));
            this.deskripsi.Location = new System.Drawing.Point(66, 433);
            this.deskripsi.Margin = new System.Windows.Forms.Padding(6);
            this.deskripsi.Name = "deskripsi";
            this.deskripsi.Size = new System.Drawing.Size(1458, 341);
            this.deskripsi.TabIndex = 7;
            this.deskripsi.Text = "";
            // 
            // beasiswaBindingSource
            // 
            this.beasiswaBindingSource.DataMember = "Beasiswa";
            this.beasiswaBindingSource.DataSource = this.beasiswaDBDataSet;
            // 
            // beasiswaDBDataSet
            // 
            this.beasiswaDBDataSet.DataSetName = "beasiswaDBDataSet";
            this.beasiswaDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // namaB
            // 
            this.namaB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.beasiswaBindingSource, "nama_beasiswa", true));
            this.namaB.Location = new System.Drawing.Point(262, 117);
            this.namaB.Margin = new System.Windows.Forms.Padding(6);
            this.namaB.Name = "namaB";
            this.namaB.Size = new System.Drawing.Size(542, 31);
            this.namaB.TabIndex = 8;
            // 
            // link
            // 
            this.link.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.beasiswaBindingSource, "link_beasiswa", true));
            this.link.Location = new System.Drawing.Point(982, 263);
            this.link.Margin = new System.Windows.Forms.Padding(6);
            this.link.Name = "link";
            this.link.Size = new System.Drawing.Size(552, 31);
            this.link.TabIndex = 11;
            // 
            // dtpBuka
            // 
            this.dtpBuka.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.beasiswaBindingSource, "tgl_buka", true));
            this.dtpBuka.Location = new System.Drawing.Point(982, 117);
            this.dtpBuka.Margin = new System.Windows.Forms.Padding(6);
            this.dtpBuka.Name = "dtpBuka";
            this.dtpBuka.Size = new System.Drawing.Size(552, 31);
            this.dtpBuka.TabIndex = 12;
            // 
            // dtpTutup
            // 
            this.dtpTutup.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.beasiswaBindingSource, "tgl_tutup", true));
            this.dtpTutup.Location = new System.Drawing.Point(982, 192);
            this.dtpTutup.Margin = new System.Windows.Forms.Padding(6);
            this.dtpTutup.Name = "dtpTutup";
            this.dtpTutup.Size = new System.Drawing.Size(552, 31);
            this.dtpTutup.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1292, 798);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(236, 44);
            this.button1.TabIndex = 14;
            this.button1.Text = "Insert";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1036, 798);
            this.button2.Margin = new System.Windows.Forms.Padding(6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(244, 44);
            this.button2.TabIndex = 15;
            this.button2.Text = "Update";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // namaJ
            // 
            this.namaJ.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.jenjangBindingSource, "nama_jenjang", true));
            this.namaJ.FormattingEnabled = true;
            this.namaJ.Location = new System.Drawing.Point(262, 192);
            this.namaJ.Margin = new System.Windows.Forms.Padding(6);
            this.namaJ.Name = "namaJ";
            this.namaJ.Size = new System.Drawing.Size(542, 33);
            this.namaJ.TabIndex = 16;
            this.namaJ.SelectedIndexChanged += new System.EventHandler(this.namaJ_SelectedIndexChanged);
            // 
            // jenjangBindingSource
            // 
            this.jenjangBindingSource.DataMember = "Jenjang";
            this.jenjangBindingSource.DataSource = this.beasiswaDBDataSet;
            // 
            // namaK
            // 
            this.namaK.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.kategoriBindingSource, "nama_kategori", true));
            this.namaK.FormattingEnabled = true;
            this.namaK.Location = new System.Drawing.Point(262, 263);
            this.namaK.Margin = new System.Windows.Forms.Padding(6);
            this.namaK.Name = "namaK";
            this.namaK.Size = new System.Drawing.Size(542, 33);
            this.namaK.TabIndex = 17;
            this.namaK.SelectedIndexChanged += new System.EventHandler(this.namaK_SelectedIndexChanged);
            // 
            // kategoriBindingSource
            // 
            this.kategoriBindingSource.DataMember = "Kategori";
            this.kategoriBindingSource.DataSource = this.beasiswaDBDataSet;
            // 
            // beasiswaTableAdapter
            // 
            this.beasiswaTableAdapter.ClearBeforeFill = true;
            // 
            // jenjangTableAdapter
            // 
            this.jenjangTableAdapter.ClearBeforeFill = true;
            // 
            // kategoriTableAdapter
            // 
            this.kategoriTableAdapter.ClearBeforeFill = true;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigator1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.Padding = new System.Windows.Forms.Padding(0);
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(1608, 50);
            this.bindingNavigator1.TabIndex = 18;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(46, 44);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(70, 36);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(46, 36);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(46, 36);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(46, 36);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 42);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 39);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 42);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(46, 36);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(46, 36);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 42);
            // 
            // btnSQLi
            // 
            this.btnSQLi.Location = new System.Drawing.Point(788, 798);
            this.btnSQLi.Margin = new System.Windows.Forms.Padding(6);
            this.btnSQLi.Name = "btnSQLi";
            this.btnSQLi.Size = new System.Drawing.Size(236, 44);
            this.btnSQLi.TabIndex = 19;
            this.btnSQLi.Text = "SQL Inject";
            this.btnSQLi.UseVisualStyleBackColor = true;
            this.btnSQLi.Click += new System.EventHandler(this.btnTestInjection_Click);
            // 
            // btnImpEx
            // 
            this.btnImpEx.Location = new System.Drawing.Point(262, 800);
            this.btnImpEx.Margin = new System.Windows.Forms.Padding(4);
            this.btnImpEx.Name = "btnImpEx";
            this.btnImpEx.Size = new System.Drawing.Size(234, 42);
            this.btnImpEx.TabIndex = 29;
            this.btnImpEx.Text = "Import From Excel";
            this.btnImpEx.UseVisualStyleBackColor = true;
            this.btnImpEx.Click += new System.EventHandler(this.btnImpEx_Click);
            // 
            // btnImpDb
            // 
            this.btnImpDb.Location = new System.Drawing.Point(527, 798);
            this.btnImpDb.Margin = new System.Windows.Forms.Padding(4);
            this.btnImpDb.Name = "btnImpDb";
            this.btnImpDb.Size = new System.Drawing.Size(234, 42);
            this.btnImpDb.TabIndex = 28;
            this.btnImpDb.Text = "Import To Database";
            this.btnImpDb.UseVisualStyleBackColor = true;
            this.btnImpDb.Click += new System.EventHandler(this.btnImpDb_Click);
            // 
            // Insert_Update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1608, 865);
            this.Controls.Add(this.btnImpEx);
            this.Controls.Add(this.btnImpDb);
            this.Controls.Add(this.btnSQLi);
            this.Controls.Add(this.bindingNavigator1);
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
            this.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.beasiswaBindingSource, "nama_beasiswa", true));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Insert_Update";
            this.Text = "Insert_Update";
            this.Load += new System.EventHandler(this.Insert_Update_Load);
            ((System.ComponentModel.ISupportInitialize)(this.beasiswaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beasiswaDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jenjangBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kategoriBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
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
        private System.Windows.Forms.BindingSource bindingSource1;
        private beasiswaDBDataSet beasiswaDBDataSet;
        private System.Windows.Forms.BindingSource beasiswaBindingSource;
        private beasiswaDBDataSetTableAdapters.BeasiswaTableAdapter beasiswaTableAdapter;
        private System.Windows.Forms.BindingSource jenjangBindingSource;
        private beasiswaDBDataSetTableAdapters.JenjangTableAdapter jenjangTableAdapter;
        private System.Windows.Forms.BindingSource kategoriBindingSource;
        private beasiswaDBDataSetTableAdapters.KategoriTableAdapter kategoriTableAdapter;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.Button btnSQLi;
        private System.Windows.Forms.Button btnImpEx;
        private System.Windows.Forms.Button btnImpDb;
    }
}