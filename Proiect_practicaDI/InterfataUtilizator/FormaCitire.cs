using LibrarieClase;
using NivelStocareDate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace InterfataUtilizator
{
    public partial class FormaCitire : Form
    {
        public Administrare_FisierText admin;
        private FormaCitire formaCitire;
        public string Nume
        {
            get { return txtNume.Text; }
            set { txtNume.Text = value; }
        }

        public string Nr
        {
            get { return txtNr.Text; }
            set { txtNr.Text = value; }
        }

        public string Adresa
        {
            get { return txtAdresa.Text; }
            set { txtAdresa.Text = value; }
        }
        public FormaCitire()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            string numeFisier = System.Configuration.ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = System.IO.Path.Combine(locatieFisierSolutie, "Proiect_practicaDI", numeFisier);
            Administrare_FisierText admin = new Administrare_FisierText(caleCompletaFisier);
            InitializeComponent();
        }

        private void txtNume_TextChanged(object sender, EventArgs e)
        {
            if (txtNume.Text.Length > 25)
            {
                txtNume.ForeColor = Color.Red;
            }
            else
            {
                txtNume.ForeColor = SystemColors.ControlText;
            }
        }

        private void txtNr_TextChanged(object sender, EventArgs e)
        {
            if (txtNr.Text.Length > 12)
            {
                txtNr.ForeColor = Color.Red;
            }
            else
            {
                txtNr.ForeColor = SystemColors.ControlText;
            }
        }

        private void txtAdresa_TextChanged(object sender, EventArgs e)
        {
            if (txtAdresa.Text.Length > 22)
            {
                txtAdresa.ForeColor = Color.Red;
            }
            else
            {
                txtAdresa.ForeColor = SystemColors.ControlText;
            }
        }
        private void btnSalveaza_Click(object sender, EventArgs e)
        {
            string numeFisier = System.Configuration.ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = System.IO.Path.Combine(locatieFisierSolutie, "Proiect_practicaDI", numeFisier);
            Administrare_FisierText admin = new Administrare_FisierText(caleCompletaFisier);
            Utilizator[] utilizatoriexistenti = admin.GetUtilizatori(out int nrUtilizatori);
            if (Validare() == 5)
            {
                Utilizator utilizatornou = new Utilizator
                {
                    Nume = txtNume.Text,
                    Numar = txtNr.Text,
                    AdresaMAC = txtAdresa.Text
                };
                admin.AddUtilizator(utilizatornou);
                MessageBox.Show("Salvat cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNume.Text = "";
                txtNr.Text = "";
                txtAdresa.Text = "";
                this.Close();
            }
            else
            {
                if (Validare() == 0)
                {
                    MessageBox.Show("Completati intreg formularul inainte de a salva.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (Validare() == 1)
                {
                    MessageBox.Show("Ati depasit numarul de caractere permise. Incercati din nou.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (Validare() == 2)
                {
                    MessageBox.Show("Numarul este invalid. Incercati din nou.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (Validare() == 3)
                {
                    MessageBox.Show("Adresa MAC incorecta. Incercati din nou.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        public int Validare()
        {
            var cleanAddress = new string(txtAdresa.Text
                .Where(c => "0123456789ABCDEF".Contains(char.ToUpper(c)))
                .ToArray());
            /*Verificare daca are exact 12 caractere (6 octeti)*/
            if (cleanAddress.Length == 12)
            {
                /*Formateaza in formatul 00::11::22::33::44::55*/
                txtAdresa.Text = string.Join("::", Enumerable.Range(0, cleanAddress.Length / 2)
                    .Select(i => cleanAddress.Substring(i * 2, 2)));
            }
            else
            {
                return 3; /*Invalid*/
            }
            if (txtNume.Text == string.Empty || txtNr.Text == string.Empty|| txtAdresa.Text == string.Empty)
            {
                return 0;
            }
            if (txtNume.Text.Length > 25 || txtNr.Text.Length > 12||txtAdresa.Text.Length > 22)
            {
                return 1;
            }
            if (txtNr.Text.StartsWith("+40"))
            {
                /*Verificare daca numarul are exact 13 caractere si sunt doar cifre dupa +40*/
                if (txtNr.Text.Length != 12 || !txtNr.Text.Substring(3).All(char.IsDigit))
                {
                    return 2;
                }
                else
                {
                    return 5; /*Valid*/
                }
            }
            if (txtNr.Text.Length == 10 && txtNr.Text.All(char.IsDigit) && txtNr.Text.StartsWith("0"))
            {
                txtNr.Text = "+4" + txtNr.Text;
                return 5; /*Adaugam prefixul +4 -> 0 fiind deja inclus*/
            }
            else
            {
                return 2; /*Invalid*/
            }
        }
    }
}
