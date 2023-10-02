using Business.Abstract;
using Business.Concrete;
using Core.DTOs.Reservation;
using Core.DTOs.ReservationDetail;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
            _context = context;
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var reservation = _reservationService.Get(x => x.Id == id);
            return Ok(reservation);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var reservations = _reservationService.GetAll();
            return Ok(reservations);
        }
        [HttpPost]
        public IActionResult Add(CreateReservationDto dto)
        {
            Reservation reservation = new Reservation();
            reservation.CountOfPassenger = dto.CountOfPassenger;
            reservation.ReservationDate = dto.ReservationDate;
            reservation.TrainId = dto.TrainId;
            _reservationService.Add(reservation);
            return Ok(reservation);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var train = _reservationService.Get(c => c.Id == id);
                if (train == null)
                {
                    return NotFound();
                }
                _reservationService.Delete(train);
                return Ok("Başarıyla silindi.");
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CreateReservationDto dto)
        {
            var reservation = _reservationService.Get(c => c.Id == id);
            reservation.CountOfPassenger = dto.CountOfPassenger;
            reservation.ReservationDate = dto.ReservationDate;
            reservation.TrainId = dto.TrainId;
            _reservationService.Update(reservation);
            return Ok(reservation);
        }

        [HttpPost("makereservation")]
        public IActionResult MakeReservation([FromBody] ReservationRequestDto request)
        {
            
           if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           var response = ProcessReservation(request);
            return Ok(response);
        }
        private List<ReservationResponseDto> ProcessReservation(ReservationRequestDto request)
        {
            var train = request.Train;
            var reservationCount = request.CountOfPassengerForReservation;
            var allowMultipleWagons = request.IsPassengersAnotherWagon;

            var responses = new List<ReservationResponseDto>();

            var availableWagons = train.Wagons
                .Where(v => v.CountOfOccupiedSeat + reservationCount <= v.Capacity && ((double)v.CountOfOccupiedSeat + reservationCount) / v.Capacity <= 0.7)
                .ToList();

            foreach (var wagon in availableWagons)
            {
                var availableSeats = wagon.Capacity - wagon.CountOfOccupiedSeat;
                var passengersToPlace = Math.Min(reservationCount, availableSeats);
                var response = new ReservationResponseDto
                {
                    IsMakeReservation = true,
                    DetailResidential = new List<ReservationDetailDto>
            {
                new ReservationDetailDto
                {
                    WagonName = wagon.Name,
                    CountOfPassengers = passengersToPlace
                }
            }
                };
                responses.Add(response);
                reservationCount -= passengersToPlace;
            }

            return responses;
        }

    }
}
