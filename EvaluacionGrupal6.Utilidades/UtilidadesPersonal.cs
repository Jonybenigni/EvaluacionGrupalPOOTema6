using EvaluaciónGrupalPOOTema_6;

namespace EvaluacionGrupal6.Utilidades
{
    public class UtilidadesPersonal
    {
        public static double CalcularPromedioSueldos(List<Empleado> empleados)
        {
            return empleados.Any() ? empleados.Average(e => e.CalcularSueldo()) : 0;
        }

        public static Empleado ObtenerConMayorAntiguedad(List<Empleado> empleados)
        {
            return empleados.OrderByDescending(e => e.Antiguedad).FirstOrDefault();
        }

        public static Dictionary<Operario.TurnoEnum, int> CantidadPorTurno(List<Empleado> empleados)
        {
            return empleados
                .OfType<Operario>()
                .GroupBy(o => o.Turno)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        public static int CantidadConArma(List<Empleado> empleados)
        {
            return empleados
                .OfType<Seguridad>()
                .Count(s => s.TieneArma);
        }
    }
}
