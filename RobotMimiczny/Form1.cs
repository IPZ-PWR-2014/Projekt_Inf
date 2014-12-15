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
        int clickedButton;
        bool saved = true;
        bool savedToFile = true;
        int licznik = 0;

        public Form1()
        {
            InitializeComponent();
        }

        //Funkcja wywoływana po kliknięciu przycisku "Zapisz
        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            openedFacePackage.SetName(currentFace, clickedButton);
            openedFacePackage.SetSetting(clickedButton, 1, trackBar1.Value);
            openedFacePackage.SetSetting(clickedButton, 2, trackBar2.Value);
            openedFacePackage.SetSetting(clickedButton, 3, trackBar3.Value);
            openedFacePackage.SetSetting(clickedButton, 4, trackBar4.Value);
            openedFacePackage.SetSetting(clickedButton, 5, trackBar5.Value);
            openedFacePackage.SetSetting(clickedButton, 6, trackBar6.Value);
            openedFacePackage.SetSetting(clickedButton, 7, trackBar7.Value);
            openedFacePackage.SetSetting(clickedButton, 8, trackBar8.Value);

            savedToFile = false;
            saved = true;
        }

        //Udostępnienie przycisków, suwaków itp. po wczytaniu/utworzeniu konfiguracji
        private void PrepareWindowForEditPackage()
        {
            EnableAllButtons();
            EnableTextBoxesForTrackBars();
            EnableAllTrackBars();

            btnSaveSettings.Enabled = true;
            menuItemSavePackageToFile.Enabled = true;
            btnExecuteFace.Enabled = true;
            chBxRun.Enabled = true;

            btnFace1_Click(null, null);

            saved = true;
            savedToFile = false;
        }

        //Sprawdzenie czy bieżące ustawienie są zapisane dla aktualnie edytowanego zestawu,
        //wywoływana przed zmianą edytowanej miny
        private void SaveControl()
        {
            if (!saved)
            {
                const string message = "Bieżące ustawienia silników, nie zostały zapisane, czy chcesz je zapisać?";
                const string caption = "";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    btnSaveSettings_Click(null, null);
                }
                saved = true;
            }
        }

        //Sprawdzenie czy bieżąca konfiguracja została zapamietana w pliku
        private void SaveControlForNewPackage()
        {
            if (!savedToFile)
            {
                const string message = "Bieżąca konfiguracja nie została zapisana do pliku, czy chcesz to zrobić teraz?";
                const string caption = "";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    menuItemSavePackageToFile_Click(null, null);

                }
                savedToFile = true;
            }
        }

       private void SendActualDataToDevice()
       {
           int[,] dataToSend = new int[1, 16];
            dataToSend[0, 0] = trackBar1.Value;
            dataToSend[0, 1] = trackBar2.Value;
            dataToSend[0, 2] = trackBar3.Value;
            dataToSend[0, 3] = trackBar4.Value;
            dataToSend[0, 4] = trackBar5.Value;
            dataToSend[0, 5] = trackBar6.Value;
            dataToSend[0, 6] = trackBar7.Value;
            dataToSend[0, 7] = trackBar8.Value;


           timer2.Enabled=false;
           if(komunikacja.send(dataToSend, 10)!=1&&chBxRun.Checked)
           {
               timer2.Enabled=true;
           }
       }
       

        //Funkcja wykonująca bieżące ustawienia na podłączonym zestawie
        private void btnExecuteFace_Click(object sender, EventArgs e)
        {
            SendActualDataToDevice();
        }

        //Funkcja wywoływana po wybraniu z menu opcji nowego zestawu, tworzy nową,
        //pustą konfigurację
        private void menuItemNewPackage_Click(object sender, EventArgs e)
        {
            SaveControl();
            SaveControlForNewPackage();

            openedFacePackage = new FacePackage();
            openedFacePackage.NewEmptyFacePackage();

            PrepareWindowForEditPackage();
        }

        //Funkcja wywoływana po wybraniu z menu opcji wczytania zestawu z pliku,
        //tworzy konfigurację na podstawie jego zawartości
        private void menuItemOpenPackageFromFile_Click(object sender, EventArgs e)
        {
            SaveControlForNewPackage();

            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "C:\\Users\\Agnieszka\\Desktop";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        openedFacePackage = new FacePackage();
                        if (openedFacePackage.ReadFromFile(myStream))
                        {
                            PrepareWindowForEditPackage();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nie można otworzyć pliku. Komunikat błędu: " + ex.Message);
                }
            }
        }

        //Funkcja pobierająca tablicę nazw aktualnie otwartego zestawu i wpisująca je
        //jako podpisy przycisków
        private void GetFacesName()
        {
            string[] faceTable = openedFacePackage.GetFacesTable();
            textBox1.Text = faceTable[0];
            textBox2.Text = faceTable[1];
            textBox3.Text = faceTable[2];
            textBox4.Text = faceTable[3];
            textBox5.Text = faceTable[4];
            textBox6.Text = faceTable[5];
            textBox7.Text = faceTable[6];
            textBox8.Text = faceTable[7];
        }

        //Funkcja wywoływana po wybraniu z menu opcji zapisu do pliku,
        //zapisuje aktualnie otwartą konfigurację do pliku tekstowego
        private void menuItemSavePackageToFile_Click(object sender, EventArgs e)
        {
            SaveControl();
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    using (StreamWriter writer = new StreamWriter(myStream))
                    {
                        foreach (string name in openedFacePackage.GetFacesTable())
                        {
                            writer.Write(name + ";");
                            int[] settingsList = openedFacePackage.GetSettingsList(name);
                            foreach (int oneSetting in settingsList)
                            {
                                writer.Write(oneSetting + ";");
                            }
                            writer.WriteLine();
                        }
                        savedToFile = true;
                    }
                }
            }
        }


        private void menuItemExportPackageToDevice_Click(object sender, EventArgs e)
        {
            SaveControl();
            timer1.Enabled = false;

            int[,] dataToSend = new int[8, 16];

            for (int i = 0; i < 8; i++)
            {
                dataToSend[0, i] = openedFacePackage.GetSettingsList(textBox1.Text)[i];
                dataToSend[1, i] = openedFacePackage.GetSettingsList(textBox2.Text)[i];
                dataToSend[2, i] = openedFacePackage.GetSettingsList(textBox3.Text)[i];
                dataToSend[3, i] = openedFacePackage.GetSettingsList(textBox4.Text)[i];
                dataToSend[4, i] = openedFacePackage.GetSettingsList(textBox5.Text)[i];
                dataToSend[5, i] = openedFacePackage.GetSettingsList(textBox6.Text)[i];
                dataToSend[6, i] = openedFacePackage.GetSettingsList(textBox7.Text)[i];
                dataToSend[7, i] = openedFacePackage.GetSettingsList(textBox8.Text)[i];
            }

            komunikacja.send(dataToSend, 9);
            MessageBox.Show("Dane zostały wyeksportowane poprawnie");
            timer1.Enabled = true;
        }


        private void menuItemImportPackageFromDevice_Click(object sender, EventArgs e)
        {
            SaveControl();
            SaveControlForNewPackage();

            int[,] split;
            string[] dataTables = komunikacja.readSettings();
            split = new int[8, 8];
            for (int i = 0; i < 8; i++)
            {
                string[] temp = dataTables[i].Split('$');
                for (int j = 0; j < 8; j++)
                {
                    split[i, j] = Convert.ToInt32(temp[j + 2]);
                }
            }

            openedFacePackage = new FacePackage();
            openedFacePackage.NewEmptyFacePackage();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    openedFacePackage.SetSetting(i, j + 1, split[i, j]);
                }
            }
            MessageBox.Show("Dane zostały wczytane poprawnie");
            PrepareWindowForEditPackage();
        }

        //Funkcja obsługująca zdarzenie zmiany statusu zaznaczenia checkBoxa
        private void chBxRun_CheckedChanged(object sender, EventArgs e)
        {
            if (chBxRun.Checked)
            {
                btnExecuteFace.Enabled = false;
                timer2.Enabled = true;
            }
            else
            {
                btnExecuteFace.Enabled = true;
                timer2.Enabled = false;
            }
        }

        private void RunMode_Tick(object sender, EventArgs e)
        {
            SendActualDataToDevice();
        }

        //Funkcja ustawiająca wartości wszystkich suwaków na 0
        private void ResetTrackBarValues()
        {
            trackBar1.Value = 0;
            trackBar2.Value = 0;
            trackBar3.Value = 0;
            trackBar4.Value = 0;
            trackBar5.Value = 0;
            trackBar6.Value = 0;
            trackBar7.Value = 0;
            trackBar8.Value = 0;
        }

        private void SetTrackBarsValue(string faceName)
        {
            currentFace = faceName;
            trackBar1.Value = openedFacePackage.GetSetting(faceName, 1);
            trackBar2.Value = openedFacePackage.GetSetting(faceName, 2);
            trackBar3.Value = openedFacePackage.GetSetting(faceName, 3);
            trackBar4.Value = openedFacePackage.GetSetting(faceName, 4);
            trackBar5.Value = openedFacePackage.GetSetting(faceName, 5);
            trackBar6.Value = openedFacePackage.GetSetting(faceName, 6);
            trackBar7.Value = openedFacePackage.GetSetting(faceName, 7);
            trackBar8.Value = openedFacePackage.GetSetting(faceName, 8);
            SetValuesInTextBoxesFromTrackBars();


        }

        //Zablokowanie textBoxes dla podpisów min
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

        //Udostępnienie edycji suwaków
        private void EnableAllTrackBars()
        {
            trackBar1.Enabled = true;
            trackBar2.Enabled = true;
            trackBar3.Enabled = true;
            trackBar4.Enabled = true;
            trackBar5.Enabled = true;
            trackBar6.Enabled = true;
            trackBar7.Enabled = true;
            trackBar8.Enabled = true;
        }

        //Udostępnienie przycisków
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

        //Udostępnienie pól do zmiany suwaków
        private void EnableTextBoxesForTrackBars()
        {
            txtBxTrackBar1.Enabled = true;
            txtBxTrackBar2.Enabled = true;
            txtBxTrackBar3.Enabled = true;
            txtBxTrackBar4.Enabled = true;
            txtBxTrackBar5.Enabled = true;
            txtBxTrackBar6.Enabled = true;
            txtBxTrackBar7.Enabled = true;
            txtBxTrackBar8.Enabled = true;
        }

        //Ustawienie wartości w opisach suwaków
        private void SetValuesInTextBoxesFromTrackBars()
        {
            txtBxTrackBar1.Text = trackBar1.Value.ToString();
            txtBxTrackBar2.Text = trackBar2.Value.ToString();
            txtBxTrackBar3.Text = trackBar3.Value.ToString();
            txtBxTrackBar4.Text = trackBar4.Value.ToString();
            txtBxTrackBar5.Text = trackBar5.Value.ToString();
            txtBxTrackBar6.Text = trackBar6.Value.ToString();
            txtBxTrackBar7.Text = trackBar7.Value.ToString();
            txtBxTrackBar8.Text = trackBar8.Value.ToString();
        }



        //Grupa funkcji obsługująca kliknięcia przycisków,
        //ustawia na suwakach wartości dla aktualnie wybranej miny
        private void btnFace1_Click(object sender, EventArgs e)
        {
            SaveControl();
            GetFacesName();
            SetTrackBarsValue(textBox1.Text);
            BlockAllTextBoxes();
            textBox1.Enabled = true;
            btnFace1.Select();
            clickedButton = 0;
        }

        private void btnFace2_Click(object sender, EventArgs e)
        {
            SaveControl();
            GetFacesName();
            SetTrackBarsValue(textBox2.Text);
            BlockAllTextBoxes();
            textBox2.Enabled = true;
            clickedButton = 1;
        }

        private void btnFace3_Click(object sender, EventArgs e)
        {
            SaveControl();
            GetFacesName();
            SetTrackBarsValue(textBox3.Text);
            BlockAllTextBoxes();
            textBox3.Enabled = true;
            clickedButton = 2;
        }

        private void btnFace4_Click(object sender, EventArgs e)
        {
            SaveControl();
            GetFacesName();
            SetTrackBarsValue(textBox4.Text);
            BlockAllTextBoxes();
            textBox4.Enabled = true;
            clickedButton = 3;
        }

        private void btnFace5_Click(object sender, EventArgs e)
        {
            SaveControl();
            GetFacesName();
            SetTrackBarsValue(textBox5.Text);
            BlockAllTextBoxes();
            textBox5.Enabled = true;
            clickedButton = 4;
        }

        private void btnFace6_Click(object sender, EventArgs e)
        {
            SaveControl();
            GetFacesName();
            SetTrackBarsValue(textBox6.Text);
            BlockAllTextBoxes();
            textBox6.Enabled = true;
            clickedButton = 5;
        }

        private void btnFace7_Click(object sender, EventArgs e)
        {
            SaveControl();
            GetFacesName();
            SetTrackBarsValue(textBox7.Text);
            BlockAllTextBoxes();
            textBox7.Enabled = true;
            clickedButton = 6;
        }

        private void btnFace8_Click(object sender, EventArgs e)
        {
            SaveControl();
            GetFacesName();
            SetTrackBarsValue(textBox8.Text);
            BlockAllTextBoxes();
            textBox8.Enabled = true;
            clickedButton = 7;
        }


        //Grupa funkcji obsługujących zmiany położenia suwaków
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            txtBxTrackBar1.Text = trackBar1.Value.ToString();
            saved = false;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            txtBxTrackBar2.Text = trackBar2.Value.ToString();
            saved = false;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            txtBxTrackBar3.Text = trackBar3.Value.ToString();
            saved = false;
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            txtBxTrackBar4.Text = trackBar4.Value.ToString();
            saved = false;
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            txtBxTrackBar5.Text = trackBar5.Value.ToString();
            saved = false;
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            txtBxTrackBar6.Text = trackBar6.Value.ToString();
            saved = false;
        }

        private void trackBar7_Scroll(object sender, EventArgs e)
        {
            txtBxTrackBar7.Text = trackBar7.Value.ToString();
            saved = false;
        }

        private void trackBar8_Scroll(object sender, EventArgs e)
        {
            txtBxTrackBar8.Text = trackBar8.Value.ToString();
            saved = false;
        }


        //Grupa funkcji obsługująca zmianę podpisu pod przyciskiem
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            saved = false;
            currentFace = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            saved = false;
            currentFace = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            saved = false;
            currentFace = textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            saved = false;
            currentFace = textBox4.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            saved = false;
            currentFace = textBox5.Text;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            saved = false;
            currentFace = textBox6.Text;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            saved = false;
            currentFace = textBox7.Text;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            saved = false;
            currentFace = textBox8.Text;
        }


        //Grupa funkcji obsługująca zmianę tekstu dla opisu suwaka
        private void txtBxTrackBar1_TextChanged(object sender, EventArgs e)
        {
            if (txtBxTrackBar1.Text.Equals(""))
                return;
            int number;
            bool result = Int32.TryParse(txtBxTrackBar1.Text, out number);
            if (result && number >= 0 && number <= 100)
            {
                trackBar1.Value = number;
            }
            else
            {
                if (number < 50)
                {
                    trackBar1.Value = 0;
                    txtBxTrackBar1.Text = "0";
                }
                else if (number >= 50)
                {
                    trackBar1.Value = 100;
                    txtBxTrackBar1.Text = "100";
                }
                MessageBox.Show("Wpisz wartość z przedziału 1-100");
            }

        }

        private void txtBxTrackBar2_TextChanged(object sender, EventArgs e)
        {
            if (txtBxTrackBar2.Text.Equals(""))
                return;
            int number;
            bool result = Int32.TryParse(txtBxTrackBar2.Text, out number);
            if (result && number >= 0 && number <= 100)
            {
                trackBar2.Value = number;
            }
            else
            {
                if (number < 50)
                {
                    trackBar2.Value = 0;
                    txtBxTrackBar2.Text = "0";
                }
                else if (number >= 50)
                {
                    trackBar2.Value = 100;
                    txtBxTrackBar2.Text = "100";
                }
                MessageBox.Show("Wpisz wartość z przedziału 1-100");
            }
        }

        private void txtBxTrackBar3_TextChanged(object sender, EventArgs e)
        {
            if (txtBxTrackBar3.Text.Equals(""))
                return;
            int number;
            bool result = Int32.TryParse(txtBxTrackBar3.Text, out number);
            if (result && number >= 0 && number <= 100)
            {
                trackBar3.Value = number;
            }
            else
            {
                if (number < 50)
                {
                    trackBar3.Value = 0;
                    txtBxTrackBar3.Text = "0";
                }
                else if (number >= 50)
                {
                    trackBar3.Value = 100;
                    txtBxTrackBar3.Text = "100";
                }
                MessageBox.Show("Wpisz wartość z przedziału 1-100");
            }
        }

        private void txtBxTrackBar4_TextChanged(object sender, EventArgs e)
        {
            if (txtBxTrackBar4.Text.Equals(""))
                return;
            int number;
            bool result = Int32.TryParse(txtBxTrackBar4.Text, out number);
            if (result && number >= 0 && number <= 100)
            {
                trackBar4.Value = number;
            }
            else
            {
                if (number < 50)
                {
                    trackBar4.Value = 0;
                    txtBxTrackBar4.Text = "0";
                }
                else if (number >= 50)
                {
                    trackBar4.Value = 100;
                    txtBxTrackBar4.Text = "100";
                }
                MessageBox.Show("Wpisz wartość z przedziału 1-100");
            }
        }

        private void txtBxTrackBar5_TextChanged(object sender, EventArgs e)
        {
            if (txtBxTrackBar5.Text.Equals(""))
                return;
            int number;
            bool result = Int32.TryParse(txtBxTrackBar5.Text, out number);
            if (result && number >= 0 && number <= 100)
            {
                trackBar5.Value = number;
            }
            else
            {
                if (number < 50)
                {
                    trackBar5.Value = 0;
                    txtBxTrackBar5.Text = "0";
                }
                else if (number >= 50)
                {
                    trackBar5.Value = 100;
                    txtBxTrackBar5.Text = "100";
                }
                MessageBox.Show("Wpisz wartość z przedziału 1-100");
            }
        }

        private void txtBxTrackBar6_TextChanged(object sender, EventArgs e)
        {
            if (txtBxTrackBar6.Text.Equals(""))
                return;
            int number;
            bool result = Int32.TryParse(txtBxTrackBar6.Text, out number);
            if (result && number >= 0 && number <= 100)
            {
                trackBar6.Value = number;
            }
            else
            {
                if (number < 50)
                {
                    trackBar6.Value = 0;
                    txtBxTrackBar6.Text = "0";
                }
                else if (number >= 50)
                {
                    trackBar6.Value = 100;
                    txtBxTrackBar6.Text = "100";
                }
                MessageBox.Show("Wpisz wartość z przedziału 1-100");
            }
        }

        private void txtBxTrackBar7_TextChanged(object sender, EventArgs e)
        {
            if (txtBxTrackBar7.Text.Equals(""))
                return;
            int number;
            bool result = Int32.TryParse(txtBxTrackBar7.Text, out number);
            if (result && number >= 0 && number <= 100)
            {
                trackBar7.Value = number;
            }
            else
            {
                if (number < 50)
                {
                    trackBar7.Value = 0;
                    txtBxTrackBar7.Text = "0";
                }
                else if (number >= 50)
                {
                    trackBar7.Value = 100;
                    txtBxTrackBar7.Text = "100";
                }
                MessageBox.Show("Wpisz wartość z przedziału 1-100");
            }
        }

        private void txtBxTrackBar8_TextChanged(object sender, EventArgs e)
        {
            if (txtBxTrackBar8.Text.Equals(""))
                return;
            int number;
            bool result = Int32.TryParse(txtBxTrackBar8.Text, out number);
            if (result && number >= 0 && number <= 100)
            {
                trackBar8.Value = number;
            }
            else
            {
                if (number < 50)
                {
                    trackBar8.Value = 0;
                    txtBxTrackBar8.Text = "0";
                }
                else if (number >= 50)
                {
                    trackBar8.Value = 100;
                    txtBxTrackBar8.Text = "100";
                }
                MessageBox.Show("Wpisz wartość z przedziału 1-100");
            }
        }

        //Część Maćka
        Form2 form2 = new Form2();
        COM komunikacja = new COM();
        // Pokazanie okna odpowiedzialnego za ustawienia połączenia
        private void ustawieniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form2.Show();
            form2.BaudRate.Text = komunikacja.baudRate;
            form2.DataBits.Text = komunikacja.dataBits;
            form2.StopBits.Text = komunikacja.stopBits;
            form2.Parity.Text = komunikacja.parity;
            form2.FlowControl.Text = komunikacja.handshake;
            form2.Port.Items.Clear();
            foreach (string s in komunikacja.findAllAvailablePorts())
                form2.Port.Items.Add(s);
            if(form2.Port.Items.Count>0)
                form2.Port.SelectedIndex = 0;
        }

        // Timer sprawdzający co 5s czy połączenie jest nadal aktywne za pomocą metody HAI
        //oraz czy zostały zmienione parametry połączenia
        private void SprawdzeniePolaczenia_Tick(object sender, EventArgs e)
        {
            if (form2.przeslij == 1)
            {
                komunikacja.baudRate = form2.parametry[0];
                komunikacja.dataBits = form2.parametry[1];
                komunikacja.stopBits = form2.parametry[2];
                komunikacja.parity = form2.parametry[3];
                komunikacja.handshake = form2.parametry[4];
                form2.przeslij = 0;
            }
           
            if (komunikacja.HAI() == 0)
            {
                label13.Text = "Aktywne";
                label12.BackColor = System.Drawing.Color.Green;
                menuItemExportPackageToDevice.Enabled = true;
                menuItemImportPackageFromDevice.Enabled = true;
                licznik = 0;
            }
            else
            {
                label13.Text = "Nieaktywne";
                label12.BackColor = System.Drawing.Color.Red;
                menuItemExportPackageToDevice.Enabled = false;
                menuItemImportPackageFromDevice.Enabled = false;

                if (++licznik > 10)
                {
                    timer1.Enabled = false;
                    komunikacja.closeTransmision();
                }
            }
        }

        // Zainicjalizowanie połączenia
        private void połączToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (komunikacja.initializeTransmission().Equals("brak portu"))
                MessageBox.Show("Nie można utworzyć połączenia z urządzeniem.","Błąd połączenia");
            else
            {
                timer1.Enabled = true;
                //komunikacja.baudRate = form2.parametry[0];
                //komunikacja.dataBits = form2.parametry[1];
                //komunikacja.stopBits = form2.parametry[2];
                //komunikacja.parity = form2.parametry[3];
                //komunikacja.handshake = form2.parametry[4];
                form2.przeslij = 0;
                komunikacja.HAI();
            }
        }

        // Zakończenie połączenia
        private void rozłączToolStripMenuItem_Click(object sender, EventArgs e)
        {
            komunikacja.closeTransmision();
            menuItemExportPackageToDevice.Enabled = false;
            menuItemImportPackageFromDevice.Enabled = false;

            label13.Text = "Nieaktywne";
            label12.BackColor = System.Drawing.Color.Red;
            menuItemExportPackageToDevice.Enabled = false;
            menuItemImportPackageFromDevice.Enabled = false;
            timer1.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_Closed(object sender, System.EventArgs e)
        {
            SaveControl();
            SaveControlForNewPackage();
            rozłączToolStripMenuItem_Click(sender, e);
        }
    }
}