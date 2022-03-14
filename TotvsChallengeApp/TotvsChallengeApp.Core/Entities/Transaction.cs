using System;
using System.Collections.Generic;

namespace TotvsChallengeApp.Core.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal TotalCost { get; set; }
        public decimal Change { get; set; }
        public string MessageChange { get; set; }
        public DateTime DateCreate { get; set; }
    }
}
