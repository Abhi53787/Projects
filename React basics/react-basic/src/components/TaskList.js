import TaskItem from "./TaskItem"
const TaskList=(props)=>{
    return(
    
        <ul>
{/* 
            <TaskItem mywish={props.taskData[0]} />
            <TaskItem mywish={props.taskData[1]} />
            <TaskItem mywish={props.taskData[2]} /> */}
            {props.taskData.map ((t)=>(
                      <TaskItem mywish={t} deleteFunction ={props.onDeleteTask}  key={Math.random()}/>     ))}
        </ul>
    )

}
export default TaskList;