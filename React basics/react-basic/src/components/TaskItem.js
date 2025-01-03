
const TaskItem=(props) => {
// const deleteTask=(tastoDelete)=>{
//     props.deleteFunction(tastoDelete)
// }
    return (
        <li>
            <h1>{props.mywish}</h1>
            <button onClick={e=>props.deleteFunction(props.mywish)}>  delete</button>
        </li>
    )
}

export default TaskItem;