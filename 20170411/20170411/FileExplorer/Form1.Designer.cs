namespace FileExplorer
{
    partial class Form1
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
            this.cmbsuruculer = new System.Windows.Forms.ComboBox();
            this.trwklasorler = new System.Windows.Forms.TreeView();
            this.lstbilgiler = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.kesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kopyalaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yapistirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tssToplamOge = new System.Windows.Forms.StatusStrip();
            this.tssToplamBoyut = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmbfiltrele = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tssToplamOge.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbsuruculer
            // 
            this.cmbsuruculer.FormattingEnabled = true;
            this.cmbsuruculer.Location = new System.Drawing.Point(12, 12);
            this.cmbsuruculer.Name = "cmbsuruculer";
            this.cmbsuruculer.Size = new System.Drawing.Size(258, 24);
            this.cmbsuruculer.TabIndex = 0;
            this.cmbsuruculer.SelectedIndexChanged += new System.EventHandler(this.cmbsuruculer_SelectedIndexChanged);
            // 
            // trwklasorler
            // 
            this.trwklasorler.Location = new System.Drawing.Point(13, 52);
            this.trwklasorler.Name = "trwklasorler";
            this.trwklasorler.Size = new System.Drawing.Size(257, 600);
            this.trwklasorler.TabIndex = 1;
            this.trwklasorler.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.trwklasorler_AfterExpand);
            this.trwklasorler.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trwklasorler_AfterSelect);
            // 
            // lstbilgiler
            // 
            this.lstbilgiler.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lstbilgiler.ContextMenuStrip = this.contextMenuStrip1;
            this.lstbilgiler.GridLines = true;
            this.lstbilgiler.Location = new System.Drawing.Point(298, 12);
            this.lstbilgiler.Name = "lstbilgiler";
            this.lstbilgiler.Size = new System.Drawing.Size(660, 457);
            this.lstbilgiler.TabIndex = 2;
            this.lstbilgiler.UseCompatibleStateImageBehavior = false;
            this.lstbilgiler.View = System.Windows.Forms.View.Details;
            this.lstbilgiler.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstbilgiler_ColumnClick);
            this.lstbilgiler.DoubleClick += new System.EventHandler(this.lstbilgiler_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Dosya Adı";
            this.columnHeader1.Width = 250;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Boyut";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Oluşturulma Tarihi";
            this.columnHeader3.Width = 150;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kesToolStripMenuItem,
            this.kopyalaToolStripMenuItem,
            this.yapistirToolStripMenuItem,
            this.silToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(139, 108);
            // 
            // kesToolStripMenuItem
            // 
            this.kesToolStripMenuItem.Name = "kesToolStripMenuItem";
            this.kesToolStripMenuItem.Size = new System.Drawing.Size(138, 26);
            this.kesToolStripMenuItem.Text = "Kes";
            this.kesToolStripMenuItem.Click += new System.EventHandler(this.kesToolStripMenuItem_Click);
            // 
            // kopyalaToolStripMenuItem
            // 
            this.kopyalaToolStripMenuItem.Name = "kopyalaToolStripMenuItem";
            this.kopyalaToolStripMenuItem.Size = new System.Drawing.Size(138, 26);
            this.kopyalaToolStripMenuItem.Text = "Kopyala";
            this.kopyalaToolStripMenuItem.Click += new System.EventHandler(this.kopyalaToolStripMenuItem_Click);
            // 
            // yapistirToolStripMenuItem
            // 
            this.yapistirToolStripMenuItem.Name = "yapistirToolStripMenuItem";
            this.yapistirToolStripMenuItem.Size = new System.Drawing.Size(138, 26);
            this.yapistirToolStripMenuItem.Text = "Yapıştır";
            this.yapistirToolStripMenuItem.Click += new System.EventHandler(this.yapistirToolStripMenuItem_Click);
            // 
            // silToolStripMenuItem
            // 
            this.silToolStripMenuItem.Name = "silToolStripMenuItem";
            this.silToolStripMenuItem.Size = new System.Drawing.Size(138, 26);
            this.silToolStripMenuItem.Text = "Sil";
            this.silToolStripMenuItem.Click += new System.EventHandler(this.silToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tssToplamOge);
            this.panel1.Controls.Add(this.cmbfiltrele);
            this.panel1.Location = new System.Drawing.Point(298, 475);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(660, 177);
            this.panel1.TabIndex = 3;
            // 
            // tssToplamOge
            // 
            this.tssToplamOge.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tssToplamOge.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssToplamBoyut});
            this.tssToplamOge.Location = new System.Drawing.Point(0, 152);
            this.tssToplamOge.Name = "tssToplamOge";
            this.tssToplamOge.Size = new System.Drawing.Size(660, 25);
            this.tssToplamOge.TabIndex = 1;
            this.tssToplamOge.Text = "Toplam Dosya Sayısı";
            // 
            // tssToplamBoyut
            // 
            this.tssToplamBoyut.Name = "tssToplamBoyut";
            this.tssToplamBoyut.Size = new System.Drawing.Size(151, 20);
            this.tssToplamBoyut.Text = "toolStripStatusLabel1";
            // 
            // cmbfiltrele
            // 
            this.cmbfiltrele.FormattingEnabled = true;
            this.cmbfiltrele.Location = new System.Drawing.Point(3, 3);
            this.cmbfiltrele.Name = "cmbfiltrele";
            this.cmbfiltrele.Size = new System.Drawing.Size(121, 24);
            this.cmbfiltrele.TabIndex = 0;
            this.cmbfiltrele.SelectedIndexChanged += new System.EventHandler(this.cmbfiltrele_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 697);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lstbilgiler);
            this.Controls.Add(this.trwklasorler);
            this.Controls.Add(this.cmbsuruculer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tssToplamOge.ResumeLayout(false);
            this.tssToplamOge.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbsuruculer;
        private System.Windows.Forms.TreeView trwklasorler;
        private System.Windows.Forms.ListView lstbilgiler;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip tssToplamOge;
        private System.Windows.Forms.ToolStripStatusLabel tssToplamBoyut;
        private System.Windows.Forms.ComboBox cmbfiltrele;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kopyalaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yapistirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
    }
}

