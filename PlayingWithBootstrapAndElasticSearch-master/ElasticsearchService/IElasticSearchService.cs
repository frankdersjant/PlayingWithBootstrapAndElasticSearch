
using Domain.DomainModels.Persons;
using Nest;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ElasticsearchService
{
    public interface IElasticSearchService
    {
        ElasticClient CreateIndex(string index);
        Task<IEnumerable<Person>> SearchAsync();
        Task<IEnumerable<Person>> SearchByName(string LN);
        Task<IEnumerable<Person>> Matching(string firstname);

        //TODO implement - can be tricky
        //Task<IEnumerable<Person>> Fuzzy(string fuzzy);

    }
}
