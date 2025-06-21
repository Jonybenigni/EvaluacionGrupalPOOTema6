using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace EvaluaciónGrupalPOOTema_6
{
    public class Empleado : IValidatableObject
    {
        public string Legajo { get; set; }

        public string Nombre { get; set; } = null!;

        public DateTime FechaIngreso { get; set; }

        public double SueldoBase { get; set; }

        public  double Antiguedad;

        public Empleado(string legajo, string nombre, double antiguedad, DateTime fechaIngreso, double sueldoBase)
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

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            
            if (string.IsNullOrWhiteSpace(Legajo) || !Regex.IsMatch(Legajo, @"^[A-Za-z]{2}[0-9]{3}$"))
            {
                yield return new ValidationResult("El legajo debe tener exactamente 2 letras seguidas de 3 números (ej. AB123).", new[] { nameof(Legajo) });
            }

            if (string.IsNullOrWhiteSpace(Nombre))
            {
                yield return new ValidationResult("El nombre no puede estar vacío ni contener solo espacios.", new[] { nameof(Nombre) });
            }

            if (Antiguedad < 0)
            {
                yield return new ValidationResult("La antigüedad no puede ser negativa.", new[] { nameof(Antiguedad) });
            }

            if (FechaIngreso > DateTime.Now)
            {
                yield return new ValidationResult("La fecha de ingreso no puede ser superior a la fecha actual.", new[] { nameof(FechaIngreso) });
            }
        }
    }  }
