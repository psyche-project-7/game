using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PartSelectScript : MonoBehaviour
{
    public GameObject sprite;
    public GameObject toRemove;
    
    public void OnButtonPress()
    {
        if (toRemove != null)
        {
            // Set object to proper position
            sprite.transform.position = (Vector2) toRemove.transform.position;

            // Destroy the gameObject after clicking on it
            Destroy(toRemove.gameObject);
        }
        
    }
}
