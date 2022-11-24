using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskBase : ScriptableObject
{
    [SerializeField] string name;
    [SerializeField] string npcName;
    [SerializeField] Sprite npcImage;

    public string Name { get { return name; } set { name = value; } }
    public string NPCName { get { return npcName; } set { npcName = value; } }
    public Sprite NPCImage { get { return npcImage; } set { npcImage = value; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
