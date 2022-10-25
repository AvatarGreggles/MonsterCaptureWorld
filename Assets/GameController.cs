using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState { FreeRoam, Phone }
public class GameController : MonoBehaviour
{
    [SerializeField] GameObject phoneUI;

    GameState state;

    public GameState State { get { return state; } }

    PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        
    }

    void Update()
    {
        if(state == GameState.FreeRoam)
        {
            // Handle Open Phone
            if (Input.GetKeyDown(KeyCode.P))
            {
                OpenPhone();
            }

            // Handle Player Movement
            player.HandleUpdate();
        }
        else if(state == GameState.Phone)
        {
            // Handle Close Phone
            if (Input.GetKeyDown(KeyCode.P))
            {
               ClosePhone();
            }
        }  
    }

    public void OpenPhone()
    {
        phoneUI.SetActive(true);
        state = GameState.Phone;
    }

    public void ClosePhone()
    {
        phoneUI.SetActive(false);
        state = GameState.FreeRoam;
    }
}
