using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public float MovementSpeed = 1;
    public GameObject psycheAsteroid;

    void Start()
    {

    }

    void Update()
    {
        if (psycheAsteroid != null)
        {
            Vector3 direction = psycheAsteroid.transform.position - transform.position;
            direction = Quaternion.Euler(0, 0, 60) * direction;
            float distancePerFrame = MovementSpeed * Time.deltaTime;
            transform.Translate(direction.normalized * distancePerFrame, Space.World);
        }
        
    }
}




