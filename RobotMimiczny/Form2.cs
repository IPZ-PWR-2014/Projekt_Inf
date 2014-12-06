﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RobotMimiczny
{
    // Okno odpowiedzialne za parametry połączenia
    public partial class Form2 : Form
    {
        public int przeslij;
        public string[] parametry = new string[6];

        public Form2()
        {
            InitializeComponent();
            parametry[5] = Port.Text;
            parametry[0] = BaudRate.Text;
            parametry[1] = DataBits.Text;
            parametry[2] = StopBits.Text;
            parametry[3] = Parity.Text;
            parametry[4] = FlowControl.Text;
        }

        // Przycisk ANULUJ - zamyka okno
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        // Przycisk DOMYŚLNE - wprowadza w pola domyślne ustawienia
        private void button3_Click(object sender, EventArgs e)
        {
            Port.Text = "COM1";
            BaudRate.Text = "9600";
            DataBits.Text = "8";
            StopBits.Text = "1";
            Parity.Text = "none";
            FlowControl.Text = "none";
        }

        // Przycisk OK - przypisuje ustawione wartości i zamyka okno
        private void button1_Click(object sender, EventArgs e)
        {
            przeslij = 1;
            parametry[5] = Port.Text;
            parametry[0] = BaudRate.Text;
            parametry[1] = DataBits.Text;
            parametry[2] = StopBits.Text;
            parametry[3] = Parity.Text;
            parametry[4] = FlowControl.Text;
            this.Hide();
        }
    }
}
