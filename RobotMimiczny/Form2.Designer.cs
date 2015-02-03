namespace RobotMimiczny
{
    partial class Form2
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
            this.Port = new System.Windows.Forms.ComboBox();
            this.BaudRate = new System.Windows.Forms.ComboBox();
            this.DataBits = new System.Windows.Forms.ComboBox();
            this.StopBits = new System.Windows.Forms.ComboBox();
            this.Parity = new System.Windows.Forms.ComboBox();
            this.FlowControl = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Baud rate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Data Bits";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Stop Bits";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Parity";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Flow control";
            // 
            // Port
            // 
            this.Port.FormattingEnabled = true;
            this.Port.Location = new System.Drawing.Point(82, 1);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(121, 21);
            this.Port.TabIndex = 6;
            // 
            // BaudRate
            // 
            this.BaudRate.FormattingEnabled = true;
            this.BaudRate.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600"});
            this.BaudRate.Location = new System.Drawing.Point(82, 23);
            this.BaudRate.Name = "BaudRate";
            this.BaudRate.Size = new System.Drawing.Size(121, 21);
            this.BaudRate.TabIndex = 7;
            // 
            // DataBits
            // 
            this.DataBits.FormattingEnabled = true;
            this.DataBits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.DataBits.Location = new System.Drawing.Point(82, 45);
            this.DataBits.Name = "DataBits";
            this.DataBits.Size = new System.Drawing.Size(121, 21);
            this.DataBits.TabIndex = 8;
            // 
            // StopBits
            // 
            this.StopBits.FormattingEnabled = true;
            this.StopBits.Items.AddRange(new object[] {
            "1",
            "1,5",
            "2"});
            this.StopBits.Location = new System.Drawing.Point(82, 67);
            this.StopBits.Name = "StopBits";
            this.StopBits.Size = new System.Drawing.Size(121, 21);
            this.StopBits.TabIndex = 9;
            // 
            // Parity
            // 
            this.Parity.FormattingEnabled = true;
            this.Parity.Items.AddRange(new object[] {
            "none",
            "odd",
            "even",
            "mark",
            "space"});
            this.Parity.Location = new System.Drawing.Point(82, 89);
            this.Parity.Name = "Parity";
            this.Parity.Size = new System.Drawing.Size(121, 21);
            this.Parity.TabIndex = 10;
            // 
            // FlowControl
            // 
            this.FlowControl.FormattingEnabled = true;
            this.FlowControl.Items.AddRange(new object[] {
            "hardware",
            "software",
            "none"});
            this.FlowControl.Location = new System.Drawing.Point(82, 111);
            this.FlowControl.Name = "FlowControl";
            this.FlowControl.Size = new System.Drawing.Size(121, 21);
            this.FlowControl.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1, 159);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(143, 159);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Anuluj";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(72, 159);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(61, 23);
            this.button3.TabIndex = 14;
            this.button3.Text = "Domyślne";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 184);
            this.ControlBox = false;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.FlowControl);
            this.Controls.Add(this.Parity);
            this.Controls.Add(this.StopBits);
            this.Controls.Add(this.DataBits);
            this.Controls.Add(this.BaudRate);
            this.Controls.Add(this.Port);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(225, 222);
            this.MinimumSize = new System.Drawing.Size(225, 222);
            this.Name = "Form2";
            this.Text = "Ustawienia połączenia";
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
        public System.Windows.Forms.ComboBox Port;
        public System.Windows.Forms.ComboBox BaudRate;
        public System.Windows.Forms.ComboBox DataBits;
        public System.Windows.Forms.ComboBox StopBits;
        public System.Windows.Forms.ComboBox Parity;
        public System.Windows.Forms.ComboBox FlowControl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}