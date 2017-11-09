
function loadAllTasks(){
    var request = new XMLHttpRequest
    request.onreadystatechange = function(){
        if(request.readyState == 4 && request.status == 200)
        addAllTasksToHTML(JSON.parse(request.responseText))
    }
    request.open("GET", "http://localhost:8080/Tasks", true)
    request.send(null)
}
function addAllTasksToHTML(tasks){
   tasks.forEach(addOneTaskToHTML)
}
function addOneTaskToHTML(task){
  var tasksList = document.getElementById('list')
  var newTask = document.createElement('li')
  newTask.appendChild(document.createTextNode(task.Name))
  tasksList.appendChild(newTask)
}    
function addNewTask(){
    var newTaskName = document.getElementById('text').value;
	addNewTaskOnServer(newTaskName)
}

function addNewTaskOnServer(taskName){
	var request = new XMLHttpRequest();
	request.onreadystatechange = function(){
		if (request.readyState == 4 && request.status == 200)
			addOneTaskToHTML({Name:taskName})
	}
	request.open("POST", "http://localhost:8080/Tasks", true); // true for asynchronous
	var newTask = {TaskName:taskName};
    request.send(JSON.stringify(newTask))
}