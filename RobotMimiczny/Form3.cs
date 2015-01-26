/*! 
 *  \brief     Program do obsługi Robota Mimicznego. PWr Mechtronika 2 sem. MGR pod kierunkiem dr hab. inż., prof. nadzw. PWr Zbigniewa Zimniaka
 *  \author    inż. Paweł Duda 188192
 *  \author    inż. Jan Karwasiński 188124
 *  \author    inż. Agnieszka Nowaczyńska 188143
 *  \author    inż. Maciej Pałka 188197
 *  \author    inż. Łukasz Rdzeń 188175
 *  \author    inż. Michał Sarnowski 188199
 *  \date      rok akademicki 2014/2015
 */
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
