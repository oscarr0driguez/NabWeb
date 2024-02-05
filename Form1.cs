using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NabWeb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnIr_Click(object sender, EventArgs e)
        {
            /*String UrlIngresado = comboBox1.Text;
            bool comprobacion = UrlIngresado.Contains("https://");

            if (comprobacion == false)
            {
                String UrlCompleto = "https://" + UrlIngresado + "/";
                comboBox1.Text = UrlCompleto;
            }
            if()
            webBrowser1.Navigate(new Uri(comboBox1.SelectedItem.ToString()));*/
            // Obtener la URL ingresada
            String urlIngresada = comboBox1.Text.Trim();

            // Verificar si la URL ingresada contiene "https://"
            if (!urlIngresada.StartsWith("https://"))
            {
                // Si no comienza con "https://", verificar si es un término de búsqueda
                if (!urlIngresada.Contains("."))
                {
                    // Es un término de búsqueda, construir la URL de búsqueda de Google
                    urlIngresada = "https://www.google.com/search?q=" + Uri.EscapeDataString(urlIngresada);
                }
                else
                {
                    // Si contiene un punto, agregar automáticamente "https://"
                    urlIngresada = "https://" + urlIngresada;
                }

                // Actualizar el ComboBox con la URL completa
                comboBox1.Text = urlIngresada;
            }

            // Navegar a la URL utilizando el WebBrowser
            webBrowser1.Navigate(new Uri(urlIngresada));

        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }

        private void haciaAtrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }

        private void haciaDelanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            webBrowser1.GoHome();
        }
    }
}
