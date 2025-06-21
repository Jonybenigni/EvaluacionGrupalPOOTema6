using EvaluaciónGrupalPOOTema_6;

namespace EvaluacionGrupal6.Datos
{
    public class RepositorioEmpleadosLinq
    {
        private List<Empleado> empleados=null!;


        public RepositorioEmpleadosLinq()
        {
            empleados = new List<Empleado>();
        }

        public List<Empleado> GetLista()
        {
            return empleados;
        }
        public bool Agregar(Empleado empleado)
        {
            if (Existe(empleado)) return false;
            empleados.Add(empleado);
            return true;
        }
        public bool Existe(Empleado empleado)
        {
            return empleados.Contains(empleado);
        }
        public int GetCantidad()
        {
            return empleados.Count;
        }

        public List<Empleado> BuscarPorNombre(string nombre)
        {
            return empleados
                   .Where(e => e.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase))
                   .ToList();
        }

        public List<Empleado> ListarPorTipoExacto(Type tipo)
        {
            return empleados
                   .Where(e => e.GetType() == tipo)
                   .ToList();
        }

        public List<Empleado> OrdenarPorSueldo(bool descendente = false)
        {
            return descendente
                ? empleados.OrderByDescending(e => e.SueldoBase).ToList()
                : empleados.OrderBy(e => e.SueldoBase).ToList();
        }

        public List<Operario> ListarOperariosPorTurno(Operario.TurnoEnum turno)
        {
            return empleados
                .OfType<Operario>()
                .Where(o => o.Turno == turno)
                .ToList();
        }




    }
}
