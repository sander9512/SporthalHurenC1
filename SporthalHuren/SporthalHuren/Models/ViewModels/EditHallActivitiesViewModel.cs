﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SporthalHuren.Models.ViewModels
{
    public class EditHallActivitiesViewModel
    {
        public int SportsHallId { get; set; }
        public List<Domain.SportsHallsActivity> Activities;
    }
}
