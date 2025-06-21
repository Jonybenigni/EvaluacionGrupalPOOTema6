using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluaciónGrupalPOOTema_6
{
    public class Seguridad : Empleado
    {
        public bool TieneArma { get; set; }

        public int AdicionalUsoArma { get; set; } = 10000;

        public Seguridad(string legajo, string nombre, double antiguedad, DateTime fechaIngreso, double sueldoBase, bool tieneArma) : base(legajo, nombre, antiguedad, fechaIngreso, sueldoBase)
        {

            TieneArma = tieneArma;


        }

        public override double CalcularSueldo()
        {
            double sueldo = base.CalcularSueldo();
            if (TieneArma==true)
            {
                sueldo += AdicionalUsoArma;
            }
            return sueldo;
        }
    }
}
