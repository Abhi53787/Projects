import { useState } from "react";

const AddTask=(props)=>{ 
    //hooks 
    const[Task , setTask] =useState('');
    
    const handleButtonClick=(e)=>{
        e.preventDefault(); //prevent page refresh
        if(Task.trim()){ //trim used to prevent empty spaces 
            
        props.getData(Task)
        setTask('');
        }
        
        
    }
    const handleInputChange=(e)=>{
        console.log(e.target.value);
        setTask(e.target.value);
    }
    return(
       
            <form>
                <input type="text" 
                placeholder="Enter Task"
                onChange={handleInputChange}
                value={Task}
                />
                
                <button onClick={handleButtonClick}> Add Task </button>
            
            </form>
         
    )
}
export default AddTask;

