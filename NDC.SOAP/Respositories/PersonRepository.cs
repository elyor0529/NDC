using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NDC.SOAP.Models;

namespace NDC.SOAP.Respositories
{
    public class PersonRepository : IRepository
    {
        private readonly NDCDbContext _context;

        public PersonRepository(NDCDbContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
        }

        public IEnumerable<Person> FindBy(Expression<Func<Person, bool>> predicate)
        {
            return _context.People.Where(predicate).AsEnumerable();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}