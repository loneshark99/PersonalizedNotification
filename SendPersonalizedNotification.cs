using System.Collections.Generic;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace PersonalizedNotification
{
    public static class SendPersonalizedNotification
    {
        [FunctionName("SendPersonalizedNotification")]
        public static void Run([CosmosDBTrigger(
            databaseName: "Notifications",
            collectionName: "Items",
            ConnectionStringSetting = "DBConnectionString",
            LeaseCollectionName = "leases")]IReadOnlyList<Document> input, ILogger log)
        {
            if (input != null && input.Count > 0)
            {
                log.LogInformation("Documents modified " + input.Count);
                log.LogInformation("First document Id " + input[0].Id);
            }
        }
    }
}
