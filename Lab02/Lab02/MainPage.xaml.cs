using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Lab02
{
    public partial class MainPage : ContentPage
    {
        List<Button> selectedOnes = new List<Button>();
        List<Button> options = new List<Button>();
        List<String> vals = new List<String>();
        String encontrados = "";
        int intentos = 0;

        public MainPage()
        {
            InitializeComponent();
            generateGame();
        }

        void generateGame() {
            for (int i =1 ; i < 6 ; i++) { 
                for (int j =0 ; j < 5; j++) {
                    String name = "btn" + i + j;
                    Button btn = this.FindByName<Button>(name);
                    options.Add(btn);
                }
            }

            //reiniciar el color y habilitar los botones
            foreach (Button bn in options)
            {
                bn.BackgroundColor = Color.FromHex("#000000");
                bn.IsEnabled = true;
            }

            //revolver la lista de botones
            var shuffled = options.OrderBy(x => Guid.NewGuid()).ToList();
            
            

            for (int i = 1; i < 13; i++)
            {
                vals.Add((char)(64 + i) + "");
            }

            for (int i = 1; i < 13; i++)
            {
                vals.Add((char)(64 + i) + "");
            }

            //eliminando el cuadro que sobra
            shuffled.RemoveAt(0);

            //llena los cuadros con las letras de forma random
            for (int i = 0; i < shuffled.Count; i++)
            {
                shuffled[i].Text = vals[i];
            }


        }

        void rstrt(object sender, System.EventArgs e) {
            selectedOnes.Clear();
            options.Clear();
            //restart counters
            encontrados = "";
            intentos = 0;
            Label foo = this.FindByName<Label>("Intentos");
            Label goo = this.FindByName<Label>("Encontrados");
            foo.Text = "Intentos Fallidos: ";
            goo.Text = "Encontrados: ";

            generateGame();

        }

        void show(object sender, System.EventArgs e) {
            Button btn = (Button)sender;
            btn.IsEnabled = false; 
          
            //mustra el signo
            btn.BackgroundColor = Color.FromHex("#ffffff");
            
            // insertar en array temporalmente los selecionados
            selectedOnes.Add(btn);
                
            //en caso de que ambos seleccionados son del mismo signo
            if (selectedOnes.Count > 1 && selectedOnes[0].Text == selectedOnes[1].Text) {
                encontrados = encontrados + " " + selectedOnes[0].Text;
                foreach (Button bn in selectedOnes)
                {
                    bn.BackgroundColor = Color.FromHex("#1ABC9C");
                    bn.IsEnabled = false;
                }
                selectedOnes.Clear();
                Label foo = this.FindByName<Label>("Encontrados");
                foo.Text = "Encontrados: " + encontrados;


            }

            //para que al tercer click se escondan las opciones
            if (selectedOnes.Count > 2)
            {
                foreach (Button bn in selectedOnes)
                {
                    bn.BackgroundColor = Color.FromHex("#000000");
                    bn.IsEnabled = true;
                }
                selectedOnes.Clear();
                //aumentar el contador de intentos fallidos
                intentos = intentos + 1;
                Label qoo = this.FindByName<Label>("Intentos");
                qoo.Text = "Intentos Fallidos:  " + intentos;

            }

        }
    }
}
