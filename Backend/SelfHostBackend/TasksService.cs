using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;

namespace SelfHostBackend
{
	[ServiceBehavior(InstanceContextMode =InstanceContextMode.Single)]
	public class TasksService : IRestService<ToDoTask>
	{
		private int _lastNewCreatedTaskId = 0;
		private List<ToDoTask> _tasks = new List<ToDoTask>();

		public ToDoTask[] Get()
		{
			return _tasks.ToArray();
		}

		public ToDoTask Get(string id)
		{
			return _tasks.First(x => x.Id == int.Parse(id));
		}

		public int Post(Stream requestBody)
		{
			var newTask = Deserialize<CreatingTask>(requestBody);
			_tasks.Add(new ToDoTask { Id = ++_lastNewCreatedTaskId, Name = newTask.TaskName });
			return _lastNewCreatedTaskId;
		}

		public void Put(Stream requestBody)
		{
			var editTask = Deserialize<EditTask>(requestBody);
			_tasks.First(x => x.Id == editTask.Id).Name = editTask.TaskName;
		}

		public void Delete(Stream requestBody)
		{
			var deleteTask = Deserialize<DeleteTask>(requestBody);
			_tasks.RemoveAll(x => x.Id == deleteTask.Id);
		}

		private static T Deserialize<T>(Stream requestBody)
		{
			T requestObject;
			using (var reader = new StreamReader(requestBody))
			{
				requestObject = JsonConvert.DeserializeObject<T>(reader.ReadToEnd());
			}

			return requestObject;
		}
	}
}
