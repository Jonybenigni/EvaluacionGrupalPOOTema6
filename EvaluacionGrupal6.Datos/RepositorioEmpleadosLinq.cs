using EvaluaciónGrupalPOOTema_6;

namespace EvaluacionGrupal6.Datos
{
    public class RepositorioEmpleadosLinq
    {
        private List<Empleado> empleados = new();
        
        public string ruta = "Empleados.txt";

        public RepositorioEmpleadosLinq(string rutaArchivo)
        {
            ruta = rutaArchivo;
            LeerDatos();
        }

        public RepositorioEmpleadosLinq()
        {
        }

        public List<Empleado> GetEmpleado()
        {
            return empleados.OrderBy(p => p.Nombre).ToList();
        }

        public List<Empleado> GetLista()
        {
            return empleados;
        }

        private void LeerDatos()
        {
            if (!File.Exists(ruta))
            {
                return;
            }
            var registros = File.ReadAllLines(ruta);
            foreach (var registro in registros)
            {
                Empleado empleado = ConstruirEmpleado(registro);
                empleados.Add(empleado);
            }

        }

        private Empleado ConstruirEmpleado(string registro)
        {
            var campos = registro.Split('|');
            var empleadoId = int.Parse(campos[0]);
            var nombreEmpleado = campos[1];
            return new Empleado()
            {
                Nombre = nombreEmpleado,
                EmpleadoId = empleadoId,
            };
        }

        private int SetearEmpleadoId()
        {
            if (empleados.Any())
            {
                return empleados.Max(p => p.EmpleadoId) + 1;
            }
            else
            {
                return 1;
            }
        }


        public bool Existe(Empleado empleado)
        {
            return empleado.EmpleadoId == 0 ? empleados.Any(p => p.Nombre == empleado.Nombre) :
                empleados.Any(p => p.Nombre == empleado.Nombre && p.EmpleadoId != empleado.EmpleadoId);
        }

        public void Agregar(Empleado empleado)
        {
            empleado.EmpleadoId = SetearEmpleadoId();
            empleados.Add(empleado);
            if (File.Exists(ruta))
            {
                var registros = File.ReadAllText(ruta);
                if (!string.IsNullOrEmpty(registros) && !registros.EndsWith(Environment.NewLine))
                {
                    File.WriteAllText(ruta, Environment.NewLine);

                }
            }
            using (var escritor = new StreamWriter(ruta, true))
            {
                string linea = ConstruirLinea(empleado);
                escritor.WriteLine(linea);
            }
        }

        public void Borrar(Empleado empleado)
        {
            Empleado? empleadoBorrar = empleados.FirstOrDefault(p => p.Nombre == empleado.Nombre);
            if (empleadoBorrar is null)
            {
                return;
            }
            empleados.Remove(empleadoBorrar);

            var registros = empleados.Select(p => ConstruirLinea(p)).ToArray();
            File.WriteAllLines(ruta, registros);

        }

        public void Editar(Empleado empleado)
        {
            var empleadoEditado = empleados.FirstOrDefault(p => p.EmpleadoId == empleado.EmpleadoId);
            if (empleadoEditado is null)
            {
                return;
            }
            empleadoEditado.Nombre = empleado.Nombre;
            var registros = empleados.Select(p => ConstruirLinea(p)).ToArray();
            File.WriteAllLines(ruta, registros);


        }

        private string ConstruirLinea(Empleado empleado)
        {
            return $"{empleado.EmpleadoId}|{empleado.Nombre}";
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
