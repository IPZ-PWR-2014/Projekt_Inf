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

            name = findPortName();
            if (name != "Nie ma urządzenia")    //sprawdzanie czy odnaleziono odpowiedni port 
            {
                _serialPort.PortName = name;

                _serialPort.ReadTimeout = 500;  //czasy oczekiwania
                _serialPort.WriteTimeout = 500;
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


        // Odczyt danych string
        // int iloscZapytan - ilosc prob odczytu danych
        // Zwraca odczytaną linie lub error ("brak odpowiedzi")
        public string read(int iloscZapytan)
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


        // biotwy odczyt danych
        // int iloscZapytan - ilosc prob odczytu danych
        // Zwraca odczytaną linie lub error ("brak odpowiedzi")
        public string readByByte(int iloscZapytan)
        {
            int i = iloscZapytan;
            int j =1;
            int [] message = new int[100];
            string messageInString = "";
            char temp = '$';

             message[0] = 0x00;
            _continue = true;

            while (message[j-1]!= 0xA0 && (_continue))
            {
                try
                {
                    message[j] = _serialPort.ReadByte();
                }
                catch (TimeoutException) 
                {
                    i--;
                    j--;
                }
                j++;
                if (i == 0)
                {
                    _continue = false;
                }
            }

            if (j > 1)
            {
                for (int k = 1; k < j - 1; k++)
                {
                    messageInString += message[k].ToString();
                    messageInString += temp.ToString();
                }
            }

            else
            {
                messageInString = "brak odpowiedzi";
            }

            return messageInString;
        }


        // Wyszukiwanie portu pod które podpięte jest urządzenie
        // Funkcja bez parametrów
        // Zwraca nazwę portu lub komunikat "Nie ma urządzenia"
        public string findPortName()
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
                    _serialPort.Open();
                    while (_continue)
                    {
                        try
                        {
                            if (HAI() == 0)
                            {
                                portName = s;
                            }
                        }
                        catch (TimeoutException) { }
                        iloscZapytan++;
                        if (iloscZapytan == 1)
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


        public string[] findAvailablePorts()
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
            int[] command = { 0x0A, 0x0B, 0x0C, 0x0D,0x0F,0x10,0x11,0xAA,0x1A };
            int blad = 0;

            for (int j = 0; j < sets.GetLength(0); j++)
            {
                sendByByte(0xFF, "$");       //format ramki ->ustawić zgodnie z elektronikami
                sendByByte(0x01, "$");

                if (commandNr == 10)
                {
                    sendByByte(command[j], "$");
                }
                else
                {
                    sendByByte(command[commandNr], "$");
                }

                for (int i = 0; i < sets.GetLength(1); i++)
                {
                    if (i == sets.GetLength(1) - 1)
                    {
                        sendByByte(sets[j, i], "0xA0");       
                    }
                    else
                    {
                        sendByByte(sets[j, i], "$");
                    }
                }
            }
            if (readByByte(1) == "brak odpowiedzi")
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
            int[] tab = { 0xFF, 0x01, 0x01 };

            sendByByte(tab, "0xA0");

            for (int i = 0; i < 8; i++)
            {
                faceSets[i] = readByByte(1);
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
            int[] tab = { 0xFF, 0x01, 0x01 };
            int blad = 1;
            sendByByte(tab,"0xA0");       //format ramki ->ustawić zgodnie z elektronikami
            if (readByByte(3) == "255$1$255$")
            {
                blad=0;
            }
            return blad;
        }

        public int sendByByte(int [] dane, string koniecRamki)
        {
            int blad = 0;
            int i;
            int dlugosc = dane.Length;

            byte[] data = new byte[dlugosc+1];

            for (i=0; i < dlugosc; i++)
            {
                data[i]=(byte)dane[i];
            }
            if (koniecRamki == "0xA0")
            {
                data[i] = 0xA0;
                _serialPort.Write(data, 0, data.Length);
            }
            else if (koniecRamki == "$")
            {
                _serialPort.Write(data, 0, data.Length-1);
            }

            return blad;
        }

        public int sendByByte(int dane, string koniecRamki)
        {
            int blad = 0;
            byte[] data = new byte[2];

            data[0] = (byte)dane;

            if (koniecRamki == "0xA0")
            {
                data[1] = 0xA0;
                _serialPort.Write(data, 0, data.Length);
            }
            else if (koniecRamki == "$")
            {
                _serialPort.Write(data, 0, data.Length - 1);
            }

            return blad;
        }
    }
}
