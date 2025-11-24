using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LaboratoriosCampusTech.Models
{
    public class Reservation : IValidatableObject
    {
        [Required]
        [MinLength(3)]
        public string NombreProfesor { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression(@"^[\w\.-]+@campus\.edu$", ErrorMessage = "Debe ser un correo institucional @campus.edu")]
        public string EmailInstitucional { get; set; }

        [Required]
        [RegularExpression(@"^(Lab-01|Lab-02|Lab-03|Lab-04|Lab-05)$")]
        public string Lab { get; set; }

        [Required]
        public DateTime FechaReservacion { get; set; }

        [Required]

        public TimeSpan TiempoInicio { get; set; }

        [Required]

        public TimeSpan TiempoFinal { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(200)]
        public string Razon { get; set; }

        [Required]
        [RegularExpression(@"^RES-\d{3}$", ErrorMessage = "El codigo debe ser RES-000")]
        public string CodigoReservacion { get; set; }

        public string TimeRange => $"{TiempoInicio:hh\\:mm} - {TiempoFinal:hh\\:mm}";

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (FechaReservacion.Date < DateTime.Today)
                yield return new ValidationResult("La fecha no puede ser pasada.", new[] { nameof(FechaReservacion) });

            if (TiempoFinal <= TiempoInicio)
                yield return new ValidationResult("La hora de fin debe ser mayor a la de inicio.", new[] { nameof(TiempoFinal) });
        }
    }
}