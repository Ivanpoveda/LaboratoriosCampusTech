using Microsoft.AspNetCore.Mvc;
using LaboratoriosCampusTech.Data;
using LaboratoriosCampusTech.Models;

namespace LaboratoriosCampusTech.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly IReservationRepository _repo;

        public ReservationsController(IReservationRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            return View(_repo.GetAll());
        }

        public IActionResult Create()
        {
            return View(new Reservation { ReservationDate = DateTime.Today });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Reservation reservation)
        {
            if (_repo.ExistsByCode(reservation.ReservationCode))
                ModelState.AddModelError(nameof(reservation.ReservationCode), "Código ya existe.");

            if (!ModelState.IsValid)
                return View(reservation);

            _repo.Add(reservation);
            return RedirectToAction(nameof(Index));
        }
    }
}