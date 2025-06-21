using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EvaluaciónGrupalPOOTema_6.Operario;

namespace EvaluaciónGrupalPOOTema_6
{
    public class Supervisor : Empleado
    {
        public AreaEnum Area { get; set; }

        public static int BonoFijo { get; set; } = 20000; 
        public enum AreaEnum
        {
           Personal,
           Fabrica,
           Ventas

        }
        

        public Supervisor(string legajo, string nombre,AreaEnum area, double antiguedad, DateTime fechaIngreso, double sueldoBase) : base(legajo, nombre, antiguedad, fechaIngreso, sueldoBase)
        {

            Area = area;

        }

        public new double CalcularSueldo()
        {
            return SueldoBase + BonoFijo;
        }
    }
}
