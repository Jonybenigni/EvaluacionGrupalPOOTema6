using EvaluaciónGrupalPOOTema_6;
using System.ComponentModel.DataAnnotations;

namespace EvaluacionGrupal6.Consola
{
    public class Menu
    {
        static List<Empleado> personal = new List<Empleado>();

        static void Main()
        {
            CargarPersonalInicial();

            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("=== Menú de Personal ===");
                Console.WriteLine("1. Alta de personal");
                Console.WriteLine("2. Baja de personal");
                Console.WriteLine("3. Modificar personal");
                Console.WriteLine("4. Buscar personal por legajo");
                Console.WriteLine("5. Listar todo el personal");
                Console.WriteLine("6. Mostrar solo de Seguridad");
                Console.WriteLine("7. Mostrar solo de Supervisores");
                Console.WriteLine("8. Mostrar solo de Operarios");
                Console.WriteLine("0. Salir");
                Console.Write("Opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1: AltaPersonal(); break;
                    case 2: BajaPersonal(); break;
                    case 3: ModificarPersonal(); break;
                    case 4: BuscarPersonal(); break;
                    case 5: ListarTodo(); break;
                    case 6: MostrarPorTipo(typeof(Seguridad)); break;
                    case 7: MostrarPorTipo(typeof(Supervisor)); break;
                    case 8: MostrarPorTipo(typeof(Operario)); break;
                }

                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            } while (opcion != 0);
        }

        static void CargarPersonalInicial()
        {
            personal.Add(new Seguridad("DO123", "Carlos Gómez", 10, new DateTime(2010, 5, 1), 70000));
            personal.Add(new Supervisor("DR456", "Laura Suárez", Supervisor.AreaEnum.Personal, 15, new DateTime(2005, 3, 10), 7000));
            personal.Add(new Operario("OP789", "Luis López", Operario.TurnoEnum.Noche, Operario.AdicionalTurnoEnum.Noche, 8, new DateTime(2015, 9, 20), 60000));
        }

        static void AltaPersonal()
        {
            Console.Write("Ingrese legajo (ej: AB123): ");
            string legajo = Console.ReadLine().ToUpper();

            if (personal.Any(p => p.Legajo == legajo))
            {
                Console.WriteLine("Ya existe un empleado con ese legajo.");
                return;
            }
            
            Console.Write("Ingrese nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese antigüedad: ");
            double antiguedad = double.Parse(Console.ReadLine());

            

            Console.Write("Ingrese sueldo base: ");
            double sueldoBase = double.Parse(Console.ReadLine());

            Console.Write("Ingrese fecha de ingreso (yyyy-mm-dd): ");
            DateTime fechaIngreso = DateTime.Parse(Console.ReadLine());

            // Ejemplo: Alta como docente
            var nuevo = new Seguridad(legajo, nombre, antiguedad, fechaIngreso, sueldoBase);
            var nuevob = new Operario(legajo, nombre, Operario.TurnoEnum.Noche, Operario.AdicionalTurnoEnum.Noche, antiguedad, fechaIngreso, sueldoBase);
            var nuevoc = new Supervisor(legajo, nombre, Supervisor.AreaEnum.Personal, antiguedad, fechaIngreso, sueldoBase);

            // Validar antes de agregar
            var context = new ValidationContext(nuevo);
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(nuevo, context, results, true))
            {
                foreach (var e in results)
                    Console.WriteLine(e.ErrorMessage);
            }
            else
            {
                personal.Add(nuevo);
                Console.WriteLine("Empleado agregado exitosamente.");
            }
        }

        static void BajaPersonal()
        {
            Console.Write("Ingrese legajo a eliminar: ");
            string legajo = Console.ReadLine().ToUpper();

            var emp = personal.FirstOrDefault(p => p.Legajo == legajo);
            if (emp != null)
            {
                personal.Remove(emp);
                Console.WriteLine("Empleado eliminado.");
            }
            else
                Console.WriteLine("Empleado no encontrado.");
        }

        static void ModificarPersonal()
        {
            Console.Write("Ingrese legajo a modificar: ");
            string legajo = Console.ReadLine().ToUpper();

            var emp = personal.FirstOrDefault(p => p.Legajo == legajo);
            if (emp != null)
            {
                Console.Write("Nuevo nombre: ");
                emp.Nombre = Console.ReadLine();

                Console.Write("Nueva antigüedad: ");
                emp.Antiguedad = double.Parse(Console.ReadLine());

                Console.Write("Nuevo sueldo base: ");
                emp.SueldoBase = double.Parse(Console.ReadLine());

                Console.Write("Nueva fecha ingreso (yyyy-mm-dd): ");
                emp.FechaIngreso = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Modificación realizada.");
            }
            else
                Console.WriteLine("Empleado no encontrado.");
        }

        static void BuscarPersonal()
        {
            Console.Write("Ingrese legajo a buscar: ");
            string legajo = Console.ReadLine().ToUpper();

            var emp = personal.FirstOrDefault(p => p.Legajo == legajo);
            if (emp != null)
            {
                MostrarEmpleado(emp);
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }

        static void ListarTodo()
        {
            foreach (var emp in personal)
                MostrarEmpleado(emp);
        }

        static void MostrarPorTipo(Type tipo)
        {
            var filtrados = personal.Where(p => p.GetType() == tipo);
            foreach (var emp in filtrados)
                MostrarEmpleado(emp);
        }

        static void MostrarEmpleado(Empleado emp)
        {
            Console.WriteLine($"[{emp.GetType().Name}] Legajo: {emp.Legajo}, Nombre: {emp.Nombre}, Sueldo Total: {emp.CalcularSueldo()}");
        }
    }
}
