using Expense.Core.Interfaces;
using System.Collections.Generic;
using XmlParser.Entities;
using System.Linq;

namespace Expense.Core.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private IExpenseDatabase _database;

        public Repository(IExpenseDatabase database)
        {
            _database = database;
        }

        public void Add(T entity)
        {
            _database.Save(entity);
        }

        public T Get(int id)
        {
            return _database.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public IList<T> List()
        {
            return _database.Set<T>();
        }
    }
}
