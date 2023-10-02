using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Reservation
{
    public class ResultReservationDto
    {
        public bool IsMakeReservation { get; set; }
        public List<ResidentalDetailDto> DetailOfResidental { get; set; }
    }
}
