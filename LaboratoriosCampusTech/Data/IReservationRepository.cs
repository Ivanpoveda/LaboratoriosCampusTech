using System.Collections.Generic;
using LaboratoriosCampusTech.Models;

namespace LaboratoriosCampusTech.Data
{
    public interface IReservationRepository
    {
        IEnumerable<Reservation> GetAll();
        void Add(Reservation r);
        bool ExistsByCode(string code);
    }
}
