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
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.trackBar4 = new System.Windows.Forms.TrackBar();
            this.trackBar5 = new System.Windows.Forms.TrackBar();
            this.trackBar6 = new System.Windows.Forms.TrackBar();
            this.trackBar7 = new System.Windows.Forms.TrackBar();
            this.trackBar8 = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar8)).BeginInit();
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
            this.menuItemSavePackageToFile.Enabled = false;
            this.menuItemSavePackageToFile.Name = "menuItemSavePackageToFile";
            this.menuItemSavePackageToFile.Size = new System.Drawing.Size(233, 22);
            this.menuItemSavePackageToFile.Text = "Zapisz zestaw do pliku";
            this.menuItemSavePackageToFile.Click += new System.EventHandler(this.menuItemSavePackageToFile_Click);
            // 
            // menuItemExportPackageToDevice
            // 
            this.menuItemExportPackageToDevice.Enabled = false;
            this.menuItemExportPackageToDevice.Name = "menuItemExportPackageToDevice";
            this.menuItemExportPackageToDevice.Size = new System.Drawing.Size(233, 22);
            this.menuItemExportPackageToDevice.Text = "Eksport zestawu na urzadzenie";
            this.menuItemExportPackageToDevice.Click += new System.EventHandler(this.menuItemExportPackageToDevice_Click);
            // 
            // menuItemImportPackageFromDevice
            // 
            this.menuItemImportPackageFromDevice.Enabled = false;
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
            this.trackBar1.Enabled = false;
            this.trackBar1.Location = new System.Drawing.Point(78, 180);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(201, 45);
            this.trackBar1.TabIndex = 8;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // trackBar2
            // 
            this.trackBar2.Enabled = false;
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
            this.label4.Location = new System.Drawing.Point(12, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "motor2";
            // 
            // btnFace1
            // 
            this.btnFace1.Enabled = false;
            this.btnFace1.Location = new System.Drawing.Point(16, 70);
            this.btnFace1.Name = "btnFace1";
            this.btnFace1.Size = new System.Drawing.Size(70, 60);
            this.btnFace1.TabIndex = 13;
            this.btnFace1.UseVisualStyleBackColor = true;
            this.btnFace1.Click += new System.EventHandler(this.btnFace1_Click);
            // 
            // btnFace2
            // 
            this.btnFace2.AccessibleDescription = "";
            this.btnFace2.Enabled = false;
            this.btnFace2.Location = new System.Drawing.Point(103, 70);
            this.btnFace2.Name = "btnFace2";
            this.btnFace2.Size = new System.Drawing.Size(70, 60);
            this.btnFace2.TabIndex = 14;
            this.btnFace2.UseVisualStyleBackColor = true;
            this.btnFace2.Click += new System.EventHandler(this.btnFace2_Click);
            // 
            // btnFace3
            // 
            this.btnFace3.Enabled = false;
            this.btnFace3.Location = new System.Drawing.Point(191, 70);
            this.btnFace3.Name = "btnFace3";
            this.btnFace3.Size = new System.Drawing.Size(70, 60);
            this.btnFace3.TabIndex = 15;
            this.btnFace3.UseVisualStyleBackColor = true;
            this.btnFace3.Click += new System.EventHandler(this.btnFace3_Click);
            // 
            // btnFace4
            // 
            this.btnFace4.Enabled = false;
            this.btnFace4.Location = new System.Drawing.Point(282, 70);
            this.btnFace4.Name = "btnFace4";
            this.btnFace4.Size = new System.Drawing.Size(70, 60);
            this.btnFace4.TabIndex = 16;
            this.btnFace4.UseVisualStyleBackColor = true;
            this.btnFace4.Click += new System.EventHandler(this.btnFace4_Click);
            // 
            // btnFace5
            // 
            this.btnFace5.Enabled = false;
            this.btnFace5.Location = new System.Drawing.Point(375, 70);
            this.btnFace5.Name = "btnFace5";
            this.btnFace5.Size = new System.Drawing.Size(70, 60);
            this.btnFace5.TabIndex = 17;
            this.btnFace5.UseVisualStyleBackColor = true;
            this.btnFace5.Click += new System.EventHandler(this.btnFace5_Click);
            // 
            // btnFace6
            // 
            this.btnFace6.Enabled = false;
            this.btnFace6.Location = new System.Drawing.Point(463, 70);
            this.btnFace6.Name = "btnFace6";
            this.btnFace6.Size = new System.Drawing.Size(70, 60);
            this.btnFace6.TabIndex = 18;
            this.btnFace6.UseVisualStyleBackColor = true;
            this.btnFace6.Click += new System.EventHandler(this.btnFace6_Click);
            // 
            // btnFace7
            // 
            this.btnFace7.Enabled = false;
            this.btnFace7.Location = new System.Drawing.Point(551, 70);
            this.btnFace7.Name = "btnFace7";
            this.btnFace7.Size = new System.Drawing.Size(70, 60);
            this.btnFace7.TabIndex = 19;
            this.btnFace7.UseVisualStyleBackColor = true;
            this.btnFace7.Click += new System.EventHandler(this.btnFace7_Click);
            // 
            // btnFace8
            // 
            this.btnFace8.Enabled = false;
            this.btnFace8.Location = new System.Drawing.Point(638, 70);
            this.btnFace8.Name = "btnFace8";
            this.btnFace8.Size = new System.Drawing.Size(70, 60);
            this.btnFace8.TabIndex = 20;
            this.btnFace8.UseVisualStyleBackColor = true;
            this.btnFace8.Click += new System.EventHandler(this.btnFace8_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(16, 145);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(69, 20);
            this.textBox1.TabIndex = 21;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(104, 145);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(69, 20);
            this.textBox2.TabIndex = 22;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(192, 145);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(69, 20);
            this.textBox3.TabIndex = 23;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(283, 145);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(69, 20);
            this.textBox4.TabIndex = 24;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // textBox5
            // 
            this.textBox5.Enabled = false;
            this.textBox5.Location = new System.Drawing.Point(375, 145);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(69, 20);
            this.textBox5.TabIndex = 25;
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // textBox6
            // 
            this.textBox6.Enabled = false;
            this.textBox6.Location = new System.Drawing.Point(463, 145);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(69, 20);
            this.textBox6.TabIndex = 26;
            this.textBox6.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // textBox7
            // 
            this.textBox7.Enabled = false;
            this.textBox7.Location = new System.Drawing.Point(551, 145);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(69, 20);
            this.textBox7.TabIndex = 27;
            this.textBox7.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            // 
            // textBox8
            // 
            this.textBox8.Enabled = false;
            this.textBox8.Location = new System.Drawing.Point(638, 145);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(69, 20);
            this.textBox8.TabIndex = 28;
            this.textBox8.TextChanged += new System.EventHandler(this.textBox8_TextChanged);
            // 
            // trackBar3
            // 
            this.trackBar3.Enabled = false;
            this.trackBar3.Location = new System.Drawing.Point(78, 282);
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(201, 45);
            this.trackBar3.TabIndex = 29;
            this.trackBar3.Scroll += new System.EventHandler(this.trackBar3_Scroll);
            // 
            // trackBar4
            // 
            this.trackBar4.Enabled = false;
            this.trackBar4.Location = new System.Drawing.Point(78, 342);
            this.trackBar4.Name = "trackBar4";
            this.trackBar4.Size = new System.Drawing.Size(201, 45);
            this.trackBar4.TabIndex = 30;
            this.trackBar4.Scroll += new System.EventHandler(this.trackBar4_Scroll);
            // 
            // trackBar5
            // 
            this.trackBar5.Enabled = false;
            this.trackBar5.Location = new System.Drawing.Point(375, 180);
            this.trackBar5.Name = "trackBar5";
            this.trackBar5.Size = new System.Drawing.Size(201, 45);
            this.trackBar5.TabIndex = 31;
            this.trackBar5.Scroll += new System.EventHandler(this.trackBar5_Scroll);
            // 
            // trackBar6
            // 
            this.trackBar6.Enabled = false;
            this.trackBar6.Location = new System.Drawing.Point(375, 231);
            this.trackBar6.Name = "trackBar6";
            this.trackBar6.Size = new System.Drawing.Size(201, 45);
            this.trackBar6.TabIndex = 32;
            this.trackBar6.Scroll += new System.EventHandler(this.trackBar6_Scroll);
            // 
            // trackBar7
            // 
            this.trackBar7.Enabled = false;
            this.trackBar7.Location = new System.Drawing.Point(375, 282);
            this.trackBar7.Name = "trackBar7";
            this.trackBar7.Size = new System.Drawing.Size(201, 45);
            this.trackBar7.TabIndex = 33;
            this.trackBar7.Scroll += new System.EventHandler(this.trackBar7_Scroll);
            // 
            // trackBar8
            // 
            this.trackBar8.Enabled = false;
            this.trackBar8.Location = new System.Drawing.Point(375, 342);
            this.trackBar8.Name = "trackBar8";
            this.trackBar8.Size = new System.Drawing.Size(201, 45);
            this.trackBar8.TabIndex = 34;
            this.trackBar8.Scroll += new System.EventHandler(this.trackBar8_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 291);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "motor3";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 342);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "motor4";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(331, 342);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 40;
            this.label7.Text = "motor8";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(330, 291);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "motor7";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(330, 231);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 38;
            this.label9.Text = "motor6";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(331, 180);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 13);
            this.label10.TabIndex = 37;
            this.label10.Text = "motor5";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 419);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.trackBar8);
            this.Controls.Add(this.trackBar7);
            this.Controls.Add(this.trackBar6);
            this.Controls.Add(this.trackBar5);
            this.Controls.Add(this.trackBar4);
            this.Controls.Add(this.trackBar3);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
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
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar8)).EndInit();
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
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.TrackBar trackBar4;
        private System.Windows.Forms.TrackBar trackBar5;
        private System.Windows.Forms.TrackBar trackBar6;
        private System.Windows.Forms.TrackBar trackBar7;
        private System.Windows.Forms.TrackBar trackBar8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}

