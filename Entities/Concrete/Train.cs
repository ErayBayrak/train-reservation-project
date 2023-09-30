using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Train:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Wagon> Wagons { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}
