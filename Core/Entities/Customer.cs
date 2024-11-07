﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; }
    }
}
