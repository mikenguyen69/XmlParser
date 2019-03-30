using System.Collections.Generic;
using XmlParser.Entities;

namespace Expense.Core.Interfaces
{
    public interface IExpenseDatabase
    {
        IList<T> Set<T>() where T : BaseEntity;
        void Save<T>(T entity) where T : BaseEntity;
    }
}
