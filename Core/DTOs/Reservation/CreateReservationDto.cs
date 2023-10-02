using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Reservation
{
    public class CreateReservationDto
    {
        public int CountOfPassenger { get; set; }
        public int TrainId { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}
