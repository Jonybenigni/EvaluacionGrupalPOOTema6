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

        public int AdicionalUsoArma { get; set; } = 1000;

        public Seguridad(int legajo, string nombre, double antiguedad, DateTime fechaIngreso, double sueldoBase) : base(legajo, nombre, antiguedad, fechaIngreso, sueldoBase)
        {




        }

        public new double CalcularSueldo()
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
