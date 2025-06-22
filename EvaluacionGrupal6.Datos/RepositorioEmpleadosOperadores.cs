using EvaluaciónGrupalPOOTema_6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionGrupal6.Datos
{
    public class RepositorioEmpleadosOperadores
    {

        private List<Empleado> empleados = new List<Empleado>();

        private readonly RepositorioEmpleadosLinq _empleadoRepositorio = null!;
        public RepositorioEmpleadosOperadores(string ruta)
        {
            _empleadoRepositorio = new RepositorioEmpleadosLinq(ruta);
        }

        public void Borrar(Empleado empleado)
        {
            _empleadoRepositorio.Borrar(empleado);
        }

        public bool Existe(Empleado empleado)
        {
            return _empleadoRepositorio.Existe(empleado);
        }

        public List<Empleado> GetEmpleado()
        {
            return _empleadoRepositorio.GetEmpleado();
        }

        public void Guardar(Empleado empleado)
        {
            if (empleado.EmpleadoId == 0)
            {
                _empleadoRepositorio.Agregar(empleado);

            }
            else
            {
                _empleadoRepositorio.Editar(empleado);
            }
        }

        public static RepositorioEmpleadosOperadores operator +(RepositorioEmpleadosOperadores repo, Empleado e)
        {
            if (!repo.empleados.Any(x => x.Legajo == e.Legajo))
            {
                repo.empleados.Add(e);
            }
            return repo;
        }

        public static RepositorioEmpleadosOperadores operator -(RepositorioEmpleadosOperadores repo, string legajo)
        {
            var emp = repo.empleados.FirstOrDefault(e => e.Legajo == legajo);
            if (emp != null)
            {
                repo.empleados.Remove(emp);
            }
            return repo;
        }
        public int MostrarIndicePorLegajo(string legajo)
        {
            return empleados.FindIndex(e => e.Legajo == legajo);
        }
        public static bool operator ==(RepositorioEmpleadosOperadores repo, Empleado e)
        {
            return repo.empleados.Any(x => x.Legajo == e.Legajo);
        }

        public static bool operator !=(RepositorioEmpleadosOperadores repo, Empleado e)
        {
            return !(repo == e);
        }

        public Empleado this[int index]
        {
            get => empleados[index];
            set => empleados[index] = value;
        }

        public void MostrarTodo()
        {
            foreach (var emp in empleados)
            {
                Console.WriteLine($"[{emp.GetType().Name}] {emp.Legajo} - {emp.Nombre} - Sueldo: {emp.CalcularSueldo():C}");
            }
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
