using System;
using System.IO.Ports;
using System.Threading;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RobotMimiczny
{
    class COM
    {
        public COM()
        {
            setDefaultParameters();
        }

        // klasy statyczne transmisji
        private static bool _continue;
        private static SerialPort _serialPort;

        // domyślne parametry transmisji
        private string _dataBits = "8";
        private string _parity = "none";
        private string _stopBits = "1";
        private string _handshake = "none";
        private string _baudRate = "9600";
        private string _defaultPortName = "brak portu";

        private string PortNameHAI = "brak portu";

        // właściwości
        public string dataBits { get { return _dataBits; } set { _dataBits = value.ToString(); } }
        public string parity { get { return _parity; } set { _parity = value.ToString(); } }
        public string stopBits { get { return _stopBits; } set { _stopBits = value.ToString(); } }
        public string handshake { get { return _handshake; } set { _handshake = value.ToString(); } }
        public string baudRate { get { return _baudRate; } set { _baudRate = value.ToString(); } }
        public string defaultPortName { get { return _defaultPortName; } set { _defaultPortName = value.ToString(); } }

        private int waitTime = 500;
        private int newLine = 0xA0;
        private int dolar = 0x24;
        private string defaultAnswer = "255$1$255$";


        // Metoda ustawia wartości domyślne parametrów transmisji
        public void setDefaultParameters()
        {
            dataBits = "8";
            parity = "none";
            stopBits = "1";
            handshake = "none";
            baudRate = "9600";
            defaultPortName = "brak portu";
        }

        // Metoda transmitująca jedną wartość
        private void sendByByte(int dane, int koniecRamki)
        {
            byte[] data = new byte[2];

            data[0] = (byte)dane;
            if (_serialPort.IsOpen == true)
            {
                if (koniecRamki == 0xA0)
                {
                    data[1] = 0xA0;
                    _serialPort.Write(data, 0, data.Length);
                }
                else if (koniecRamki == 0x24)
                {
                    _serialPort.Write(data, 0, data.Length - 1);
                }
            }
        }

        // Metoda transmituje wektor danych
        private void sendByByte(int[] dane, int koniecRamki)
        {
            int i;
            int dlugosc = dane.Length;

            byte[] data = new byte[dlugosc + 1];
            if (_serialPort.IsOpen == true)
            {
                for (i = 0; i < dlugosc; i++)
                {
                    data[i] = (byte)dane[i];
                }
                if (koniecRamki == 0xA0)
                {
                    data[i] = 0xA0;
                    _serialPort.Write(data, 0, data.Length);
                }
                else if (koniecRamki == 0x24)
                {
                    _serialPort.Write(data, 0, data.Length - 1);
                }
            }
        }

        // Odczyt odbieranej wiadomości bit po bitcie
        // int iloscZapytan - ilosc prob odczytu danych
        // Zwraca odczytaną linie lub error ("brak odpowiedzi")
        private string readByByte(int iloscZapytan)
        {
            int i = iloscZapytan;
            int j = 1;
            int[] message = new int[100];
            string messageInString = "";
            char temp = '$';

            message[0] = 0x00;
            _continue = true;

            while (message[j - 1] != newLine && (_continue))
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

        // Metoda Who Am I
        // Zwraca 0 jesli wszystko jest ok i 1 jesli nie ma odpowiedzi
        public int HAI()
        {
            int[] tab = { 0xFF, 0x01, 0xAF };
            int blad = 1;
            if (PortNameHAI != "brak portu")
            {
                if (_serialPort.IsOpen == true)
                {
                    sendByByte(tab, newLine);
                    if (readByByte(3) == defaultAnswer)
                    {
                        blad = 0;
                    }
                }
            }
            return blad;
        }

        // Metoda wyszukująca pod który port COM podpięte jest urządzenie
        // Zwraca nazwę portu lub komunikat "Nie ma urządzenia"
        private string findActivePortName()
        {
            string portName = "brak portu";
            int iloscZapytan = 0;

            foreach (string s in SerialPort.GetPortNames())
            {
                _continue = true;
                _serialPort.PortName = s;
                PortNameHAI = s;
                _serialPort.ReadTimeout = waitTime;
                _serialPort.WriteTimeout = waitTime;


                bool p = _serialPort.IsOpen;
                if (p == false)
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
                    if (portName != "brak portu") break;
                }
            }
            return portName;
        }

        // Metoda nawiązująca połączenie automatyczne
        // Funkcja bez parametrów
        // Zwraca nazwę portu lub komunikat "Nie ma urządzenia"
        public string initializeTransmission()
        {
            string name;
            _serialPort = new SerialPort();
            _serialPort.BaudRate = int.Parse(baudRate);
            _serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), parity, true);
            _serialPort.DataBits = int.Parse(dataBits.ToUpperInvariant());
            _serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), stopBits, true);
            _serialPort.Handshake = (Handshake)Enum.Parse(typeof(Handshake), handshake, true);

            name = findActivePortName();
            if (name != "brak portu")    //sprawdzanie czy odnaleziono odpowiedni port 
            {
                _serialPort.PortName = name;
                _serialPort.ReadTimeout = waitTime;  //czasy oczekiwania
                _serialPort.WriteTimeout = waitTime;
                _serialPort.Open();
            }

            defaultPortName = name;
            return name;
        }

        // Metoda nawiązująca połączenie z podanym portem COM
        // Funkcja bez parametrów
        // Zwraca nazwę portu lub komunikat "Nie ma urządzenia"
        public string initializeTransmission(string name)
        {
            _serialPort = new SerialPort();

            _serialPort.BaudRate = int.Parse(baudRate);
            _serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), parity, true);
            _serialPort.DataBits = int.Parse(dataBits.ToUpperInvariant());
            _serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), stopBits, true);
            _serialPort.Handshake = (Handshake)Enum.Parse(typeof(Handshake), handshake, true);

            _serialPort.PortName = name;
            _serialPort.ReadTimeout = waitTime;  //czasy oczekiwania
            _serialPort.WriteTimeout = waitTime;
            _serialPort.Open();

            defaultPortName = name;

            return name;
        }

        // Metoda kończy połączenie
        public void closeTransmision()
        {
            try
            {
                if (_serialPort.IsOpen == true)
                {
                    _serialPort.Close();
                    PortNameHAI = "brak portu";
                }
            }
            catch { }
        }

        // Metoda wysyłająca dane
        // int[,] sets      - tablica danych typu int (dla commandNr 1-8 i 10 - tablica [1][16]
        //                    dla commandNr 9 tablica [8][16]
        // int commandNr    - Numer Komendy
        //                  - 0-7 -> zapis min 1-8
        //                  - 9 -> zapis 8 min na raz
        //                  - 10 -> tryb RUN
        // Zwraca 0 lub 1 w wypadku błędu
        public int send(int[,] sets, int commandNr)
        {
            int[] command = { 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F, 0x10, 0x11, 0xAA };
            int[] temp = new int[sets.GetLength(1)];

            for (int j = 0; j < sets.GetLength(0); j++)
            {
                if (HAI() == 0)
                {
                    for (int i = 0; i < sets.GetLength(1); i++)
                    {
                        temp[i] = sets[j, i];
                    }

                    sendByByte(0xFF, dolar);       //format ramki ->ustawić zgodnie z elektronikami
                    sendByByte(0x01, dolar);

                    if (commandNr == 9)
                    {
                        sendByByte(command[j], dolar);
                    }
                    else if (commandNr == 10)
                    {
                        sendByByte(command[8], dolar);
                    }
                    else
                    {
                        sendByByte(command[commandNr], dolar);
                    }

                    sendByByte(temp, newLine);
                    Thread.Sleep(100);
                }
                else
                {
                    MessageBox.Show("Błąd komunikacji, sprawdź połączenie z zestawem", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 1;
                }

            }

            return 0;
        }

        // Metoda pobierająca ustawienia z uC
        // Zwraca tablice jednowymiarowa z nieobrobionymi stringami 
        //                          (format stringow: "
        //                           gdzie:  - komenda
        //                                  0$0A - numer miny
        //                                  reszta - nastawy serw
        public string[] readSettings()
        {
            string[] faceSets = new string[10];
            string[] blad = new string[10];
            int[] tab = { 0xFF, 0x01, 0x01 };

            if (HAI() == 0)
            {
                sendByByte(tab, newLine);

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
            else
            {
                MessageBox.Show("Błąd komunikacji, sprawdź połączenie z zestawem", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                blad[0] = "brak odpowiedzi";
                return blad;
            }

        }

        //Wyszukiwanie dostepnych portów COM
        //Zwraca tablicę z nazwami dostepnych portów
        public List<string> findAllAvailablePorts()
        {
            List<string> portNames = new List<string>();

            foreach (string s in SerialPort.GetPortNames())
            {
                portNames.Add(s);
            }
            return portNames;
        }
    }
}






