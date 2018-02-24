
using DataLayer;
using Domain.DomainModels.Persons;
using Nest;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElasticsearchService
{
    public class ElasticSearchService : IElasticSearchService
    {
        private NotificationContext _context { get; set; }
        private ElasticClient client { get; set; }
        private ElasticsearchClient ESclient { get; set; }
        private string index { get; set; }

        public ElasticSearchService(NotificationContext context)
        {
            _context = context;
        }

        public ElasticClient CreateIndex(string id)
        {
            ElasticsearchClient ESclient = new ElasticsearchClient();

            client = ESclient.CreateElasticClient(id);

            if (client.IndexExists(id).Exists) client.DeleteIndex("id");

            if (client != null)
            {
                if (!client.IndexExists(id).Exists)
                {
                    foreach (Person person in _context.Persons)
                    {
                        var response = client.Index(person, idx => idx.Index("id"));
                    }
                }
            }

            return client;
        }

        public async Task<IEnumerable<Person>> SearchAsync()
        {
            var response = await client.SearchAsync<Person>(s => s.Type("person"));
            return response.Documents;
        }

        public async Task<IEnumerable<Person>> SearchByName(string LN)
        {
            var response = await client.SearchAsync<Person>(s => s.Type("person").Query(q => q.QueryString(qs =>
                           qs.Fields(f => f.Field(fi => fi.LastName))
                               .Query(LN))));

            return response.Documents;
        }

        public async Task<IEnumerable<Person>> Matching(string firstname)
        {
            var response = await client.SearchAsync<Person>(s => s.Type("person").
                               Query(q => q.MatchPhrase(a => a.Field(d => d.FirstName)
                               .Query(firstname))));
            return response.Documents;
        }

        //public async Task<IEnumerable<Person>> Fuzzy(string fuzzy)
        //{
        //    //var response = await client.SearchAsync<Person>(s => s.
        //    //                        Query(q => q.Match(m => m
        //    //                       .Query(fuzzy)
        //    //                       .Field(f => f.LastName)
        //    //                       .Fuzziness(Fuzziness.EditDistance(1))
        //    //                       .PrefixLength(1))));
        //    //return response.Documents.ToList();
        //}
    }

}

