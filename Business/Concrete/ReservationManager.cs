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

    }
}
