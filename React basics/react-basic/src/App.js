import logo from './logo.svg';
import './App.css';
import AddTask from './components/AddTask';
import TaskList from './components/TaskList';
import { useState } from 'react';
const TASK_ARRAY = ["ReactJs","NodeJs","Java"];
function App() {

  const [taskArray, setTaskArray]=useState(TASK_ARRAY);
 
  //callback func, now parent class(app.js) sends the function() to child class(AddTask) so child class now sends the info that is collected and sends to parent class through the function .
  const addDataToTask = (Task) => {
    console.log(Task,"from app");
    setTaskArray([...taskArray,Task]);
    console.log(taskArray);
  }
  const removeTask= (Task)=>{
    const newTask=taskArray.filter(a => a!==Task); //filter is used to remove the element from the array 
    setTaskArray(newTask);

  }
  return (
    <div className="App">


      <AddTask data={taskArray} getData = {addDataToTask}/>
      <TaskList taskData ={taskArray} onDeleteTask={removeTask} />
    </div>
  );
}
 
export default App;

//communication chain is addtask -> app.js ; app.js -> TaskList ; TaskList -> TaskItem
