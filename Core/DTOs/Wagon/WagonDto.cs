using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Wagon
{
    public class WagonDto
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int CountOfOccupiedSeat { get; set; }
    }
}
