using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LaboratoriosCampusTech.Models
{
    public class Reservation : IValidatableObject
    {
        [Required]
        [MinLength(3)]
        public string ProfessorName { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression(@"^[\w\.-]+@campus\.edu$", ErrorMessage = "Debe ser un correo institucional @campus.edu")]
        public string InstitucionalEmail { get; set; }

        [Required]
        [RegularExpression(@"^(Lab-01|Lab-02|Lab-03|Lab-Redes|Lab-IA)$")]
        public string Lab { get; set; }

        [Required]
        public DateTime ReservationDate { get; set; }

        [Required]

        public TimeSpan StartTime { get; set; }

        [Required]

        public TimeSpan EndTime { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(200)]
        public string Reason { get; set; }

        [Required]
        [RegularExpression(@"^RES-\d{3}$")]
        public string ReservationCode { get; set; }

        public string TimeRange => $"{StartTime:hh\\:mm} - {EndTime:hh\\:mm}";

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ReservationDate.Date < DateTime.Today)
                yield return new ValidationResult("La fecha no puede ser pasada.", new[] { nameof(ReservationDate) });

            if (EndTime <= StartTime)
                yield return new ValidationResult("La hora de fin debe ser mayor a la de inicio.", new[] { nameof(EndTime) });
        }
    }
}