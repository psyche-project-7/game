using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameHook : MonoBehaviour
{
    public int miniGameNumber = 1;
    public GameObject collider;
    
    void OnTriggerEnter2D(Collider2D collision)    
    {         
        var script = collider.GetComponent<SceneSwitch>();

        if (script.checkPlayed(miniGameNumber))
        {
            return;
        } else
        {
            script.addMiniGame(miniGameNumber);
            SceneSwitch.playAltScene(collider.name);
        }

      
    }
}
