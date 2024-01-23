using Serilog.Formatting.Json;
using Serilog.Sinks.Elasticsearch;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Core.Extension
{
    public class LoggingConfig
    {
        public static void ConfigureLogging()
        {
            Log.Logger = new LoggerConfiguration()
                            .Enrich.FromLogContext()
                            .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
                            {
                                IndexFormat="Resource-Text",
                                BatchAction = ElasticOpType.Create,
                                AutoRegisterTemplate = true,
                                MinimumLogEventLevel = Serilog.Events.LogEventLevel.Error,
                            })
                            .CreateLogger();
        }
    }
}
