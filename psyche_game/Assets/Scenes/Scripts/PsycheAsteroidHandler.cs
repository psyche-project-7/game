using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsycheAsteroidHandler : MonoBehaviour
{
    public float MovementSpeed = 10;

    void Start()
    {
        
    }

    void Update()
    {
        var movementHorizontal = Input.GetAxis("Horizontal");
        var movementVertical = Input.GetAxis("Vertical");
        transform.position += new Vector3(movementHorizontal, movementVertical, 0) * Time.deltaTime * MovementSpeed;
    }
}
