using System;
using XmlParser.Entities;

namespace XmlParser.ExpenseApi.Models
{
    public class ExpenseEntry : BaseEntity
    {
        public string Category { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string PaymentMethod { get; set; }

        public double GstAmount
        {
            get
            {
                return Amount * 0.15;
            }
        }
        public double TotalAmount
        {
            get
            {
                return GstAmount + Amount;
            }
        }
    }
}