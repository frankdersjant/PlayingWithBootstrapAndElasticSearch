using Domain.DomainModels.Persons;
using ElasticsearchService;
using Nest;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PlayingWithBootstrap.Controllers
{
    public class ElasticController : Controller
    {
        private IElasticSearchService _searchservice { get; set; }
        private ElasticClient client { get; set; }

        private string defaultIndex;
        public string _defaultIndex
        {
            get { return "id"; }
            set { defaultIndex = value; }
        }

        public object Result { get; set; }

        public ElasticController(IElasticSearchService searchService)
        {
            _searchservice = searchService;
        }

        public ActionResult Index()
        {

            //client = _searchservice.CreateIndex("id");
            //var getresponse = client.Get<Person>(1, idx => idx.Index("id"));

            return View();
        }

        public async Task<ActionResult> EL()
        {

            //await SearchAsync();
            //await SearchByName("Dersjant");
            //await Matching("Yueming");

            return null;
        }

        public async Task<IEnumerable<Person>> SearchAsync()
        {
            client = _searchservice.CreateIndex("id");
            var result = await _searchservice.SearchAsync();
            return result;

        }

        public async Task<IEnumerable<Person>> SearchByName(string LN)
        {
            client = _searchservice.CreateIndex("id");
            var result = await _searchservice.SearchByName(LN);
            return result;
        }

        public async Task<IEnumerable<Person>> Matching(string match)
        {
            client = _searchservice.CreateIndex("id");
            var result = await _searchservice.Matching(match);
            return result;
        }

       

    }
}