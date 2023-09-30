using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Reservation:IEntity
    {
        public int Id { get; set; }
        public int CountOfPassenger { get; set; }
        public Train Train { get; set; }
        public int TrainId { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}
