using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace RobotMimiczny
{
    // Klasa służąca do obsługi głównego okna
    class FacePackage
    {
        //Struktura przechowująca dane dotyczące miny
        struct Face
        {
            public string faceName;
            public int[] servoSetting;

            //Funkcja umożliwiająca tworzenie miny i wypełnianie ustawień silników
            public Face(string nFaceName, int[] nServoSetting)
            {
                faceName = nFaceName;
                servoSetting = new int[nServoSetting.Length];
                for (int i = 0; i < nServoSetting.Length; i++)
                {
                    servoSetting[i] = nServoSetting[i];
                }
            }

        }

        Face[] faces;

        //funkcja tworząca zestaw ośmiu min
        public FacePackage()
        {
            faces = new Face[8];
        }


        //Funkcja wypełniajaca zestaw domyślnymi nazwami i zerowymi ustawieniami
        public void NewEmpyFacePackage()
        {
            for (int j = 0; j < 8; j++)
            {
                string faceName = "Mina "+j.ToString();
                int[] settings = new int[16];

                for (int i = 0; i < 16; i++)
                {
                    settings[i] = 0;
                }
                AddFace(faceName, settings, j);
            }
        }

        //Funkcja zwracająca tablicę nazw min
        public string[] GetFacesTable()
        {
            string[] nameList = new string[8];

            for (int i=0;i<8;i++) 
            {
                nameList[i] = faces[i].faceName;
            }
            return nameList;
        }


        //Funkcja odczytująca zestaw min z pliku (.txt)
        public bool ReadFromFile(Stream myStream)
        {
            StreamReader reader = new StreamReader(myStream);
            string line;
            int counter = 0;
            try
            {
                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(';');
                    int[] settingsFromFile = new int[16];
                    string faceNameFromFile;

                    faceNameFromFile = data[0];

                    for (int i = 1; i < 17; i++)
                    {
                        settingsFromFile[i - 1] = Int32.Parse(data[i]);
                    }
                    AddFace(faceNameFromFile, settingsFromFile, counter);
                    counter++;
                }
                for (int j = counter; j < 8; j++)
                {
                    string faceName = "Mina " + j.ToString();
                    int[] settings = new int[16];

                    for (int i = 0; i < 16; i++)
                    {
                        settings[i] = 0;
                    }
                    AddFace(faceName, settings, j);
                }
                return true;
            }
            catch 
            {
                MessageBox.Show("Niepoprawna zawartość pliku", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
        }

        //Dodanie nowej miny 
        public void AddFace(string name, int[] settings, int number)
        {
            faces[number] = new Face(name, settings);
        }


        //Funkcja zwracająca tablicę ustawień serw dla danej miny
        public int[] GetSettingsList(string name)
        {
            foreach (Face face in faces)
            {
                if (face.faceName.Contains(name))
                {
                    return face.servoSetting;
                }
            }
            return null;
        }

        //Funkcja zwracająca ustawienie danego silnika dla danej miny
        public int GetSetting(string name, int numberOfMotor)
        {
            foreach (Face face in faces)
            {
                if (face.faceName.Contains(name))
                {
                    return face.servoSetting[numberOfMotor - 1];
                }
            }
            return 0;
        }

        //Funkcja ustawiająca dany silnik w danej minie
        public void SetSetting(int numberOfName, int numberOfMotor, int newValue)
        {
            faces[numberOfName].servoSetting[numberOfMotor - 1] = newValue;
        }

        //Funkcja ustawiająca nazwę miny na danej pozycji
        public void SetName(string newName, int numberOfName)
        {
            faces[numberOfName].faceName = newName;
        }

        //Pobranie numeru miny o danej nazwie
        public int GetFaceNumber(string name)
        {
            for (int i = 0; i < 8; i++)
            {
                if (faces[i].faceName.Contains(name))
                {
                    return i;
                }
            }
            return 0;
        }

    }

}
