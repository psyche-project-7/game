using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameHook : MonoBehaviour
{ 

    void OnTriggerEnter2D(Collider2D collision)
    {            
        string nextScene = collision.gameObject.name;
            Destroy(collision.gameObject);
            //var moveScript = FindObjectByType<FlightPhaseScript>();
            //moveScript.setHookPos();
            var script = FindObjectOfType<SceneSwitch>();
            //script.playAltScene(nextScene);
      
    }
}
