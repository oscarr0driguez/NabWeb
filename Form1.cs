using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;

namespace NabWeb
{
    public partial class Form1 : Form
    {
        List<Url> ListUrl = new List<Url>();
        string fileName = @"C:\Users\Oscar_Rodriguez\Desktop\progra 3 2024\NabWeb\bin\Debug \Historial.txt";


        public Form1()
        {
            InitializeComponent();
            this.Resize += new System.EventHandler(this.Form_Resize);
        }
        private void Form_Resize(object sender, EventArgs e)
        {
            webView21.Size = this.ClientSize - new System.Drawing.Size(webView21.Location);
            BtnIr.Left = this.ClientSize.Width - BtnIr.Width;
            comboBox1 .Width = BtnIr.Left - comboBox1.Left;
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
          //webView21.Navigate(new Uri(urlIngresada));
            webView21.CoreWebView2.Navigate(urlIngresada);
            Guardar(@"C:\Users\Oscar_Rodriguez\Desktop\progra 3 2024\NabWeb\bin\Debug\Historial.txt", comboBox1.Text);
        }

        private void Leer()
        {
            string fileName = @"C:\Users\Oscar_Rodriguez\Desktop\progra 3 2024\NabWeb\bin\Debug\Historial.txt";
            FileStream flujo = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader lector = new StreamReader(flujo);
            ListUrl.Clear();

            while (lector.Peek() > -1)
            {
                Url url = new Url();
                url.Pagina = lector.ReadLine();
                string veces = Convert.ToString(lector.ReadLine());
                url.Veces = Convert.ToInt32(veces);
                url.Fecha = Convert.ToDateTime(lector.ReadLine());
                //string textoLeido = lector.ReadLine();
                //comboBox1.Items.Add(textoLeido);
                ListUrl.Add(url);
            }
            lector.Close();

            comboBox1.DisplayMember = "Pagina";
            comboBox1.DataSource = ListUrl;
            comboBox1.Refresh();
        }


        private void Guardar(string fileName, string texto)
        {
            FileStream flujo = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter lector = new StreamWriter(flujo);
            foreach (Url url in ListUrl)
            {
                lector.WriteLine(url.Pagina);
                lector.WriteLine(url.Veces);
                lector.WriteLine(url.Fecha);
            }
            lector.Close();


            /*
            FileStream stream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine(texto);
            writer.Close();*/
        }
        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webView21.CoreWebView2.Navigate("https://www.google.com/");


        }

        private void haciaAtrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webView21.GoBack();
        }

        private void haciaDelanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webView21.GoForward();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            Leer();
           // webBrowser1.GoHome();
        }
    }
}
