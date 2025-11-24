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
            return View(new Reservation { FechaReservacion = DateTime.Today });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Reservation reservation)
        {
            if (_repo.ExistsByCode(reservation.CodigoReservacion))
                ModelState.AddModelError(nameof(reservation.CodigoReservacion), "Código ya existe.");

            if (!ModelState.IsValid)
                return View(reservation);

            _repo.Add(reservation);
            return RedirectToAction(nameof(Index));
        }
    }
}