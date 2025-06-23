using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluaciónGrupalPOOTema_6
{
    public class Administrativo : Empleado
    {
        public double HorasExtras { get; set; }

        public double PrecioPorHoraExtra { get; set; } = 2000; 


        public Administrativo(string legajo, string nombre, double antiguedad, DateTime fechaIngreso, double sueldoBase, double horasExtras) : base(legajo, nombre, antiguedad, fechaIngreso, sueldoBase)
        {
            HorasExtras = horasExtras;

        }

        public override double CalcularSueldo()
        {
            return SueldoBase + (HorasExtras*PrecioPorHoraExtra);
        }
    }
}
