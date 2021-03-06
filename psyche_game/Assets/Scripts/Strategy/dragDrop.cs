using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragDrop : MonoBehaviour
{
    public string partType;
    public Sprite theSprite;

    private Vector3 _dragOffset;
    private Camera _cam;

    public int timeCost;
    public GameObject[] snapPoints;
    private float snapSensitivity = .75f;
    private Vector3 initialPosition;
    private bool snapped;
    private int totalSnapped;

    private bool fadeOutPart;
    private float fadeSpeed;
   


    public delegate void PartChanged(int timeChange);
    public static event PartChanged OnPartChanged;

    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    public Transform target;
    Vector3 targetPosition;
    private Vector3 initialTakeOffPosition;

    void Start()
    {
        initialTakeOffPosition = transform.position;
        targetPosition = target.TransformPoint(new Vector3(0f, 30.0f, 0f));
    }

    private void Awake()
    {
        _cam = Camera.main;
        initialPosition = transform.position;
        snapped = false;
        fadeOutPart = false;
        totalSnapped = 0;
        fadeSpeed = 1f;
    }

    void OnEnable()
    {
        LaunchButton.OnRocketLaunchRequest += beginRocketLaunchSequence;
    }

    void OnDisable()
    {
        LaunchButton.OnRocketLaunchRequest -= beginRocketLaunchSequence;
    }

    private void Update()
    {
        if (snapped && fadeOutPart)
        {
            Invoke("flyUp", 2f);
        }
    }

    public void flyUp()
    {
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    private void beginRocketLaunchSequence()
    {
        fadeOutPart = true;
    }

    private void OnMouseDown()
    {
        _dragOffset = transform.position - getMousePos();
    }
    private void OnMouseDrag()
    {
        transform.position = getMousePos() + _dragOffset;
        for (int i = 0; i < snapPoints.Length; i++)
        {
            if (Vector3.Distance(snapPoints[i].transform.position, transform.position) < snapSensitivity)
            {
                transform.position = new Vector3(snapPoints[i].transform.position.x, snapPoints[i].transform.position.y, snapPoints[i].transform.position.z - 0.1f);
            }
        }
    }

    private void OnMouseUp()
    {
        DropPart();
    }

    Vector3 getMousePos()
    {
        var mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }

    void DropPart()
    {
        bool alreadySnapped = snapped;


        for(int i = 0; i < snapPoints.Length; i++)
        {
            //only allow the part to snap in if its both within the drop zone and it wouldn't exceed the allowed time
            if ((Vector3.Distance(snapPoints[i].transform.position, transform.position) < snapSensitivity) && !partWouldExceedAlottedTime(timeCost))
            {

                transform.position = new Vector3(snapPoints[i].transform.position.x, snapPoints[i].transform.position.y, snapPoints[i].transform.position.z - 0.1f);
                snapped = true;
                totalSnapped += 1;
                SceneSwitch.setPart(partType, theSprite.name);
                if (OnPartChanged != null)
                {
                    OnPartChanged(timeCost);
                    SceneSwitch.setPart(partType, theSprite.name);
                }
            } else
            {
                snapped = false; 
            }

        }
        if (snapped == false)
        {
            transform.position = initialPosition;
            //handle part removed (it was snapped but now its not)
            if (alreadySnapped)
            {
                totalSnapped -= 1;
                if (OnPartChanged != null )
                {
                    OnPartChanged(-1 * timeCost);
                }
            }
            
            
        }
    }

    bool partWouldExceedAlottedTime(int timeCost)
    {
        // timeCost is expected to be a negative integer
        float timeIfPartWasAdded = timeDialScript.currentTime + timeCost;
        return timeIfPartWasAdded < 0f;
    }

}
