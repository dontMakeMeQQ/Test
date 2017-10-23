using System.Runtime.Serialization;

namespace SelfHostBackend
{
	[DataContract]
	public class ToDoTask
	{
		[DataMember]
		public int Id { get; set; }
		[DataMember]
		public string Name { get; set; }
	}
}
