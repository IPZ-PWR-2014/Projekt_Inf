using System;
using System.IO.Ports;
using System.Threading;

namespace Komunikacja
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

            name = SetPortName();
            if (name != "Nie ma urządzenia")    //sprawdzanie czy odnaleziono odpowiedni port 
            {
                _serialPort.PortName = name;

                _serialPort.ReadTimeout = 500;  //czasy oczekiwania
                _serialPort.WriteTimeout = 500;
                _serialPort.NewLine = "B";      //sprawdzić czy ustawiono odpowiedni znak konca lini ->ustawić zgodnie z elektronikami
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
        public string Read()
        {
            int iloscZapytan = 0;
            string message="brak odpowiedzi";
            _continue = true;
            while (_continue)
            {
                try
                {
                    message = _serialPort.ReadLine();
                }
                catch (TimeoutException) { }
                iloscZapytan++;
                if (iloscZapytan == 3)
                {
                    iloscZapytan = 0;
                    _continue = false;
                }
            }
            return message;
        }

        // Wyszukiwanie portu pod które podpięte jest urządzenie
        // Funkcja bez parametrów
        // Zwraca nazwę portu lub komunikat "Nie ma urządzenia"
        public static string SetPortName()
        {
            string portName = "Nie ma urządzenia";
            int iloscZapytan = 0;

            foreach (string s in SerialPort.GetPortNames())
            {
                _continue = true;
                _serialPort.PortName = s;
                _serialPort.ReadTimeout = 500;
                _serialPort.WriteTimeout = 500;
                _serialPort.NewLine = "B";          //Pamiętać ustawić odpowiedni znak konca lini ->ustawić zgodnie z elektronikami

                if (s != "COM8") //do wyrzucenia, uzywane przy termianalu
                {
                    _serialPort.Open();
                    Console.WriteLine(s);
                    _serialPort.WriteLine("$FF$01$AF$00$0A");       //Kim jestem ->ustawić zgodnie z elektronikami
                    while (_continue)
                    {
                        try
                        {
                            if (_serialPort.ReadLine() == "0x1F")
                            {
                                portName = s;
                            }
                        }
                        catch (TimeoutException) { }
                        iloscZapytan++;
                        if (iloscZapytan == 5)
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

        // Wysyłanie danych
        // "set"        - Wektor danych typu int
        // "commandNr"  - Numer Komendy
        // Zwraca zero
        public int Send(int[] set, int commandNr)
        {
            _serialPort.NewLine = "$";              //zmiana znaku konca lini na czas wysyłania w celu zachowania formatu ramki
            _serialPort.WriteLine("$FF$01$AF$00$0A");       //format ramki ->ustawić zgodnie z elektronikami
            _serialPort.WriteLine(Convert.ToString(commandNr));
            for (int i = 0; i < set.Length; i++)
            {
                _serialPort.WriteLine(Convert.ToString(set[i]));
            }
            _serialPort.NewLine = "/x$";            //powrót do starego znaku konca lini ->ustawić zgodnie z elektronikami
            return 0;
        }
    }
}






