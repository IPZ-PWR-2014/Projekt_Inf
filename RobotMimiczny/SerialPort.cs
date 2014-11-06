using System;
using System.IO.Ports;
using System.Threading;

namespace RobotMimiczny
{
    class COM
    {
        static bool _continue;
        static SerialPort _serialPort;


        string dataBits = "8";      //parametry połączenia ->ustawić zgodnie z elektronikami
        string parity = "none";
        string stopBits = "1";
        string handshake = "none";
        string baudRate = "9600";

        public int setDataBits(int newBits)
        {
            dataBits = Convert.ToString(newBits);
            return 0;
        }
        public int setParity(string newParity)
        {
            parity = newParity;
            return 0;
        }
        public int setStopBits(int newStopBits)
        {
            stopBits = Convert.ToString(newStopBits);
            return 0;
        }
        public int setHandshake(string newHandshake)
        {
            handshake = newHandshake;
            return 0;
        }
        public int setbaudRate(int newBaudRate)
        {
            baudRate = Convert.ToString(newBaudRate);
            return 0;
        }

        public int defaultSet()
        {
            dataBits = "8";
            parity = "none";
            stopBits = "1";
            handshake = "none";
            baudRate = "9600";
            return 0;
        }

        // Inicjalizacja połączenia
        // Funkcja bez parametrów
        // Zwraca nazwę portu lub komunikat "Nie ma urządzenia"
        public string initialization()
        {
            string name;
            _serialPort = new SerialPort();

            _serialPort.BaudRate = int.Parse(baudRate);
            _serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), parity, true);
            _serialPort.DataBits = int.Parse(dataBits.ToUpperInvariant());
            _serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), stopBits, true);
            _serialPort.Handshake = (Handshake)Enum.Parse(typeof(Handshake), handshake, true);

            name = FindPortName();
            if (name != "Nie ma urządzenia")    //sprawdzanie czy odnaleziono odpowiedni port 
            {
                _serialPort.PortName = name;

                _serialPort.ReadTimeout = 500;  //czasy oczekiwania
                _serialPort.WriteTimeout = 500;
                _serialPort.NewLine = "$A0";      //sprawdzić czy ustawiono odpowiedni znak konca lini ->ustawić zgodnie z elektronikami
                _serialPort.Open();
            }
            return name;
        }

        // Zamykanie połączenia z portem
        // Funkcja bez parametrów
        // Funkcja nic nie zwraca
        public void close()
        {
            _serialPort.Close();
        }

        // Odczyt danych
        // Funkcja bez parametrów
        // Zwraca odczytaną linie lub error ("brak odpowiedzi")
        public string Read(int iloscZapytan)
        {
            int i = iloscZapytan;
            string message = "brak odpowiedzi";
            _continue = true;
            while (_continue)
            {
                try
                {
                    message = _serialPort.ReadLine();
                }
                catch (TimeoutException) { }
                i--;
                if (i == 0)
                {
                    _continue = false;
                }
            }
            return message;
        }

        // Wyszukiwanie portu pod które podpięte jest urządzenie
        // Funkcja bez parametrów
        // Zwraca nazwę portu lub komunikat "Nie ma urządzenia"
        public static string FindPortName()
        {
            string portName = "Nie ma urządzenia";
            int iloscZapytan = 0;

            foreach (string s in SerialPort.GetPortNames())
            {
                _continue = true;
                _serialPort.PortName = s;
                _serialPort.ReadTimeout = 500;
                _serialPort.WriteTimeout = 500;
                _serialPort.NewLine = "0xA0";          //Pamiętać ustawić odpowiedni znak konca lini ->ustawić zgodnie z elektronikami

                if (s != "COM15") //do wyrzucenia, uzywane przy termianalu
                {
                    _serialPort.Open();
                    Console.WriteLine(s);
                    _serialPort.WriteLine("$FF$01$AF");       //Kim jestem ->ustawić zgodnie z elektronikami
                    while (_continue)
                    {
                        try
                        {
                            if (_serialPort.ReadLine() == "1x")//$FF$01$FF")
                            {
                                portName = s;
                            }
                        }
                        catch (TimeoutException) { }
                        iloscZapytan++;
                        if (iloscZapytan == 3)
                        {
                            iloscZapytan = 0;
                            _continue = false;
                        }
                        Console.WriteLine(portName);
                    }
                    _serialPort.Close();
                }
            }
            return portName;
        }

        public string[] SetPortName()
        {
            string[] portNames = new string[20];
            int j = 0;

            foreach (string s in SerialPort.GetPortNames())
            {
                if (j < 20)
                {
                    portNames[j] = s;
                    Console.WriteLine(s);
                    Console.WriteLine(portNames[j]);
                    j++;
                }

            }
            return portNames;
        }



        // Wysyłanie danych
        // "set"        - Wektor danych typu int
        // "commandNr"  - Numer Komendy
        //              - 0-7 -> zapis min 1-8
        //              - 10 -> zapis 8 min na raz
        //              - 9 -> tryb RUN
        // Zwraca zero
        public int sendFace(int[,] sets, int commandNr)
        {
            string[] command = { "0A", "0B", "0C", "0D", "0F", "10", "11", "AA", "1A" };
            int blad = 0;


            for (int j = 0; j < sets.GetLength(0); j++)
            {
                _serialPort.NewLine = "$";              //zmiana znaku konca lini na czas wysyłania w celu zachowania formatu ramki
                _serialPort.WriteLine("$FF$01");       //format ramki ->ustawić zgodnie z elektronikami

                if (commandNr == 10)
                {
                    _serialPort.WriteLine(command[j]);
                }
                else
                {
                    _serialPort.WriteLine(command[commandNr]);
                }

                for (int i = 0; i < sets.GetLength(1); i++)
                {
                    if (i == sets.GetLength(1) - 1)
                    {
                        _serialPort.NewLine = "$A0";            //powrót do starego znaku konca lini ->ustawić zgodnie z elektronikami
                    }
                    _serialPort.WriteLine(Convert.ToString(sets[j, i]));
                }
            }
            if (Read(1) == "brak odpowiedzi")
            {
                blad = 1;
            }
            return blad;
        }

        public string[] downloadFace()
        {
            string[] faceSets = new string[10];
            string[] blad = new string[10];

            _serialPort.WriteLine("$FF$01$01");
            for (int i = 0; i < 8; i++)
            {
                faceSets[i] = Read(1);
                if (faceSets[i] == "brak odpowiedzi")
                {
                    blad[0] = "brak odpowiedzi";
                    return blad;
                }
            }
            return faceSets;
        }

        public int HAI()
        {
            int blad = 1;
            _serialPort.WriteLine("$FF$01$A0");       //format ramki ->ustawić zgodnie z elektronikami
            if (Read(3) == "FF01FFA0")
            {
                blad = 0;
            }
            return blad;
        }
    }
}






