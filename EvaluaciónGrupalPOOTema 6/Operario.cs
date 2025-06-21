using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluaciónGrupalPOOTema_6
{
    public class Operario : Empleado
    {
        public TurnoEnum Turno { get; set; }
        public AdicionalTurnoEnum AdicionalTurno { get; set; }
        public enum TurnoEnum
        {
            Mañana,
            Tarde,
            Noche
        }

        public enum AdicionalTurnoEnum
        {
            Mañana = 3000,
            Tarde = 5000,
            Noche = 7000
        }


        public Operario(string legajo, string nombre,TurnoEnum turno, AdicionalTurnoEnum adicionalTurno , double antiguedad, DateTime fechaIngreso, double sueldoBase) : base(legajo, nombre, antiguedad, fechaIngreso, sueldoBase)
        {

            Turno = turno;
            AdicionalTurno = adicionalTurno;


        }

        public new double CalcularSueldo()
        {
            return SueldoBase + (int)AdicionalTurno;
        }
    }
}
