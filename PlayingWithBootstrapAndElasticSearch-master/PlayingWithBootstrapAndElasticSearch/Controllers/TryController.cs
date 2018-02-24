using Domain.DomainModels.Persons;
using ElasticsearchService;
using Nest;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace PlayingWithBootstrap.Controllers
{
    public class TryController : ApiController
    {
        private IElasticSearchService _elasticsearch { get; set; }
        private ElasticClient client { get; set; }


        public TryController(IElasticSearchService elasticsearch)
        {
            _elasticsearch = elasticsearch;
            var client = _elasticsearch.CreateIndex("id");
        }

        [HttpGet]
        [Route("api/try/all")]
        public async Task<IEnumerable<Person>> Get()
        {
            var result = await _elasticsearch.SearchAsync();
            return result;
        }

        [HttpGet]
        [Route("api/try/person/{ln}")]
        public async Task<IEnumerable<Person>> GetPerson(string LN)
        {
            var result = await _elasticsearch.SearchByName(LN);
            return result;
        }

        [HttpGet]
        [Route("api/try/match/{match}")]
        public async Task<IEnumerable<Person>> GetMatching(string match)
        {
            var result = await _elasticsearch.Matching(match);
            return result;
        }
    }
}
