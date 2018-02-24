using Nest;
using System;
using System.Diagnostics;
using System.Text;

namespace ElasticsearchService
{
    public class ElasticsearchClient
    {
        private string index { get; set; }
        private ElasticClient client { get; set; }

        public ElasticClient CreateElasticClient(string setDefaultIndex)
        {
            const string ESServer = "http://localhost:9200";
            index = setDefaultIndex;
            ConnectionSettings connectionSettings = new ConnectionSettings(new Uri(ESServer));

            // connectionSettings.DefaultIndex(setDefaultIndex);

            connectionSettings.DisableDirectStreaming()
                .OnRequestCompleted(details =>
                {
                    Debug.WriteLine(details.HttpMethod + " " + details.Uri);
                    Debug.WriteLine("### REQEUST ###");
                    if (details.RequestBodyInBytes != null)
                        Debug.WriteLine(Encoding.UTF8.GetString(details.RequestBodyInBytes));
                    Debug.WriteLine("### RESPONSE ###");
                    if (details.ResponseBodyInBytes != null)
                        Debug.WriteLine(Encoding.UTF8.GetString(details.ResponseBodyInBytes));
                })
                .PrettyJson();
            return new ElasticClient(connectionSettings);
        }
    }
}
