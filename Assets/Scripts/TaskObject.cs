using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskObject : MonoBehaviour
{
    [SerializeField] TMP_Text taskName;
    [SerializeField] TMP_Text taskNPCName;
    [SerializeField] Image taskNPCImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTask(TaskBase task)
    {
        taskName.text = task.Name;
        taskNPCName.text = task.NPCName;
        taskNPCImage.sprite = task.NPCImage;
    }
}
