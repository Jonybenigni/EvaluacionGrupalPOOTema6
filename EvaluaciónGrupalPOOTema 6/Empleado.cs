namespace EvaluaciónGrupalPOOTema_6
{
    public class Empleado
    {
        public int Legajo { get; set; }

        public string Nombre { get; set; } = null!;

        public DateTime FechaIngreso { get; set; }

        public double SueldoBase { get; set; }

        public readonly double Antiguedad;

        public Empleado(int legajo, string nombre,double antiguedad, DateTime fechaIngreso, double sueldoBase)
        {
            Legajo = legajo;
            Nombre = nombre;
            FechaIngreso = fechaIngreso;
            SueldoBase = sueldoBase;
            Antiguedad = antiguedad;
        }

        public double PorcentajePorAntiguedad()
        {
            double antiguedad = (DateTime.Now - FechaIngreso).TotalDays / 365; // Calcula la antigüedad en años
            return antiguedad * 0.03; // Retorna el porcentaje de antigüedad
        }

        public double CalcularSueldo()
        {
            return SueldoBase;
        }








    }
}
