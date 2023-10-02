using Business.Abstract;
using Core.DTOs.Reservation;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ReservationManager : IReservationService
    {
        IReservationDal _reservationDal;

        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }

        public void Add(Reservation entity)
        {
            _reservationDal.Add(entity);
        }

        public void Delete(Reservation entity)
        {
            _reservationDal.Delete(entity);
        }

        public Reservation Get(Expression<Func<Reservation, bool>> filter)
        {
            return _reservationDal.Get(filter);
        }

        public List<Reservation> GetAll(Expression<Func<Reservation, bool>> filter = null)
        {
            return _reservationDal.GetAll(filter);
        }

        public void Update(Reservation entity)
        {
            _reservationDal.Update(entity);
        }

        public static ResultReservationDto MakeReservation(ReservationDto request)
        {
            var result = new ResultReservationDto();
            var detailResidental = new List<ResidentalDetailDto>();
            var countOfPassengers = request.CountOfPassenger;

            foreach (var wagon in request.Train.Wagons)
            {
                if (countOfPassengers == 0)
                {
                    break;
                }

                var countOfEmptySeat = wagon.Capacity - wagon.CountOfOccupiedSeat;
                var countPassenger = Math.Min(countOfPassengers, countOfEmptySeat);

                if (!request.IsPassengerAnotherWagon && detailResidental.Any())
                {
                    result.IsMakeReservation = false;
                    result.DetailOfResidental = new List<ResidentalDetailDto>();
                    return result;
                }

                if (countPassenger > 0 && countOfEmptySeat >= countPassenger && (double)wagon.CountOfOccupiedSeat / wagon.Capacity < 0.7)
                {
                    detailResidental.Add(new ResidentalDetailDto { WagonName = wagon.Name, CountOfPassenger = countPassenger });
                    countOfPassengers -= countPassenger;
                    wagon.CountOfOccupiedSeat += countPassenger;
                }
            }

            if (countOfPassengers == 0)
            {
                result.IsMakeReservation = true;
                result.DetailOfResidental = detailResidental;
            }
            else
            {
                result.IsMakeReservation = false;
                result.DetailOfResidental = new List<ResidentalDetailDto>();
            }

            return result;
        }
    }
}
