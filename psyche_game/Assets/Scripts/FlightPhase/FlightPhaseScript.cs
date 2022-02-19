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

    private LineRenderer renderer;
    static float deltaTheta; 
    static float theta = 0f;
    int j = 0;

    private void Awake() 
    {
        var theObjectRenderer = theObject.GetComponent<SpriteRenderer>();
        var boosterLeftRenderer = boosterLeft.GetComponent<SpriteRenderer>();
        var boosterRightRenderer = boosterRight.GetComponent<SpriteRenderer>();
        var capsuleRenderer = capsule.GetComponent<SpriteRenderer>();
        var spriteArraySelector = theObject.GetComponent<SceneSwitch>();
        var spriteArray = theObject.GetComponent<Sprites>();

        theObjectRenderer.sprite = spriteArray.getSprite(spriteArraySelector.getBody());
        boosterLeftRenderer.sprite = spriteArray.getSprite(spriteArraySelector.getBooster());
        boosterRightRenderer.sprite = spriteArray.getSprite(spriteArraySelector.getBooster());
        capsuleRenderer.sprite = spriteArray.getSprite(spriteArraySelector.getCapsule());



        deltaTheta = (2f * Mathf.PI) / vertexCount;
        renderer = GetComponent<LineRenderer>();
        makeCircle();
        InvokeRepeating("moveRocket", .5f, .1f);
    }
    
    private void moveRocket()
    {         
            radius = j * 5;
            theObject.transform.position = new Vector3((radius / vertexCount) * Mathf.Cos(theta * 3), (radius / vertexCount) * Mathf.Sin(theta * 3), 0f);
            theta += deltaTheta;
        j++;
    }

    private void makeCircle()
    {
        renderer.widthMultiplier = lineWidth;
        float deltasTheta = (2f * Mathf.PI) / vertexCount;
        float thetas = 0f;        
        renderer.positionCount = vertexCount;        
        var points = new Vector3[vertexCount + 1];
        for (int i = 0; i < vertexCount + 1; i++)
        {
            radius = i*5;             
            points[i] = new Vector3((radius/vertexCount) * Mathf.Cos(thetas*3), (radius/vertexCount) * Mathf.Sin(thetas*3), 0f);
            
            thetas += deltasTheta;
        }
        renderer.SetPositions(points);
    }    
}