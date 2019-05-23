using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Test.ViewModel
{
    public class OperacionesViewModel : INotifyPropertyChanged
    {

        public string MiNombre { get; set; }
        public string Valor1 { get; set; }
        public string Valor2 { get; set; }
        //public string Resultado { get; set; }
        private string _Resultado = "";

        public string Resultado
        {
            get
            {
                return _Resultado;
            }
            set
            {
                _Resultado = value;
                OnPropertyChanged("Resultado");
            }
        }

        public ICommand SumarCommand { get; set; }

        public OperacionesViewModel()
        {
            MiNombre = "Carlos Mendez";
            SumarCommand = new Command(MetodoSumar);
        }

        public void MetodoSumar() 
        {

            Resultado = (Int32.Parse(Valor1) +  Int32.Parse(Valor2)).ToString();


        }


        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
