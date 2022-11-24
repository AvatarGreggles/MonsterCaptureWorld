using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    [SerializeField] GameObject taskObj;
    [SerializeField] List<TaskBase> tasks;

    // Start is called before the first frame update
    void Start()
    {
        RenderTasks(); 
    }

    void RenderTasks(){
        float yPos = 0;

        foreach (TaskBase task in tasks)
        {
            GameObject newTask = Instantiate(taskObj, transform);
            newTask.GetComponent<TaskObject>().SetTask(task);
            newTask.transform.localPosition = new Vector3(0, yPos, 0);
            yPos -= 150;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddTask(TaskBase task)
    {
        tasks.Add(task);
    }

    public void RemoveTask(TaskBase task)
    {
        tasks.Remove(task);
    }
}
