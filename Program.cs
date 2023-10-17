using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;
using System;
using System.Threading.Tasks;

namespace equipo04
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Uri orgUrl = new Uri("https://dev.azure.com/equipo04");
            string personalAccessToken = "2a334hmunrokbqlqv36o7mvevpkd3qrnaomzl657f5fjvrm6xluq";
            int workItemId = 2;

            VssConnection connection = new VssConnection(orgUrl, new VssBasicCredential(string.Empty, personalAccessToken));

            await ShowWorkItemDetails(connection, workItemId);
        }

        static async Task ShowWorkItemDetails(VssConnection connection, int workItemId)
        {
            WorkItemTrackingHttpClient witClient = connection.GetClient<WorkItemTrackingHttpClient>();

            try
            {
                WorkItem workitem = await witClient.GetWorkItemAsync(workItemId);

                Console.WriteLine($"Work Item ID: {workitem.Id}");
                Console.WriteLine($"Work Item Type: {workitem.Fields["System.WorkItemType"]}");
                Console.WriteLine($"Title: {workitem.Fields["System.Title"]}");
                Console.WriteLine($"State: {workitem.Fields["System.State"]}");
                Console.WriteLine($"Assigned To: {workitem.Fields["System.AssignedTo"]}");
                Console.WriteLine($"Description: {workitem.Fields["System.Description"]}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
