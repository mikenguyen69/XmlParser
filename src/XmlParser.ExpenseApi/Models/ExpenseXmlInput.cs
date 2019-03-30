using System;
using System.Xml.Serialization;

namespace XmlParser.ExpenseApi.Models
{
    [XmlRoot]
    public class ExpenseInput : ExpenseEntry
    {
        public DateTime Expense_Date
        {
            get { return ExpenseDate; }
            set { ExpenseDate = value; }
        }

        public string Payment_Method
        {
            get { return PaymentMethod; }
            set { PaymentMethod = value; }
        }
    }
}