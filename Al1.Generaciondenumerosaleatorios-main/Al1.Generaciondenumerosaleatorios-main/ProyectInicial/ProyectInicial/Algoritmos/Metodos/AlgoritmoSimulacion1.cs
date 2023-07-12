using ProyectInicial.Algoritmos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectInicial.Algoritmos.Metodos
{
    public class AlgoritmoSimulacion1
    {
        List<Demanda> listaDemandas = new List<Demanda>();


        public AlgoritmoSimulacion1()
        {

        }
        public double CalcularMedia(List<Demanda> listaDemandas)
        {
            double media = 0;

            foreach (Demanda demanda in listaDemandas) // Recorrer cada elemento de la lista
            {

                media += demanda.Cantidad; // Sumar la cantidad de demanda a la variable 'suma'

            }
            double promedio = media / listaDemandas.Count(); // Calcular la media dividiendo la suma entre el número total de elementos en 'listaDemandas'

            return promedio; // Retornar el resultado de la media

        }
        public double CalcularVarianza(List<Demanda> listaDemandas)
        {
            double promedio = CalcularMedia(listaDemandas);
            double varianza = 0;

            foreach (Demanda demanda in listaDemandas)
            {
                double dif = demanda.Cantidad - promedio;
                varianza += dif * dif;
            }

            varianza = varianza / listaDemandas.Count;

            return varianza;
        }
        public double CalcularDesviacionEstandar(List<Demanda> listaDemandas)
        {
            double varianza = CalcularVarianza(listaDemandas);
            double desviacionEstandar = Math.Sqrt(varianza);
            return desviacionEstandar;
        }
        public List<Demanda> CalculoDemanda(int total)
        {
            // Paso 1: Variable random
            Random random = new Random(Environment.TickCount);
            // Paso 2: Ciclo de generar valores
            for (int i = 0; i < total; i++)
            {
                // Paso 2.1:  Generamos un valor aleatorio con distribución uniforme
                int valor = random.Next(1, total);
                // Paso 2.2: Se guarda en el objeto demanda
                Demanda demanda = new Demanda();
                demanda.Cantidad = valor;
                demanda.IdRequerimiento = i.ToString();
                // Paso 2.3:  Se guarda en la lista
                listaDemandas.Add(demanda);
            }

            return listaDemandas;
        }
    }
}