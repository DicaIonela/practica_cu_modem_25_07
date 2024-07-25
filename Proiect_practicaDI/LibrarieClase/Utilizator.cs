using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LibrarieClase
{
    public class Utilizator
    {
        private const char SEPARATOR_FISIER = ';';
        public string Nume { get; set; }
        public string Numar { get; set; }
        public string AdresaMAC { get; set; }
        private const int NUME = 0;
        private const int NUMAR = 1;
        private const int ADRESAMAC = 2;
        public Utilizator()/*CONSTRUCTOR FARA PARAMETRI*/
        {
            Nume=Numar=AdresaMAC=string.Empty;
        }
        public Utilizator (string Nume, string Numar, string AdresaMAC)/*CONSTRUCTOR CU PARAMETRI*/
        {
            this.Nume = Nume;
            this.Numar = Numar;
            this.AdresaMAC = AdresaMAC;
        }
        public Utilizator (string linieFisier) /*CONSTRUCTOR PENTRU LINIILE FISIERULUI*/
        {
            string[] dateFisier= linieFisier.Split(SEPARATOR_FISIER);
            this.Nume=dateFisier[NUME];
            this.Numar=dateFisier[NUMAR];
            this.AdresaMAC=dateFisier[ADRESAMAC];
        }
        public string Conversie_PentruFisier()/*CONVERTESTE INFORMATIILE UTILIZATORULUI DIN OBIECT IN STRING IN FORMATUL CORESPUNZATOR PENTRU FISIERUL CSV; PENTRU SALVARE IN FISIER*/
        {
            string UtilizatorInFisier = string.Format("{1}{0}{2}{0}{3}",
                SEPARATOR_FISIER,
                (Nume ?? " NECUNOSCUT "),
                (Numar ?? " NECUNOSCUT "),
                (AdresaMAC ?? "NECUNOSCUT"));
            return UtilizatorInFisier;
        }
        public string Info()/*FORMAREA UNUI SIR DE CARACTERE CORESPUNZATOR PENTRU AFISAREA IN CONSOLA A INFORMATIILOR UTILIZATORULUI*/
        {
            string info = $"\nUtilizator:\nNume:{Nume ?? " NECUNOSCUT "} \nNumar:{Numar ?? " NECUNOSCUT "} \nAdresa MAC: {AdresaMAC ?? " NECUNOSCUT "}";
            return info;
        }
    }
}