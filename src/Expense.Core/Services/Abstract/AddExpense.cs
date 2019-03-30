using Expense.Core.Entities.Abstract;
using Expense.Core.Interfaces;

namespace Expense.Core.Services.Abstract
{
    public abstract class AddExpense : IAddExpense
    {
        protected string category;
        protected string location;
        protected string description;
        protected string amount;

        protected IRepository<Entities.Expense> _expenseRepository;
        
        public AddExpense(IRepository<Entities.Expense> expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        protected abstract PaymentAmount MakePaymentAmount();
        protected abstract PaymentMethod MakePaymentMethod(string amount);

        public void Execute()
        {
            var paymentAmount = MakePaymentAmount();
            var paymentMethod = MakePaymentMethod(amount);

            var expense = new Entities.Expense(category, location, description)
            {
                PaymentAmount = paymentAmount,
                PaymentMethod = paymentMethod
            };

            _expenseRepository.Add(expense);
        }

        public void Load(string category, string location, string description, string amount)
        {
            this.category = category;
            this.location = location;
            this.description = description;
            this.amount = amount;
        }
    }
}
