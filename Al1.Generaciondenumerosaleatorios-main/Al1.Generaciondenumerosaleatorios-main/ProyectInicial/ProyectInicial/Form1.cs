using ProyectInicial.Algoritmos.Metodos;
using ProyectInicial.Algoritmos.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectInicial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int datoInicial = Convert.ToInt32(textBox1.Text);




            AlgoritmoSimulacion1 algoritmo = new AlgoritmoSimulacion1();
            List<int> listaSalida = new List<int>();

            List<Demanda> listaDemandas = algoritmo.CalculoDemanda(datoInicial);

            llenarGrid(listaDemandas);
            double media = algoritmo.CalcularMedia(listaDemandas);
            textBox2.Text = media.ToString();

            double varianza = algoritmo.CalcularVarianza(listaDemandas);
            textBox3.Text = varianza.ToString();

            double desviacionEstandar = algoritmo.CalcularDesviacionEstandar(listaDemandas);
            textBox4.Text = desviacionEstandar.ToString();
        }


        public void llenarGrid(List<Demanda> listaDemandas)
        {
            string numeroColumna1 = "1";
            string numeroColumna2 = "2";

            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add(numeroColumna1, "ID");
            dataGridView1.Columns.Add(numeroColumna2, "Valor aleatorio");
            int i = 0;
            foreach (Demanda demanda in listaDemandas)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[Int32.Parse(numeroColumna1) - 1].Value = demanda.IdRequerimiento;
                dataGridView1.Rows[i].Cells[Int32.Parse(numeroColumna2) - 1].Value = demanda.Cantidad.ToString();
                i++;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DescargaExcel(dataGridView1);

        }
        public void DescargaExcel(DataGridView data)
        {
            Microsoft.Office.Interop.Excel.Application exportarExcel = new Microsoft.Office.Interop.Excel.Application();
            exportarExcel.Application.Workbooks.Add(true);
            int indiceColumna = 0;
            // Paso 1: Construyes columnas
            foreach (DataGridViewColumn columna in data.Columns)
            {
                indiceColumna++;
                exportarExcel.Cells[1, indiceColumna] = columna.HeaderText;
            }
            // Paso 2: Construyes filas
            int indiceFilas = 0;

            foreach (DataGridViewRow fila in data.Rows)
            {
                indiceFilas++;
                indiceColumna = 0;
                foreach (DataGridViewColumn columna in data.Columns)
                {
                    indiceColumna++;
                    exportarExcel.Cells[indiceFilas + 1, indiceColumna] = fila.Cells[columna.Name].Value;
                }
            }
            exportarExcel.Visible = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
