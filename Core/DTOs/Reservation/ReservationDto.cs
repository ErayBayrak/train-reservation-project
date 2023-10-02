using Core.DTOs.Train;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Reservation
{
    public class ReservationDto
    {
        public TrainDto Train { get; set; }
        public int CountOfPassenger { get; set; }
        public bool IsPassengerAnotherWagon { get; set; }
    }
}
