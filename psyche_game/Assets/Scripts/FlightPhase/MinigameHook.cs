using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameHook : MonoBehaviour
{
    public static Collider2D smack;

    void OnTriggerEnter2D(smack collision)
    {            
        string nextScene = collision.gameObject.name;
            Destroy(collision.gameObject);
            //var moveScript = FindObjectByType<FlightPhaseScript>();
            //moveScript.setHookPos();
            var script = FindObjectOfType<SceneSwitch>();
            script.playAltScene(nextScene);
      
    }
}
