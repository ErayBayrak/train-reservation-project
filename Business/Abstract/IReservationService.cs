using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IReservationService
    {
        List<Reservation> GetAll(Expression<Func<Reservation, bool>> filter = null);
        Reservation Get(Expression<Func<Reservation, bool>> filter);
        void Add(Reservation entity);
        void Update(Reservation entity);
        void Delete(Reservation entity);
    }
}
