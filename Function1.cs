using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using System.Net.Http.Formatting;

namespace SelvaFuncTimerTrigger
{
    public static class SelvaTimerFunction
    {        

        [FunctionName("SelvaTimerFunction")]
        public static async Task Run(TimerInfo myTimer, ILogger log)
        {

            log.LogInformation($"C# Selva Timer triggered function executed at: {DateTime.Now}");

            var client = new HttpClient();
            var resp = await client.GetAsync("https://selvafunctionapps.azurewebsites.net/api/RestApiCall?name=selva");

            var content = await resp.Content.ReadAsStringAsync();
            log.LogInformation($"Response returned from the API => " + content);

        }

    }
}
