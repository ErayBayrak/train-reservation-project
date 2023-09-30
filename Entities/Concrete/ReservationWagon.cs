﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ReservationWagon:IEntity
    {
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public int WagonId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
