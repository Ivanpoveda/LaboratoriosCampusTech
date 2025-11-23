using System.Collections.Generic;
using System.Linq;
using LaboratoriosCampusTech.Models;

namespace LaboratoriosCampusTech.Data
{
    public class InMemoryReservationRepository : IReservationRepository
    {
        private readonly List<Reservation> _reservations = new();

        public InMemoryReservationRepository()
        {
            _reservations.Add(new Reservation
            {
                ProfessorName = "Dr. Ana López",
                InstitucionalEmail = "ana.lopez@campus.edu",
                Lab = "Lab-01",
                ReservationDate = System.DateTime.Today.AddDays(1),
                StartTime = new System.TimeSpan(9, 0, 0),
                EndTime = new System.TimeSpan(11, 0, 0),
                Reason = "Clase de programación.",
                ReservationCode = "RES-001"
            });
        }

        public IEnumerable<Reservation> GetAll() =>
            _reservations.OrderBy(r => r.ReservationDate).ThenBy(r => r.StartTime);

        public void Add(Reservation r)
        {
            if (ExistsByCode(r.ReservationCode))
                throw new System.Exception("El código ya existe.");
            _reservations.Add(r);
        }

        public bool ExistsByCode(string code) =>
            _reservations.Any(r => r.ReservationCode.ToUpper() == code.ToUpper());
    }
}