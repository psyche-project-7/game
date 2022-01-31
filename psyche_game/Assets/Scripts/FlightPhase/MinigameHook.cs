using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameHook : MonoBehaviour
{
    public int miniGameNumber = 1;
    public GameObject collider;
    
    void OnTriggerEnter2D(Collider2D collision)
    {            
        string nextScene = collision.gameObject.name;
        Destroy(collision.gameObject);
        var script = FindObjectOfType<SceneSwitch>();
        // add static int array to scenechanger and destroy colliders/start pathing based on location
        //var moveScript = FindObjectByType<FlightPhaseScript>();
        //moveScript.setHookPos();
         if (script.checkPlayed(miniGameNumber))
        {
            return;
        } else
        {
            script.addMiniGame(miniGameNumber);
            //script.playAltScene(nextScene);
        }

      
    }
}
