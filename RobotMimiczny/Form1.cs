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
        int numberOfServos = 5;

        public Form1()
        {
            InitializeComponent();
        }

        private void cBxChooseFace_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(cBxChooseFace.SelectedItem.ToString()))
            {
                btnRemoveFace.Enabled = false;
                btnExecuteFace.Enabled = false;
            }
            else
            {
                trackBar1.Value = openedFacePackage.GetSetting(cBxChooseFace.SelectedItem.ToString(), 1);
                trackBar2.Value = openedFacePackage.GetSetting(cBxChooseFace.SelectedItem.ToString(), 2);
                btnRemoveFace.Enabled = true;
                btnExecuteFace.Enabled = true;
            }
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {

        }

        private void btnExecuteFace_Click(object sender, EventArgs e)
        {

        }

        private void menuItemNewPackage_Click(object sender, EventArgs e)
        {
            openedFacePackage = new FacePackage();
            cBxChooseFace.Items.Clear();

            cBxChooseFace.Enabled = true;
            btnAddFace.Enabled = true;
            textBox1.Enabled = true;
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
                        cBxChooseFace.Items.Clear();
                        cBxChooseFace.Text = "";
                        openedFacePackage = new FacePackage();
                        openedFacePackage.ReadFromFile(myStream);

                        string[] faceList = openedFacePackage.GetFacesNameList();
                        foreach (string name in faceList)
                        {
                            cBxChooseFace.Items.Add(name);
                        }

                        cBxChooseFace.Enabled = true;
                        btnAddFace.Enabled = true;
                        textBox1.Enabled = true;

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

        private void btnAddFace_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Wprowadź nazwę miny");
                return;
            }
            foreach (string name in cBxChooseFace.Items)
            {
                if (name.Contains(textBox1.Text))
                {
                    MessageBox.Show("Istnieje już mina o danej nazwie");
                    return;
                }
            }
            int [] newSettings= new int [numberOfServos];
            for (int i=0;i<newSettings.Length;i++)
            {
                newSettings[i]=0;
            }
            openedFacePackage.AddFace(textBox1.Text, newSettings);
            cBxChooseFace.Items.Add(textBox1.Text);
            textBox1.Clear();
        }

        private void btnRemoveFace_Click(object sender, EventArgs e)
        {
            openedFacePackage.RemoveFace(cBxChooseFace.SelectedItem.ToString());
            cBxChooseFace.Items.Remove(cBxChooseFace.SelectedItem.ToString());
            ResetTrackBarValues();

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
            openedFacePackage.SetSetting(cBxChooseFace.SelectedItem.ToString(), 1, trackBar1.Value);
        }


        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            openedFacePackage.SetSetting(cBxChooseFace.SelectedItem.ToString(), 2, trackBar2.Value);
        }
    }
}
