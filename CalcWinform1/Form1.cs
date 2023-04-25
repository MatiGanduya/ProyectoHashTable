using Calc.Core.Interfaces;
using System.Collections;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CalcWinform1
{
    public partial class Form1 : Form
    {
        private ICalc _calc;

        private Hashtable _lista = new Hashtable();
        private ArrayList numeros = new ArrayList();

        public Form1(ICalc calc)
        {
            _calc = calc;

            _calc.Procesando += Calc_Procesando_Demo;
            _calc.Termino += Calc_Termino_Demo;

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var resultado = _calc.Add(1, 1);

            label1.Text = resultado.ToString();
        }

        private void Calc_Procesando_Demo(object sender, EventArgs e)
        {
            lblEstado.Text = "Procesando....";
        }

        private void Calc_Termino_Demo(object sender, EventArgs e)
        {
            lblEstado.Text = "Termino!";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            lblEstado.Text = $"Resize! {DateTime.Now.ToLongTimeString()}";
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            lblEstado.Text = $"MouseMove! {DateTime.Now.ToLongTimeString()}";
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int a = 0;
            int x=0, y=0;
            string[] operaciones = {"+", "-", "*", "/", "="};
            if (_lista.Count == 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    var b = new Button();
                    b.Text = i.ToString();
                    b.Width = 50;
                    b.Height = 50;

                    b.Location = new Point(x, y);

                    panelCalc.Controls.Add(b);
                    _lista.Add(i, b);
                    x = x+50;
                    if (x > 149)
                    {
                        x = 0;
                        y = y+50;
                    }
                    a = a + 1;
                }
                x = 150;
                y = 0;
                foreach (string operacion in operaciones)
                {
                    Button btnOperacion = new Button();
                    btnOperacion.Text = operacion;
                    btnOperacion.Width = 50;
                    btnOperacion.Height = 50;
                    btnOperacion.Location = new Point(x, y);

                    panelCalc.Controls.Add(btnOperacion);

                    y += 50;
                    
                    
                    _lista.Add(a, btnOperacion);
                    a = a + 1;
                   
                }
               
                for (int i = _lista.Count; i > 0; i--)
                {
                    numeros.Add(i);
                }
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        { 

            if (numeros.Count > 0)
            {
                // Obtenemos el último número de la lista
                int numero = (int)numeros[numeros.Count - 1];
                _lista.Remove(numero);
                // Lo eliminamos de la lista

                numeros.RemoveAt(numeros.Count - 1);
                panelCalc.Controls.RemoveAt(0);
                _lista.Clear();

            }
           
        }
    }
}