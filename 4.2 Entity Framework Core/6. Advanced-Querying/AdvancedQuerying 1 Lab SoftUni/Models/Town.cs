﻿using System;
using System.Collections.Generic;

#nullable disable

namespace AdvancedQuerying_1_Lab_SoftUni.Models
{
    public partial class Town
    {
        public Town()
        {
            Addresses = new HashSet<Address>();
        }

        public int TownId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}