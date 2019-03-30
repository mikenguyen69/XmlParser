using Expense.Core.Entities.Abstract;
using System;
using XmlParser.Entities;

namespace Expense.Core.Entities
{
    public class Expense : BaseEntity
    {
        public string Category { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public PaymentAmount PaymentAmount { get; set; }
        public DateTime Date { get; set; }

        public Expense(string category, string location, string description)
        {
            Category = category;
            Location = location;
            Description = description;
            Date = DateTime.Today;
        }
    }
}
