﻿using EvaluacionGrupal6.Datos;
using EvaluacionGrupal6.Utilidades;
using EvaluaciónGrupalPOOTema_6;
using System.ComponentModel.DataAnnotations;


namespace EvaluacionGrupal6.Consola
{
    public class Menu
    {
        static RepositorioEmpleadosOperadores repoOperadores = new RepositorioEmpleadosOperadores();
        static RepositorioEmpleadosLinq repoLinq = new RepositorioEmpleadosLinq();

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
                Console.WriteLine("6. Mostrar solo Seguridad");
                Console.WriteLine("7. Mostrar solo Supervisores");
                Console.WriteLine("8. Mostrar solo Operarios");
                Console.WriteLine("9. Mostrar solo de Administrativos");
                Console.WriteLine("10. Listar Operarios por turno");
                Console.WriteLine("11. Mostrar estadísticas de los Empleados");
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
                    case 9: MostrarPorTipo(typeof(Administrativo)); break; 
                    case 10: MostrarOperariosPorTurno(); break;
                    case 11: MostrarEstadisticas(); break;
                }

                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            } while (opcion != 0);
        }

        static void CargarPersonalInicial()
        {
            Empleado s1 = new Seguridad("DO123", "Carlos Gómez", 10, new DateTime(2010, 5, 1), 70000, true);
            Empleado s2 = new Supervisor("DR456", "Laura Suárez", Supervisor.AreaEnum.Personal, 15, new DateTime(2005, 3, 10), 7000);
            Empleado s3 = new Operario("OP789", "Luis López", Operario.TurnoEnum.Noche, Operario.AdicionalTurnoEnum.Noche, 8, new DateTime(2015, 9, 20), 60000);
            Empleado s4 = new Administrativo("AD001", "Ana Pérez", 5, new DateTime(2018, 1, 15), 50000,2);

            repoOperadores += s1;
            repoOperadores += s2;
            repoOperadores += s3;
            repoOperadores += s4;


            repoLinq.Agregar(s1);
            repoLinq.Agregar(s2);
            repoLinq.Agregar(s3);
            repoLinq.Agregar(s4);
        }

        static void AltaPersonal()
        {
            Console.Write("Ingrese legajo (ej: AB123): ");
            string legajo = Console.ReadLine().ToUpper();

            if (repoLinq.GetLista().Any(p => p.Legajo == legajo))
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

            Console.WriteLine("Tipo de empleado: 1-Seguridad, 2-Supervisor, 3-Operario, 4-Administrativo");
            int tipo = int.Parse(Console.ReadLine());

            Empleado nuevo = null!;

            switch (tipo)
            {
                case 1:
                    Console.Write("¿Usa arma? (s/n): ");
                    bool usaArma = Console.ReadLine().Trim().ToLower() == "s";
                    nuevo = new Seguridad(legajo, nombre, antiguedad, fechaIngreso, sueldoBase, usaArma);
                    break;
                case 2:
                    Console.WriteLine("Seleccione área: 0-Personal, 1-Producción, 2-Mantenimiento");
                    var area = (Supervisor.AreaEnum)int.Parse(Console.ReadLine());
                    nuevo = new Supervisor(legajo, nombre, area, antiguedad, fechaIngreso, sueldoBase);
                    break;
                case 3:
                    Console.WriteLine("Seleccione turno: 0-Mañana, 1-Tarde, 2-Noche");
                    var turno = (Operario.TurnoEnum)int.Parse(Console.ReadLine());
                    Console.WriteLine("Seleccione adicional: 0-Mañana, 1-Tarde, 2-Noche");
                    var adicional = (Operario.AdicionalTurnoEnum)int.Parse(Console.ReadLine());
                    nuevo = new Operario(legajo, nombre, turno, adicional, antiguedad, fechaIngreso, sueldoBase);
                    break;
                case 4:
                    Console.Write("Ingrese cantidad de horas extras: ");
                    double horasExtras = double.Parse(Console.ReadLine());
                    var admin = new Administrativo(legajo, nombre, antiguedad, fechaIngreso, sueldoBase, horasExtras);
                    admin.HorasExtras = horasExtras;
                    nuevo = admin;
                    break;
            }

            if (nuevo != null)
            {
                var context = new ValidationContext(nuevo);
                var results = new List<ValidationResult>();

                if (!Validator.TryValidateObject(nuevo, context, results, true))
                {
                    foreach (var e in results)
                        Console.WriteLine(e.ErrorMessage);
                }
                else
                {
                    repoOperadores += nuevo;
                    repoLinq.Agregar(nuevo);
                    Console.WriteLine("Empleado agregado exitosamente.");
                }
            }
        }

        static void BajaPersonal()
        {
            Console.Write("Ingrese legajo a eliminar: ");
            string legajo = Console.ReadLine().ToUpper();

            
            Empleado emp = repoOperadores[repoOperadores.MostrarIndicePorLegajo(legajo)];
            if (emp != null)
            {
                repoOperadores -= legajo;
                repoLinq.GetLista().RemoveAll(e => e.Legajo == legajo);
                Console.WriteLine("Empleado eliminado.");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }

        static void ModificarPersonal()
        {
            Console.Write("Ingrese legajo a modificar: ");
            string legajo = Console.ReadLine().ToUpper();

            var emp = repoLinq.GetLista().FirstOrDefault(p => p.Legajo == legajo);
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

                if (emp is Administrativo admin)
                {
                    Console.Write("Nueva cantidad de horas extras: ");
                    admin.HorasExtras = double.Parse(Console.ReadLine());
                }

                Console.WriteLine("Modificación realizada.");
            }
            else
                Console.WriteLine("Empleado no encontrado.");
        }

        static void BuscarPersonal()
        {
            Console.Write("Ingrese legajo a buscar: ");
            string legajo = Console.ReadLine().ToUpper();

            var emp = repoLinq.GetLista().FirstOrDefault(p => p.Legajo == legajo);
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
            foreach (var emp in repoLinq.GetLista())
                MostrarEmpleado(emp);
        }

        static void MostrarPorTipo(Type tipo)
        {
            var filtrados = repoLinq.GetLista().Where(p => p.GetType() == tipo);
            foreach (var emp in filtrados)
                MostrarEmpleado(emp);
        }

        static void MostrarOperariosPorTurno()
        {
            Console.WriteLine("Turno: 0-Mañana, 1-Tarde, 2-Noche");
            Console.Write("Seleccione una opción: ");
            string entrada = Console.ReadLine();

            if (int.TryParse(entrada, out int turnoInt) &&
                Enum.IsDefined(typeof(Operario.TurnoEnum), turnoInt))
            {
                var turno = (Operario.TurnoEnum)turnoInt;
                var operarios = repoLinq.ListarOperariosPorTurno(turno);

                if (operarios.Any())
                {
                    foreach (var o in operarios)
                        MostrarEmpleado(o);
                }
                else
                {
                    Console.WriteLine("No hay operarios en ese turno.");
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida. Debe ingresar 0, 1 o 2.");
            }
        }

        static void MostrarEmpleado(Empleado emp)
        {
            Console.Write($"[{emp.GetType().Name}] Legajo: {emp.Legajo}, Nombre: {emp.Nombre}, Sueldo: {emp.CalcularSueldo():C}");

            if (emp is Seguridad s)
                Console.Write($", Usa arma: {(s.TieneArma ? "Sí" : "No")}");

            if (emp is Administrativo a)
                Console.Write($", Horas extras: {a.HorasExtras}");

            Console.WriteLine();
        }

        static void MostrarEstadisticas()
        {
            ExtensionesConsola.Titulo("Estadísticas del Personal");

            var lista = repoLinq.GetLista();

            Console.WriteLine($"Promedio de sueldos: {UtilidadesPersonal.CalcularPromedioSueldos(lista):C}");

            var mayorAnt = UtilidadesPersonal.ObtenerConMayorAntiguedad(lista);
            if (mayorAnt != null)
                Console.WriteLine($"Empleado con mayor antigüedad: {mayorAnt.Nombre} ({mayorAnt.Antiguedad} años)");

            Console.WriteLine($"Cantidad que usan arma: {UtilidadesPersonal.CantidadConArma(lista)}");

            Console.WriteLine("Cantidad por turno:");
            var turnos = UtilidadesPersonal.CantidadPorTurno(lista);
            foreach (var kvp in turnos)
            {
                Console.WriteLine($"- {kvp.Key}: {kvp.Value}");
            }

            ExtensionesConsola.Separador();
        }

    }
    
}
