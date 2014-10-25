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

        List<Face> faceList;

        public FacePackage()
        {
            faceList = new List<Face>();
        }

        public string[] GetFacesNameList()
        {
            string[] nameList = new string[faceList.Count];

            int i = 0;
            foreach (Face face in faceList)
            {
                nameList[i] = face.faceName;
                i++;
            }
            return nameList;
        }


        public void SaveToFile(string filePath)
        {
        }
            
        public void ReadFromFile(Stream myStream)
        {
            StreamReader reader = new StreamReader(myStream);
            string line;
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
                AddFace(faceNameFromFile, settingsFromFile);
            }
        }

        public void AddFace(string name, int[] settings)
        {
            faceList.Add(new Face(name, settings));
        }
        
        public void RemoveFace(string name)
        {
            foreach (Face face in faceList)
            {
                if (face.faceName.Contains(name))
                {
                    faceList.Remove(face);
                    break;
                }
            }
        }

        public int GetSetting(string name, int numberOfMotor)
        {
            foreach (Face face in faceList)
            {
                if (face.faceName.Contains(name))
                {
                    return face.servoSetting[numberOfMotor-1];
                }
            }
            return 0;
        }

        public void SetSetting(string name, int numberOfMotor, int newValue)
        {
            foreach (Face face in faceList)
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
