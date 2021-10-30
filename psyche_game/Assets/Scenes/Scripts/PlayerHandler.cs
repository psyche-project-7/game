using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public float MovementSpeed = 1;
    public GameObject psycheAsteroid;

    public float x = 0;
    public float y = 0;

    private Vector3 savedPosition;

    void Start()
    {
        savedPosition = psycheAsteroid.transform.position;
        Debug.Log("savedPosition is " + savedPosition);
    }

    void Update()
    {
        if (psycheAsteroid != null)
        {
            Vector3 direction = psycheAsteroid.transform.position - transform.position;
            direction = Quaternion.Euler(0, 0, 60) * direction;
            float distanceThisFrame = MovementSpeed * Time.deltaTime;
            transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        }
        
    }
}




