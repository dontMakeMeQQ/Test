using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace SelfHostBackend
{
	class Program
	{
		static void Main(string[] args)
		{
			var taskServiceInstance = new TasksService();
			var baseAddress = new Uri("http://localhost:8080/");
			using (var host = new ServiceHost(taskServiceInstance, baseAddress))
			{
				// Enable metadata publishing.
				var smb = new ServiceMetadataBehavior();
				smb.HttpGetEnabled = true;
				smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
				host.Description.Behaviors.Add(smb);

				var webBehaviour = new WebHttpBehavior();
				

				var endpoint = host.AddServiceEndpoint(typeof(IRestService<ToDoTask>), new WebHttpBinding(), "Tasks");
				endpoint.EndpointBehaviors.Add(webBehaviour);

				// Open the ServiceHost to start listening for messages. Since
				// no endpoints are explicitly configured, the runtime will create
				// one endpoint per base address for each service contract implemented
				// by the service.
				host.Open();

				Console.WriteLine("The service is ready at {0}", baseAddress);
				Console.WriteLine("Press <Enter> to stop the service.");
				Console.ReadLine();

				// Close the ServiceHost.
				host.Close();
			}
		}
	}
}
