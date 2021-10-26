using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public float MovementSpeed = 1;

    public float x = 0;
    public float y = 0;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {



        x = Mathf.Cos(Time.time)*MovementSpeed;
        y = Mathf.Sin(Time.time)*MovementSpeed;

        transform.position = new Vector3(x, y, 0);


    }
}




