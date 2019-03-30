using System;
using System.Collections.Generic;
using System.Text;

namespace Expense.Core.Interfaces
{
    public interface IAddExpense : IProcess
    {
        void Load(string category, string location, string description, string amount);
    }
}
