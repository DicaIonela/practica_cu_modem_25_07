using LibrarieClase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using NivelStocareDate;
using System.Runtime.InteropServices;
using InterfataUtilizator;
using System.Windows.Forms;
using System.Data.SqlTypes;
using System.IO.Ports;
namespace Proiect_practicaDI
{
    public static class Metode
    {
        /*INITIALIZARI PENTRU A PUTEA ASCUNDE CONSOLA LA RULARE*/
        [DllImport("kernel32.dll")]/*Se importa functii pentru a ascunde/afisa consola*/
        static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        static SerialPort serialPort;
        static StringBuilder dataBuffer = new StringBuilder();
        static string callerNumber;
        private static bool isCallActive = false; // Variabilă pentru a urmări dacă un apel este activ
        [STAThread]
        public static void Start()
        {
            IntPtr handle = GetConsoleWindow();/*Obtine handle-ul ferestrei consolei*/
            ShowWindow(handle, SW_HIDE);/*Ascunde consola*/
            /*Setam aplicatia pentru a folosi Windows Forms*/
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            /*Afisam fereastra de alegere*/
            DialogResult result = MessageBox.Show(
                "Doriti sa intrati in interfata grafica a aplicatiei?\n\n" +
                "*Selectand butonul No alegeti optiunea de a folosi aplicatia in consola.\n",
                "Selectați modul de utilizare",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Run(new InterfataGrafica());/*Deschide interfata grafica*/
            }
            else
            {
                ShowWindow(handle, SW_SHOW);/*reafiseaza consola*/
                Metode.StartCommandPromptMode(); /*Continua cu modul Command Prompt*/
            }
        }
        public static void Meniu()
        {
            Console.WriteLine("----MENIU----");
            Console.WriteLine("C. Citire utilizator.");
            Console.WriteLine("S. Salvare utilizator.");
            Console.WriteLine("A. Afisare utilizatori din fisier.");
            Console.WriteLine("L. Cautare utilizator dupa nume.");
            Console.WriteLine("M. Afiseaza adresa MAC a acestui PC.");
            Console.WriteLine("E. Sterge un utilizator din fisier.");
        }
        public static void StartCommandPromptMode()
        {
            Init.Initialize(out Administrare_FisierText admin, out Utilizator utilizatornou); /*initializari*/
            ListenToSerialPort("COM4", 115200);
            Meniu();/*text meniu*/
            do
            {
                //ListenToSerialPort("COM4", 115200);
                Console.WriteLine("\nIntrodu optiunea dorita:");
                string optiune = Console.ReadLine();
                switch (optiune)
                {
                    case "C":
                        utilizatornou = CitireUtilizatorTastatura();
                        break;
                    case "S":
                        /* Verificare daca a fost introdus un utilizator nou */
                        if (utilizatornou.Nume != string.Empty)
                        {
                            admin.AddUtilizator(utilizatornou);/*daca a fost introdus un utilizator nou, se adauga in fisier*/
                            Console.WriteLine("Utilizatorul a fost adaugat cu succes.");
                        }
                        else
                        {
                            Console.WriteLine("Salvare nereusita. Nu ati introdus niciun utilizator nou.");
                        }
                        break;
                    case "A":
                        Utilizator[] utilizatori = admin.GetUtilizatori(out int nrUtilizatori);/*SE CREEAZA UN TABLOU DE OBIECTE*/
                        AfisareUtilizatori(utilizatori, nrUtilizatori);
                        break;
                    case "L":
                        Console.WriteLine("Introduceti criteriul de cautare:");
                        string criteriu = Console.ReadLine();
                        Utilizator[] utilizatoriGasiti = admin.CautaUtilizator(criteriu);
                        if (utilizatoriGasiti.Length > 0)
                        {
                            AfisareUtilizatori(utilizatoriGasiti, utilizatoriGasiti.Length);
                        }
                        else
                        {
                            Console.WriteLine("Nu s-au găsit utilizatori care să corespundă criteriului.");
                        }
                        break;
                    case "M":
                        string adresam = GetMacAddress();
                        Console.WriteLine("Adresa MAC a calculatorului este: " + adresam);
                        break;
                    case "E":
                        Console.WriteLine("Introdu numele utilizatorului de sters:");
                        string numedesters = Console.ReadLine();
                        admin.StergeUtilizator(numedesters);
                        break;
                }
            } while (true);
        }
        public static void AfisareUtilizatori(Utilizator[] utilizatori, int nrUtilizatori)
        {
            Console.WriteLine("Utilizatorii salvati in fisier sunt:");
            for (int contor = 0; contor < nrUtilizatori; contor++)/*SE PARCURGE TABLOUL DE OBIECTE SI SE AFISEAZA INFORMATIILE IN FORMATUL CORESPUNZATOR*/
            {
                string infoLocuri = utilizatori[contor].Info();
                Console.WriteLine(infoLocuri);
            }
        }
        public static string ValidareSiCorectareNumar(string numar)
        {
            if (numar.StartsWith("+40"))
            {
                if (numar.Length == 13 && numar.Substring(3).All(char.IsDigit))/*Verificare daca numarul are exact 13 caractere si sunt doar cifre dupa +40*/
                {
                    return numar;
                }
                else
                {
                    return null; /*Invalid*/
                }
            }
            else
            {
                if (numar.Length == 10 && numar.All(char.IsDigit) && numar.StartsWith("0"))/*Verificare daca numarul are exact 10 caractere si sunt doar cifre*/
                {
                    return "+4" + numar; /*Adaugam prefixul +4 -> 0 fiind deja inclus*/
                }
                else
                {
                    return null; /*Invalid*/
                }
            }
        }
        public static string ValidareSiFormatareAdresaMac(string adresamac)
        {
            var cleanAddress = new string(adresamac
                .Where(c => "0123456789ABCDEF".Contains(char.ToUpper(c)))
                .ToArray());/*Elimina toate caracterele non-hexadecimale si normalizeaza*/
            if (cleanAddress.Length == 12)/*Verificare daca are exact 12 caractere (6 octeti)*/
            {
                return string.Join("::", Enumerable.Range(0, cleanAddress.Length / 2)
                    .Select(i => cleanAddress.Substring(i * 2, 2)));/*Formateaza in formatul 00::11::22::33::44::55*/
            }
            else
            {
                return null; /*Invalid*/
            }
        }
        public static Utilizator CitireUtilizatorTastatura()
        {
            Console.WriteLine("Introduceti datele utilizatorului:");
            Console.WriteLine("Nume:");
            string nume = Console.ReadLine();
            string numarcitit;
            do
            {
                Console.WriteLine("Numar:");
                numarcitit = Console.ReadLine();
                numarcitit = ValidareSiCorectareNumar(numarcitit);
                if (numarcitit == null)
                {
                    Console.WriteLine("Numărul de telefon introdus nu este valid. Te rugăm să încerci din nou.");
                }
            } while (numarcitit == null);
            string adresamac;
            do
            {
                Console.WriteLine("Adresa MAC (format: 00::11::22::33::44::55):");
                adresamac = Console.ReadLine();
                adresamac = ValidareSiFormatareAdresaMac(adresamac);
                if (adresamac == null)
                {
                    Console.WriteLine("Adresa MAC introdusă nu este validă. Te rugăm să încerci din nou.");
                }
            } while (adresamac == null);
            Utilizator utilizator = new Utilizator(nume, numarcitit, adresamac);
            return utilizator;
        }
        public static string GetMacAddress()
        {
            var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();/*Obtine lista de placi de retea*/
            foreach (var networkInterface in networkInterfaces)/*Cautam prima placa de retea activa si obtinem adresa MAC*/
            {
                if (networkInterface.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                    networkInterface.OperationalStatus == OperationalStatus.Up)/*Verifica daca placa de retea nu este de tip Loopback si este activs*/
                {
                    var macAddress = networkInterface.GetPhysicalAddress();
                    if (macAddress != null)
                    {
                        return string.Join("::", macAddress.GetAddressBytes().Select(b => b.ToString("X2")));/*Formateaza adresa MAC intr-un sir de caractere hexazecimale*/
                    }
                }
            }
            return "Adresa MAC nu a putut fi gasita";
        }
        static void ListenToSerialPort(string portName, int baudRate)
        {
            serialPort = new SerialPort(portName);
            /*Setările portului serial cu valori implicite pentru parametrii care nu sunt specificați*/
            serialPort.BaudRate = baudRate;
            serialPort.Parity = Parity.None; // Fără paritate
            serialPort.DataBits = 8; // 8 biți de date
            serialPort.StopBits = StopBits.One; // Un bit de stop
            serialPort.Handshake = Handshake.None; // Fără control al fluxului
            /*Evenimentul care se declanșează când se primesc date*/
            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            try
            {
                // Deschide portul serial
                serialPort.Open();
                Console.WriteLine("Portul serial este deschis. Ascultând date...");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Eroare la deschiderea portului serial: " + ex.Message);
            }
        }
        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            dataBuffer.Append(indata);
            // Verifică dacă bufferul conține date complete
            ProcessBuffer();
        }
        private static string ExtractCallerNumber(string message)
        {
            // Extrage numărul apelantului din mesajul +CLIP
            int startIndex = message.IndexOf('"') + 1;
            int endIndex = message.IndexOf('"', startIndex);
            if (startIndex > 0 && endIndex > startIndex)
            {
                return message.Substring(startIndex, endIndex - startIndex);
            }
            return string.Empty;
        }
        private static void ProcessBuffer()
        {
            string delimiter = "\nRING";/*delimitator pentru a verifica daca buffer ul a stocat toate datele complete*/
            while (dataBuffer.ToString().Contains(delimiter))
            {
                // Extrage mesajul complet din buffer
                int delimiterIndex = dataBuffer.ToString().IndexOf(delimiter);
                string completeMessage = dataBuffer.ToString().Substring(0, delimiterIndex);

                // Elimină mesajul complet din buffer
                dataBuffer.Remove(0, delimiterIndex + delimiter.Length);
                string cleanedMessage = completeMessage.Trim();
                if (cleanedMessage.Contains("+CLIP:"))
                {
                    string callerNumber = ExtractPhoneNumber(cleanedMessage);
                    Console.WriteLine("Date primite: " + cleanedMessage+"\nNumar:"+callerNumber);
                    SendCommand("ATH");
                    WaitForOkResponse();
                    SendCommand("AT");
                }
            }
            //return callerNumber;
        }
        private static void SendCommand(string command)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                try
                {
                    // Adaugă o nouă linie după comanda AT
                    serialPort.WriteLine(command + "\r");
                    Console.WriteLine("Comandă trimisă: " + command);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Eroare la trimiterea comenzii: " + ex.Message);
                }
            }
        }
        private static void WaitForOkResponse()
        {
            string okResponse = "OK\r"; // Răspunsul așteptat
            string receivedData = string.Empty;
            // Continuă să verifice până când găsește confirmarea OK
            while (true)
            {
                // Verifică dacă există date disponibile în buffer
                if (serialPort.BytesToRead > 0)
                {
                    // Citește datele din portul serial
                    receivedData += serialPort.ReadExisting();

                    // Verifică dacă datele conțin confirmarea OK
                    if (receivedData.Contains(okResponse))
                    {
                        // Elimină confirmarea OK din bufferul de date
                        int okIndex = receivedData.IndexOf(okResponse);
                        receivedData = receivedData.Substring(okIndex + okResponse.Length);
                        Console.WriteLine("Confirmare primită: OK");
                        return; // Iese din buclă după ce a primit confirmarea
                    }
                }
                // Așteaptă puțin înainte de a verifica din nou
                System.Threading.Thread.Sleep(100); // 100 ms pentru a preveni consumul excesiv de CPU
            }
        }
        private static string ExtractPhoneNumber(string message)
        {
            // Caută începutul și sfârșitul numărului de telefon între ghilimele
            int startIndex = message.IndexOf('"') + 1;
            int endIndex = message.IndexOf('"', startIndex);

            // Verifică dacă indecșii sunt valizi
            if (startIndex > 0 && endIndex > startIndex)
            {
                return message.Substring(startIndex, endIndex - startIndex);
            }
            return string.Empty; // Returnează un șir gol dacă numărul nu a fost găsit
        }
    }
}