namespace RobotMimiczny
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewPackage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOpenPackageFromFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSavePackageToFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExportPackageToDevice = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemImportPackageFromDevice = new System.Windows.Forms.ToolStripMenuItem();
            this.pomocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.btnExecuteFace = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFace1 = new System.Windows.Forms.Button();
            this.btnFace2 = new System.Windows.Forms.Button();
            this.btnFace3 = new System.Windows.Forms.Button();
            this.btnFace4 = new System.Windows.Forms.Button();
            this.btnFace5 = new System.Windows.Forms.Button();
            this.btnFace6 = new System.Windows.Forms.Button();
            this.btnFace7 = new System.Windows.Forms.Button();
            this.btnFace8 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.pomocToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(779, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNewPackage,
            this.menuItemOpenPackageFromFile,
            this.menuItemSavePackageToFile,
            this.menuItemExportPackageToDevice,
            this.menuItemImportPackageFromDevice});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // menuItemNewPackage
            // 
            this.menuItemNewPackage.Name = "menuItemNewPackage";
            this.menuItemNewPackage.Size = new System.Drawing.Size(233, 22);
            this.menuItemNewPackage.Text = "Nowy zestaw";
            this.menuItemNewPackage.Click += new System.EventHandler(this.menuItemNewPackage_Click);
            // 
            // menuItemOpenPackageFromFile
            // 
            this.menuItemOpenPackageFromFile.Name = "menuItemOpenPackageFromFile";
            this.menuItemOpenPackageFromFile.Size = new System.Drawing.Size(233, 22);
            this.menuItemOpenPackageFromFile.Text = "Otwórz zestaw z pliku";
            this.menuItemOpenPackageFromFile.Click += new System.EventHandler(this.menuItemOpenPackageFromFile_Click);
            // 
            // menuItemSavePackageToFile
            // 
            this.menuItemSavePackageToFile.Name = "menuItemSavePackageToFile";
            this.menuItemSavePackageToFile.Size = new System.Drawing.Size(233, 22);
            this.menuItemSavePackageToFile.Text = "Zapisz zestaw do pliku";
            this.menuItemSavePackageToFile.Click += new System.EventHandler(this.menuItemSavePackageToFile_Click);
            // 
            // menuItemExportPackageToDevice
            // 
            this.menuItemExportPackageToDevice.Name = "menuItemExportPackageToDevice";
            this.menuItemExportPackageToDevice.Size = new System.Drawing.Size(233, 22);
            this.menuItemExportPackageToDevice.Text = "Eksport zestawu na urzadzenie";
            this.menuItemExportPackageToDevice.Click += new System.EventHandler(this.menuItemExportPackageToDevice_Click);
            // 
            // menuItemImportPackageFromDevice
            // 
            this.menuItemImportPackageFromDevice.Name = "menuItemImportPackageFromDevice";
            this.menuItemImportPackageFromDevice.Size = new System.Drawing.Size(233, 22);
            this.menuItemImportPackageFromDevice.Text = "Import zestawu z urzadzenia";
            this.menuItemImportPackageFromDevice.Click += new System.EventHandler(this.menuItemImportPackageFromDevice_Click);
            // 
            // pomocToolStripMenuItem
            // 
            this.pomocToolStripMenuItem.Name = "pomocToolStripMenuItem";
            this.pomocToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.pomocToolStripMenuItem.Text = "Pomoc";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Wybierz minę:";
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Enabled = false;
            this.btnSaveSettings.Location = new System.Drawing.Point(619, 320);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(148, 23);
            this.btnSaveSettings.TabIndex = 3;
            this.btnSaveSettings.Text = "Zapisz bieżące ustawienia";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // btnExecuteFace
            // 
            this.btnExecuteFace.Enabled = false;
            this.btnExecuteFace.Location = new System.Drawing.Point(619, 291);
            this.btnExecuteFace.Name = "btnExecuteFace";
            this.btnExecuteFace.Size = new System.Drawing.Size(148, 23);
            this.btnExecuteFace.TabIndex = 4;
            this.btnExecuteFace.Text = "Wykonaj minę";
            this.btnExecuteFace.UseVisualStyleBackColor = true;
            this.btnExecuteFace.Click += new System.EventHandler(this.btnExecuteFace_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(78, 180);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(201, 45);
            this.trackBar1.TabIndex = 8;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(78, 231);
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(201, 45);
            this.trackBar2.TabIndex = 9;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(568, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "motor1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "motor2";
            // 
            // btnFace1
            // 
            this.btnFace1.Location = new System.Drawing.Point(16, 70);
            this.btnFace1.Name = "btnFace1";
            this.btnFace1.Size = new System.Drawing.Size(70, 60);
            this.btnFace1.TabIndex = 13;
            this.btnFace1.Text = "button1";
            this.btnFace1.UseVisualStyleBackColor = true;
            this.btnFace1.Click += new System.EventHandler(this.btnFace1_Click);
            // 
            // btnFace2
            // 
            this.btnFace2.AccessibleDescription = "";
            this.btnFace2.Location = new System.Drawing.Point(103, 70);
            this.btnFace2.Name = "btnFace2";
            this.btnFace2.Size = new System.Drawing.Size(70, 60);
            this.btnFace2.TabIndex = 14;
            this.btnFace2.Text = "button2";
            this.btnFace2.UseVisualStyleBackColor = true;
            this.btnFace2.Click += new System.EventHandler(this.btnFace2_Click);
            // 
            // btnFace3
            // 
            this.btnFace3.Location = new System.Drawing.Point(191, 70);
            this.btnFace3.Name = "btnFace3";
            this.btnFace3.Size = new System.Drawing.Size(70, 60);
            this.btnFace3.TabIndex = 15;
            this.btnFace3.Text = "button3";
            this.btnFace3.UseVisualStyleBackColor = true;
            // 
            // btnFace4
            // 
            this.btnFace4.Location = new System.Drawing.Point(282, 70);
            this.btnFace4.Name = "btnFace4";
            this.btnFace4.Size = new System.Drawing.Size(70, 60);
            this.btnFace4.TabIndex = 16;
            this.btnFace4.Text = "button4";
            this.btnFace4.UseVisualStyleBackColor = true;
            // 
            // btnFace5
            // 
            this.btnFace5.Location = new System.Drawing.Point(375, 70);
            this.btnFace5.Name = "btnFace5";
            this.btnFace5.Size = new System.Drawing.Size(70, 60);
            this.btnFace5.TabIndex = 17;
            this.btnFace5.Text = "button5";
            this.btnFace5.UseVisualStyleBackColor = true;
            // 
            // btnFace6
            // 
            this.btnFace6.Location = new System.Drawing.Point(463, 70);
            this.btnFace6.Name = "btnFace6";
            this.btnFace6.Size = new System.Drawing.Size(70, 60);
            this.btnFace6.TabIndex = 18;
            this.btnFace6.Text = "button6";
            this.btnFace6.UseVisualStyleBackColor = true;
            // 
            // btnFace7
            // 
            this.btnFace7.Location = new System.Drawing.Point(551, 70);
            this.btnFace7.Name = "btnFace7";
            this.btnFace7.Size = new System.Drawing.Size(70, 60);
            this.btnFace7.TabIndex = 19;
            this.btnFace7.Text = "button7";
            this.btnFace7.UseVisualStyleBackColor = true;
            // 
            // btnFace8
            // 
            this.btnFace8.Location = new System.Drawing.Point(638, 70);
            this.btnFace8.Name = "btnFace8";
            this.btnFace8.Size = new System.Drawing.Size(70, 60);
            this.btnFace8.TabIndex = 20;
            this.btnFace8.Text = "button8";
            this.btnFace8.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 145);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(69, 20);
            this.textBox1.TabIndex = 21;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 419);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnFace8);
            this.Controls.Add(this.btnFace7);
            this.Controls.Add(this.btnFace6);
            this.Controls.Add(this.btnFace5);
            this.Controls.Add(this.btnFace4);
            this.Controls.Add(this.btnFace3);
            this.Controls.Add(this.btnFace2);
            this.Controls.Add(this.btnFace1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.btnExecuteFace);
            this.Controls.Add(this.btnSaveSettings);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemNewPackage;
        private System.Windows.Forms.ToolStripMenuItem menuItemOpenPackageFromFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemSavePackageToFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemExportPackageToDevice;
        private System.Windows.Forms.ToolStripMenuItem menuItemImportPackageFromDevice;
        private System.Windows.Forms.ToolStripMenuItem pomocToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.Button btnExecuteFace;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFace1;
        private System.Windows.Forms.Button btnFace2;
        private System.Windows.Forms.Button btnFace3;
        private System.Windows.Forms.Button btnFace4;
        private System.Windows.Forms.Button btnFace5;
        private System.Windows.Forms.Button btnFace6;
        private System.Windows.Forms.Button btnFace7;
        private System.Windows.Forms.Button btnFace8;
        private System.Windows.Forms.TextBox textBox1;
    }
}

