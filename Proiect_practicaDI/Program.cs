using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NivelStocareDate;
using System.Configuration;
using LibrarieClase;
using System.Windows.Forms;
using InterfataUtilizator;
using System.Runtime.InteropServices;
namespace Proiect_practicaDI
{
    internal class Program
        {
        //[DllImport("kernel32.dll")]/*Se importa functii pentru a ascunde/afisa consola*/
        //static extern IntPtr GetConsoleWindow();
        //[DllImport("user32.dll")]
        //static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        //const int SW_HIDE = 0;
        //const int SW_SHOW = 5;
        //[STAThread]
            static void Main(string[] args)
            {
            Metode.Start();
            //IntPtr handle = GetConsoleWindow();/*Obtine handle-ul ferestrei consolei*/
            //ShowWindow(handle, SW_HIDE);/*Ascunde consola*/
            ///*Setam aplicatia pentru a folosi Windows Forms*/
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            ///*Afisam fereastra de alegere*/
            //DialogResult result = MessageBox.Show(
            //    "Doriti sa intrati in interfata grafica a aplicatiei?\n\n" +
            //    "*Selectand butonul No alegeti optiunea de a folosi aplicatia in consola.\n",
            //    "Selectați modul de utilizare",
            //    MessageBoxButtons.YesNo,
            //    MessageBoxIcon.Question);
            //if (result == DialogResult.Yes)
            //{
            //    Application.Run(new InterfataGrafica());/*Deschide interfata grafica*/
            //}
            //else
            //{
            //    ShowWindow(handle, SW_SHOW);/*reafiseaza consola*/
            //    Metode.StartCommandPromptMode(); /*Continua cu modul Command Prompt*/
            //}
        }
    }
}
