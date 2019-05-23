using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Test.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            lblLabel.Text = "Hola Mundo!!!";
        }

        void evento_sumar(object sender, System.EventArgs e)
        {
            //Primer paso
            int resultado = Int32.Parse(txtCampo1.Text) + Int32.Parse(txtCampo2.Text);

            //Segundo paso

            lblResultado.Text = resultado.ToString();

            if (resultado == 100)
            {
                Application.Current.MainPage = new Felicitaciones();
            }


            //Tercer paso
            txtCampo1.Text = "";
            txtCampo2.Text = "";
        }
    }
}
