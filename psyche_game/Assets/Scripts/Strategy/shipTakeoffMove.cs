using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipTakeoffMove : MonoBehaviour
{
    public GameObject spaceShip;
    private Vector3 initialPosition;
    private bool pressed = false;


    public Transform target;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;


    Vector3 targetPosition;

    void Start()
    {
        initialPosition = transform.position;
        targetPosition = target.TransformPoint(new Vector3(0f, 20.0f, 0f));
    }


    void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            pressed = !pressed;

        }
        if (pressed)
        {
            Invoke("flyUp", 2);
        }
        
    }

    public void flyUp()
    {        
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
