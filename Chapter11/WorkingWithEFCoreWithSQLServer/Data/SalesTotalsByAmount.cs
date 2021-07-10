﻿using System;
using System.Collections.Generic;

#nullable disable

namespace WorkingWithEFCoreWithSQLServer.Data
{
    public partial class SalesTotalsByAmount
    {
        public decimal? SaleAmount { get; set; }
        public int OrderId { get; set; }
        public string CompanyName { get; set; }
        public DateTime? ShippedDate { get; set; }
    }
}