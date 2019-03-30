using System;
using System.Collections.Generic;
using System.Text;
using XmlParser.Entities;

namespace Expense.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IList<T> List();
        T Get(int id);
        void Add(T entity);
    }
}
