using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RobotMimiczny
{
    // Klasa służąca do obsługi głównego okna
    class FacePackage
    {

        //potrzeba zestawu dla miny neutralnej
        //potrzeba zestawu min domyślnych
        //na uC każda mina ma swój IP przyporządkowany do fizycznego przycisku

        //Struktura przechowująca dane dotyczące miny
        struct Face
        {
            public string faceName;
            public int[] servoSetting;

            //funkcja umożliwiająca tworzenie miny i wypełnianie ustawień silników
            public Face(string nFaceName, int[] nServoSetting)
            {
                faceName=nFaceName;
                servoSetting= new int [nServoSetting.Length];
                for (int i=0;i<nServoSetting.Length;i++)
                {
                    servoSetting[i]=nServoSetting[i];
                }
            }

        }

        Face [] faces;

        //funkcja tworząca zestaw ośmiu min
        public FacePackage()
        {
            faces = new Face[8];
        }

        //funkcja zwracająca listę nazw min
        public List<string> GetFacesNameList()
        {
            List<string> nameList = new List<string>();

            foreach (Face face in faces)
            {
                if (!String.IsNullOrEmpty(face.faceName))
                {
                    nameList.Add(face.faceName);
                }
            }
            return nameList;
        }

        //funkcja zapisująca zestaw min do pliku
        public void SaveToFile(string filePath)
        {
        }
        
        //funkcja odczytująca zestaw min z pliku
        //format pliku: ???
        public void ReadFromFile(Stream myStream)
        {
            StreamReader reader = new StreamReader(myStream);
            string line;
            int counter = 0;
            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split(';');
                int[] settingsFromFile = new int[data.Length - 1];
                string faceNameFromFile;

                faceNameFromFile = data[0];

                for (int i = 1; i < data.Length; i++)
                {
                    settingsFromFile[i - 1] = Int32.Parse(data[i]);
                }
                AddFace(faceNameFromFile, settingsFromFile,counter);
                counter++;
            }
        }

        //
        public void AddFace(string name, int[] settings, int number)
        {
            faces[number] = new Face(name, settings);
        }

        //
        public void RemoveFace(string name)
        {
            
        }

        //funkcja zwracająca wektor ustawień silników dla danej miny lub 0
        public int GetSetting(string name, int numberOfMotor)
        {
            foreach (Face face in faces)
            {
                if (face.faceName.Contains(name))
                {
                    return face.servoSetting[numberOfMotor-1];
                }
            }
            return 0;
        }

        //funkcja ustawiająca dany silnik w danej minie
        public void SetSetting(string name, int numberOfMotor, int newValue)
        {
            foreach (Face face in faces)
            {
                if (face.faceName.Contains(name))
                {
                    face.servoSetting[numberOfMotor - 1]=newValue;
                    return;
                }
            }
        }






    }


}
