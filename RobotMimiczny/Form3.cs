using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotMimiczny
{
    public partial class Form3 : Form
    {
        static System.IO.StreamReader file;
        static string line;

        public Form3()
        {
            InitializeComponent();
            file = new System.IO.StreamReader(@"config\Help.txt");

            line = file.ReadToEnd();
            richTextBox1.Text = line;

           
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
