using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectInicial.Algoritmos.Models
{
    public class Demanda
    {
        public string IdRequerimiento { get; set; }
        public double Cantidad { get; set; }
        public string NombreCliente { get; set; }

        public DateTime FechaRequerimiento { get; set; }

        public Demanda()
        {
        }

        public Demanda(string idRequerimiento, double cantidad,
            string nombreCliente, DateTime fechaRequerimiento)
        {
            IdRequerimiento = idRequerimiento;
            Cantidad = cantidad;
            NombreCliente = nombreCliente;
            FechaRequerimiento = fechaRequerimiento;
        }
    }

}
