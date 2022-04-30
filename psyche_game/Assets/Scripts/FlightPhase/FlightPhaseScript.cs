using UnityEngine;
using System.Collections;

    [RequireComponent(typeof(LineRenderer))]
public class FlightPhaseScript : MonoBehaviour
{
    public int vertexCount = 150;
    public float lineWidth = 0.2f;
    public static float radius;
    public GameObject theObject;
    public GameObject boosterLeft;
    public GameObject boosterRight;
    public GameObject capsule;
    public GameObject sceneSwitch;

    static float deltaTheta; 
    static float theta = 0f;
    int j = 0;

    static bool modelChosen = false;

    private void Awake() 
    {
        deltaTheta = (2f * Mathf.PI) / vertexCount;                
        InvokeRepeating("moveRocket", .5f, .1f);
        if (!modelChosen){
            Invoke("assembleRocket", 0.5f);
        }

    }

    private void assembleRocket() {
        var theObjectRenderer = theObject.GetComponent<SpriteRenderer>();
        var boosterLeftRenderer = boosterLeft.GetComponent<SpriteRenderer>();
        var boosterRightRenderer = boosterRight.GetComponent<SpriteRenderer>();
        var capsuleRenderer = capsule.GetComponent<SpriteRenderer>();
        var spriteArraySelector = theObject.GetComponent<SceneSwitch>();

//        Debug.Log(SpritesScript.getSprite(spriteArraySelector.getBody()));
//        Debug.Log(SpritesScript.getSprite(spriteArraySelector.getBooster()));
//        Debug.Log(SpritesScript.getSprite(spriteArraySelector.getCapsule()));

        theObjectRenderer.sprite = SpritesScript.getSprite(spriteArraySelector.getBody());
        boosterLeftRenderer.sprite = SpritesScript.getSprite(spriteArraySelector.getBooster());
        boosterRightRenderer.sprite = SpritesScript.getSprite(spriteArraySelector.getBooster());
        capsuleRenderer.sprite = SpritesScript.getSprite(spriteArraySelector.getCapsule());
        modelChosen = true;
    }
    
    private void moveRocket()
    {         
            radius = j * 5;
            theObject.transform.position = new Vector3((radius / vertexCount) * Mathf.Cos(theta * 3), (radius / vertexCount) * Mathf.Sin(theta * 3), 0f);
            theta += deltaTheta;
        j++;
    }     
}