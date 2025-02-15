﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebAPItwe.Entities
{
    [Table("Payment")]
    public partial class Payment
    {
        public string Id { get; set; }
        public double Amount { get; set; }
        public string Type { get; set; }
        public string SessionId { get; set; }
        public string Status { get; set; }


        public virtual Session Session { get; set; }
    }
}
