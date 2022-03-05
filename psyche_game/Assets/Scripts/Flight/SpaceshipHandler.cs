using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipHandler : MonoBehaviour
{
    public float MovementSpeed = 10;
    public GameObject psycheAsteroid;
    public int ZRotationAngle = 70;


    void Start()
    {

    }

    void Update()
    {
        if (psycheAsteroid != null)
        {
            Vector3 direction = psycheAsteroid.transform.position - transform.position;
            direction = Quaternion.Euler(0, 0, ZRotationAngle) * direction;
            float distancePerFrame = MovementSpeed * Time.deltaTime;
            transform.Translate(direction.normalized * distancePerFrame, Space.World);
        }

    }
}
