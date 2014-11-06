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


        // Ustawianie liczby bitow w ramce danych 
        // int newBits - nowa liczba bitow
        // Zwraca zero
        public int setDataBits(int newBits)
        {
            dataBits = Convert.ToString(newBits);
            return 0;
        }

        // Ustawianie rodzaju parzystosci w ramce danych 
        // string newParity - nowa parzystość (możliwe tylko: none, odd, even, mark, space)
        // Zwraca zero
        public int setParity(string newParity)
        {
            parity = newParity;
            return 0;
        }

        // Ustawianie liczby bitow stopu w ramce danych 
        // int newStopBits - nowa liczba bitow stopu (możliwe tylko: "1","1,5","2")
        // Zwraca zero
        public int setStopBits(int newStopBits)
        {
            stopBits = Convert.ToString(newStopBits);
            return 0;
        }

        // Ustawianie typu handshake w ramce danych 
        // string newHandshake - nowy handshake
        // Zwraca zero
        public int setHandshake(string newHandshake)
        {
            handshake = newHandshake;
            return 0;
        }

        // Ustawianie prędkosci polaczenia
        // int newBaudRate - nowa predkosc polaczenia
        // Zwraca zero
        public int setbaudRate(int newBaudRate)
        {
            baudRate = Convert.ToString(newBaudRate);
            return 0;
        }

        // Przywraca domyslne ustawienia polaczenia
        // Funkcja bez parametrów
        // Zwraca zero
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
        // int iloscZapytan - ilosc prob odczytu danych
        // Zwraca odczytaną linie lub error ("brak odpowiedzi")
        public string Read(int iloscZapytan)
        {
            _serialPort.NewLine = "0xA0";
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


                if (s != "COM15") //do wyrzucenia, uzywane przy termianalu
                {
                    _serialPort.NewLine = "$A0";              //Pamiętać ustawić odpowiedni znak konca lini ->ustawić zgodnie z elektronikami
                    _serialPort.Open();
                    //Console.WriteLine(s);
                    _serialPort.WriteLine("$FF$01$AF");       //Kim jestem ->ustawić zgodnie z elektronikami
                    while (_continue)
                    {
                        _serialPort.NewLine = "0xA0";          //Pamiętać ustawić odpowiedni znak konca lini ->ustawić zgodnie z elektronikami
                        try
                        {
                            if (_serialPort.ReadLine() == "0xFF0x010xFF")
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
                    }
                    _serialPort.Close();
                }
            }
            return portName;
        }

        public string[] SetPortName()
        {
            string[] portNames = new string[50];
            int j = 0;

            foreach (string s in SerialPort.GetPortNames())
            {
                if (j < 50)         //zapewnienie nie przepelnienia talbicy
                {
                    portNames[j] = s;
                    j++;
                }

            }
            return portNames;
        }



        // Wysyłanie danych
        // int[,] sets      - Wektor danych typu int (dla commandNr 1-8 i 10 - tablica [1][16] dla commandNr 9 tablica [8][16]
        // int commandNr    - Numer Komendy
        //                  - 0-7 -> zapis min 1-8
        //                  - 9 -> zapis 8 min na raz
        //                  - 10 -> tryb RUN
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


        // Pobieranie ustawien z uC
        // Funkcja bez parametrów
        // Zwraca tablice jednowymiarowa z nieobrobionymi stringami 
        //                          (format stringow: "0xFF0x010x0A0x000x220x000x000x000x000x000x000x000x000x000x000x000x000x000x00"
        //                           gdzie 0xFF0x010 - komenda
        //                                 0x0A - numer miny
        //                                 reszta - nastawy serw
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


        // Who Am I
        // Funkcja bez parametrów
        // Zwraca 0 jesli wszystko jest ok i 1 jesli nie ma odpowiedzi
        public int HAI()
        {
            int blad = 1;
            _serialPort.NewLine = "$A0";
            _serialPort.WriteLine("$FF$01$A0");       //format ramki ->ustawić zgodnie z elektronikami
            if (Read(3) == "0xFF0x010xFF")
            {
                blad = 0;
            }
            return blad;
        }
    }
}
