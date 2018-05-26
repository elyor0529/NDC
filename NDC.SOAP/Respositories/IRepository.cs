using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using NDC.SOAP.Models;

namespace NDC.SOAP.Respositories
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRepository : IDisposable
    {
        /// <summary>
        /// find by creteria
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<Person> FindBy(Expression<Func<Person, bool>> predicate);
    }
}