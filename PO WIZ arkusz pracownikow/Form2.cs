using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace PO_WIZ_arkusz_pracownikow
{
    public partial class Form2 : Form
    {
        private Form1 form1;
        public Form2(Form1 form)
        {
            InitializeComponent();
            form1 = form;
        }

      

        private void button2_Click(object sender, EventArgs e)
        {         
            this.Close();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {

            if (int.TryParse(textBox3.Text, out int wiek))
            {
                Global nowa_osoba = new Global
                {

                    Imie = textBox1.Text,
                    Nazwisko = textBox2.Text,
                    Wiek = wiek,
                    Etat = comboBox1.SelectedItem?.ToString()
                };

                StaticData.ListaOsob.Add(nowa_osoba);
                form1.OdswiezGridView();
            }
            
            this.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
