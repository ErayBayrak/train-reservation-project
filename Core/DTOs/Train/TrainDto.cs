using Core.DTOs.Wagon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Train
{
    public class TrainDto
    {
        public string Name { get; set; }
        public List<WagonDto> Wagons { get; set; }
    }
}
