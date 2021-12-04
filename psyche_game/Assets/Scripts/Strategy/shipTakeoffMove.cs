using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipTakeoffMove : MonoBehaviour
{
    private Vector3 initialPosition;

    public Transform target;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    private bool launch = false;


    Vector3 targetPosition;

    void Start()
    {
        initialPosition = transform.position;
        targetPosition = target.TransformPoint(new Vector3(0f, 30.0f, 0f));
    }

    void OnEnable()
    {
        LaunchButton.OnRocketLaunchRequest += handleLaunchRequest;
    }

    void OnDisable()
    {
        LaunchButton.OnRocketLaunchRequest -= handleLaunchRequest;
    }

    void Update()
    {
        flyUp();
    }

    public void handleLaunchRequest()
    {
        Invoke("enableFly", 2f);
        Invoke("requestNextScene", 5f);
    }

    public void enableFly()
    {
        launch = true;
    }

    public void flyUp()
    {
        if (launch)
        {
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }

    }

    public void requestNextScene()
    {
        SceneSwitch.playAltScene("FlightPath");
    }
}

