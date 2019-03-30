using Expense.Core.Entities;
using Expense.Core.Interfaces;
using System.Collections;
using System.Collections.Generic;
using XmlParser.Entities;

namespace Expense.Core.Repositories
{
    public class ExpenseDatabase : IExpenseDatabase
    {
        private static Hashtable dataStore = new Hashtable();

        public ExpenseDatabase()
        {
            dataStore[typeof(Entities.Expense)] = new List<Entities.Expense>();
            dataStore[typeof(SystemValue)] = new List<SystemValue>()
            {
                new SystemValue("NZ_GST", 0.15),
            };
            
        }
        public IList<T> Set<T>() where T : BaseEntity
        {
            return (IList<T>)dataStore[typeof(T)];
        }

        public void Save<T>(T entity) where T : BaseEntity
        {
            var currentSet = Set<T>();

            currentSet.Add(entity);

            dataStore[typeof(T)] = currentSet;
        }
    }
}
