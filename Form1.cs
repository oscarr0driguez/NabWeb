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
        string fileName = @"C:\Users\Oscar_Rodriguez\Desktop\progra 3 \Historial.txt";

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
        }
        private void Leer()
        {
            
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while(reader.Peek() > -1)
            {
                Url url = new Url();
                url.Url = reader.ReadLine();
                url.Veces = Convert.ToInt32(reader.ReadLine());
                url.Fecha = Convert.ToDateTime(reader.ReadLine());
                urls.Add(url);

            }
            reader.Close();

        }

        private void Guardar(string Nombre, string texto)
        {
            FileStream flujo = new FileStream(NombreArchivo, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter escritor = new StreamWriter(flujo);
            foreach(URL url in urls){
                escritor.WriteLine(url.Url);
                escritor.WriteLine(url.Url);
                escritor.WriteLine(url.Url);

            }
            escritor.Close();

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
           // webBrowser1.GoHome();
        }
    }
}
