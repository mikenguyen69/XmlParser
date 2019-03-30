using Expense.Core.Entities;
using Expense.Core.Entities.Abstract;
using Expense.Core.Interfaces;
using Expense.Core.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Expense.Core.Services
{
    public class AddCashExpense : AddExpense
    {
        public AddCashExpense(IRepository<Entities.Expense> expenseRepository) : 
            base(expenseRepository)
        {
        }

        protected override PaymentAmount MakePaymentAmount()
        {
            throw new NotImplementedException();
        }

        protected override PaymentMethod MakePaymentMethod(string amount)
        {
            throw new NotImplementedException();
        }
    }
}
