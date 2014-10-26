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
                        List<string> faceList = new List<string>();
                        faceList = openedFacePackage.GetFacesNameList();
                        btnFace1.Text = faceList[0];
                        btnFace2.Text = faceList[1];

                        btnSaveSettings.Enabled = true;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
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
            setTrackBarsValue(btnFace1.Text);
        }

        private void btnFace2_Click(object sender, EventArgs e)
        {
            setTrackBarsValue(btnFace2.Text);
        }

        private void setTrackBarsValue(string faceName)
        {
            currentFace = faceName;
            trackBar1.Value = openedFacePackage.GetSetting(faceName,1);
            trackBar2.Value = openedFacePackage.GetSetting(faceName, 2);
        }

    }
}
