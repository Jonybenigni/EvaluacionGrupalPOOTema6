using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionGrupal6.Utilidades
{
    public class ExtensionesConsola
    {
        public static void EscribirConColor(string texto, ConsoleColor color)
        {
            var anterior = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(texto);
            Console.ForegroundColor = anterior;
        }

        public static void Titulo(string texto)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=== " + texto.ToUpper() + " ===");
            Console.ResetColor();
        }

        public static void Separador()
        {
            Console.WriteLine(new string('-', 50));
        }

        public static void MensajeError(string mensaje)
        {
            EscribirConColor("ERROR: " + mensaje, ConsoleColor.Red);
        }

        public static void MensajeExito(string mensaje)
        {
            EscribirConColor("✔ " + mensaje, ConsoleColor.Green);
        }
    }
}
