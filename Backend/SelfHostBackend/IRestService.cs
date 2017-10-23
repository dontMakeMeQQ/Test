using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace SelfHostBackend
{
	[ServiceContract]
	public interface IRestService<out T>
	{
		[OperationContract(Name = "GetAll")]
		[WebInvoke(Method ="GET",
			ResponseFormat =WebMessageFormat.Json
			, UriTemplate ="")]
		T[] Get();

		[OperationContract(Name ="GetOne")]
		[WebInvoke(Method = "GET",
			ResponseFormat = WebMessageFormat.Json
			, UriTemplate = "/{id}")]
		T Get(string id);

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
			UriTemplate ="")]
		int Post(Stream requestBody);

		[OperationContract]
		[WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json,
			UriTemplate = "")]
		void Put(Stream requestBody);

		[OperationContract]
		[WebInvoke(Method = "DELETE", RequestFormat = WebMessageFormat.Json,
			UriTemplate ="")]
		void Delete(Stream requestBody);
	}
}
