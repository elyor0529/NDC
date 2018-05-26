using System;
using System.Linq;
using System.Threading.Tasks;
using DevTrends.WCFDataAnnotations;
using NDC.Common.ViewModels;
using NDC.SOAP.Respositories;
using NDC.SOAP.Services;

namespace NDC.SOAP
{
    [ValidateDataAnnotationsBehavior]
    public class PersonService : IPersonService
    {
        private readonly IRepository _repository;
        private readonly IService _service;

        public PersonService(IRepository repository, IService service)
        {
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));

            if (service == null)
                throw new ArgumentNullException(nameof(service));

            _repository = repository;
            _service = service;

        }

        /// <summary>
        ///     search by person creterias:names,gender,country,age,heigth and weight
        /// </summary>
        /// <param name="email"></param>
        /// <param name="model">result count</param>
        /// <returns></returns>
        public int Search(string email, SearchModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            //names,gender and country
            var query = _repository.FindBy(w => w.FullName.Contains(model.Names) || w.Gender == model.Gender || w.Country.Contains(model.Nationality));

            //age
            if (model.MinAge <= model.MaxAge)
                query = query.Where(w => DateTime.Now.Year - w.BirthDate.Year >= model.MinAge && DateTime.Now.Year - w.BirthDate.Year <= model.MaxAge);
            else
                throw new ArgumentException("Min Age <= Max Age");

            //heigth
            if (model.MinHeigth <= model.MaxHeigth)
                query = query.Where(w => w.Height >= model.MinAge && w.Height <= model.MaxHeigth);
            else
                throw new ArgumentException("Min Height <= Max Height");

            //weight
            if (model.MinWeight <= model.MaxWeight)
                query = query.Where(w => w.Weight >= model.MinWeight && w.Weight <= model.MaxWeight);
            else
                throw new ArgumentException("Min Weight <= Max Weight");

            if (query == null || !query.Any())
                throw new NullReferenceException("Not found result(s)");

            _service.BatchSend(email, query);

            return query.Count();
        }
    }
}