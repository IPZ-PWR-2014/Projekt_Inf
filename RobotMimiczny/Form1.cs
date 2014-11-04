using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotMimiczny
{
    public partial class Form1 : Form
    {

        FacePackage openedFacePackage;
        string currentFace;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            openedFacePackage.SetSetting(currentFace, 1, trackBar1.Value);
            openedFacePackage.SetSetting(currentFace, 2, trackBar2.Value);
        }

        private void btnExecuteFace_Click(object sender, EventArgs e)
        {

        }

        private void menuItemNewPackage_Click(object sender, EventArgs e)
        {
            openedFacePackage = new FacePackage();
            ResetTrackBarValues();
            EnableAllButtons();
        }

        private void menuItemOpenPackageFromFile_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        openedFacePackage = new FacePackage();
                        openedFacePackage.ReadFromFile(myStream);
                        GetFacesName();
                        EnableAllButtons();
                        btnSaveSettings.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void GetFacesName()
        {
            List<string> faceList = new List<string>();
            faceList = openedFacePackage.GetFacesNameList();
            textBox1.Text = faceList[0];
            textBox2.Text = faceList[1];
        }

        private void menuItemSavePackageToFile_Click(object sender, EventArgs e)
        {

        }

        private void menuItemExportPackageToDevice_Click(object sender, EventArgs e)
        {

        }

        private void menuItemImportPackageFromDevice_Click(object sender, EventArgs e)
        {

        }

        private void ResetTrackBarValues()
        {
            trackBar1.Value = 0;
            trackBar2.Value = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //openedFacePackage.SetSetting(cBxChooseFace.SelectedItem.ToString(), 1, trackBar1.Value);
        }


        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            //openedFacePackage.SetSetting(cBxChooseFace.SelectedItem.ToString(), 2, trackBar2.Value);
        }

        private void btnFace1_Click(object sender, EventArgs e)
        {
            SetTrackBarsValue(textBox1.Text);
            BlockAllTextBoxes();
            textBox1.Enabled = true;
        }

        private void btnFace2_Click(object sender, EventArgs e)
        {
            SetTrackBarsValue(textBox2.Text);
            BlockAllTextBoxes();
            textBox2.Enabled = true;
        }

        private void SetTrackBarsValue(string faceName)
        {
            currentFace = faceName;
            trackBar1.Value = openedFacePackage.GetSetting(faceName, 1);
            trackBar2.Value = openedFacePackage.GetSetting(faceName, 2);
        }

        private void BlockAllTextBoxes()
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
        }

        private void EnableAllButtons()
        {
            btnFace1.Enabled = true;
            btnFace2.Enabled = true;
            btnFace3.Enabled = true;
            btnFace4.Enabled = true;
            btnFace5.Enabled = true;
            btnFace6.Enabled = true;
            btnFace7.Enabled = true;
            btnFace8.Enabled = true;
        }


        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    btnFace1.Text = textBox1.Text;
            //    textBox1.Clear();
            //}
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btnFace3_Click(object sender, EventArgs e)
        {
            BlockAllTextBoxes();
            textBox3.Enabled = true;
            
        }

        private void btnFace4_Click(object sender, EventArgs e)
        {
            BlockAllTextBoxes();
            textBox4.Enabled = true;
            
        }

        private void btnFace5_Click(object sender, EventArgs e)
        {
            BlockAllTextBoxes();
            textBox5.Enabled = true;
            
        }

        private void btnFace6_Click(object sender, EventArgs e)
        {
            BlockAllTextBoxes();
            textBox6.Enabled = true;
        }

        private void btnFace7_Click(object sender, EventArgs e)
        {
            BlockAllTextBoxes();
            textBox7.Enabled = true;
        }

        private void btnFace8_Click(object sender, EventArgs e)
        {
            BlockAllTextBoxes();
            textBox8.Enabled = true;
        }

    }
}
