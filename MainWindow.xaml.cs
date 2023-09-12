using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculadora
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnLimpiar(object sender, RoutedEventArgs e)
        {
            numeroOperador1 = 0;
            numeroOperador2 = 0;
            numeroTexto1 = "";
            numeroTexto2 = "";
            resultado = "";
            operador = "";
            pantalla.Text = "";
    }
        private void BtnNumeros(object sender, RoutedEventArgs e)
        {
            //me debe imprimir los numeros 
            Button btn = sender as Button;
            if(operador== "" && numeroTexto2 == "")
            {
                numeroTexto1 = numeroTexto1 + (string)btn.Content;// esto para poder poner un 88899
                numeroOperador1 = double.Parse(numeroTexto1);
                imprimirPantalla(numeroTexto1);
            }
            else
            {
                numeroTexto2= numeroTexto2 + (string)btn.Content;
                numeroOperador2= double.Parse(numeroTexto2);
                imprimirPantalla(numeroTexto1, numeroTexto2);
            }
           
            
        }
        public void BtnSigno(object sender, RoutedEventArgs e)
        {
            if (operador == "")
            {
                numeroOperador1 = numeroOperador1 * (-1);
                numeroTexto1 = Convert.ToString(numeroOperador1);
                imprimirPantalla(numeroTexto1);
            }
            else
            {
                numeroOperador2 = numeroOperador2 * (-1);
                numeroTexto2 = Convert.ToString(numeroOperador2);
                imprimirPantalla(numeroTexto1, numeroTexto2);
            }
                
        }
        private void BtnPunto(object sender, RoutedEventArgs e)
        {
            if (operador=="" && numeroTexto1 != "" && numeroOperador1%1==0)
            {
                numeroTexto1 = numeroTexto1 + ",";
                imprimirPantalla(numeroTexto1);

            }
            if(operador != "" && numeroTexto2 != "" && numeroOperador2%1==0) {
                numeroTexto2 = numeroTexto2 + ",";
                imprimirPantalla(numeroTexto1, numeroTexto2);
            }

              




        }
        public void BtnOperadores(object sender, RoutedEventArgs e)
        {
            Button button= sender as Button;
            if( operador=="" && numeroTexto2 == ""){
                operador = (string)button.Content;
                imprimirPantalla(numeroTexto1 );   
            }
            
            
        }

        public void BtnIgual(object sender, RoutedEventArgs e) 
        {
            if (operador != "")
            {
                switch(operador)
                {
                    case "+":
                        resultado=Convert.ToString(numeroOperador1 + numeroOperador2);
                    break;
                    case "-":
                        resultado = Convert.ToString(numeroOperador1 - numeroOperador2);
                    break;
                    case "x":
                        resultado = Convert.ToString(numeroOperador1 * numeroOperador2);
                    break;
                    case "÷":
                        resultado = Convert.ToString(numeroOperador1 / numeroOperador2);
                    break;

                }
            }
            numeroTexto1 = resultado;
            numeroOperador1 = double.Parse(numeroTexto1);
            numeroTexto2 = "";
            operador = "";
            resultado = "";
            imprimirPantalla(numeroTexto1, numeroTexto2);
        }
     
        public void imprimirPantalla(Object numero, Object numero2= null)
        {
            if (resultado == "")
            {
                if (operador == "")
                {
                    pantalla.Text= Convert.ToString(numero);
                }
                else
                {
                    pantalla.Text= "("+ Convert.ToString(numero)+") "+ operador + "( "+Convert.ToString(numero2)+")";//aca usamos convert 
                    //porque estamos usando object
                }
            }
            else
            {
                pantalla.Text = "Resultado= " + resultado;
            }
        }
       
        private double numeroOperador1=0;
        private double numeroOperador2 =0;
        private string numeroTexto1 = "";
        private string numeroTexto2 = "";
        private string resultado = "";
        private string operador = "";//la suma, resta etc
       




    }
}
