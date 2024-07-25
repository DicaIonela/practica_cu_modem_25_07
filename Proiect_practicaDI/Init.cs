using System;
using NivelStocareDate;
using LibrarieClase;

namespace Proiect_practicaDI
{
    public static class Init
    {
        public static void Initialize(out Administrare_FisierText admin, out Utilizator utilizatornou)
        {
            // Inițializarea calea către fișier
            string numeFisier = System.Configuration.ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = System.IO.Path.Combine(locatieFisierSolutie, "Proiect_practicaDI", numeFisier);

            // Inițializare obiecte
            admin = new Administrare_FisierText(caleCompletaFisier);
            utilizatornou = new Utilizator();
        }
    }
}
