using System.Collections.Generic;
using System.Linq;
using LaboratoriosCampusTech.Models;

namespace LaboratoriosCampusTech.Data
{
    public class InMemoryReservationRepository : IReservationRepository
    {
        private readonly List<Reservation> _reservations = new();
     
            public void AddReservation(Reservation r)
        {
            if (string.IsNullOrWhiteSpace(r.NombreProfesor) ||
                string.IsNullOrWhiteSpace(r.EmailInstitucional) ||
                string.IsNullOrWhiteSpace(r.Lab) ||
                string.IsNullOrWhiteSpace(r.Razon) ||
                r.TiempoInicio == r.TiempoFinal)
            {
                // No agregar reservas inválidas
                return;
            }

            _reservations.Add(r);
        }
        

        public IEnumerable<Reservation> GetAll() =>
            _reservations.OrderBy(r => r.FechaReservacion).ThenBy(r => r.TiempoInicio);

        public void Add(Reservation r)
        {
            if (ExistsByCode(r.CodigoReservacion))
                throw new System.Exception("El código ya existe.");
            _reservations.Add(r);
        }

        public bool ExistsByCode(string code) =>
            _reservations.Any(r => r.CodigoReservacion.ToUpper() == code.ToUpper());
    }
}