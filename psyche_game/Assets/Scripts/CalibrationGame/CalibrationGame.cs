using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrationGame : MonoBehaviour
{

    private LineRenderer _lineRender;
    // Start is called before the first frame update
    float x_value;
    int state;
    void Start()
    {
        _lineRender = GetComponent<LineRenderer>();
        state = 0;
        x_value = 0.0f;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            state = 2;
        }

        _lineRender.SetPosition(0, new Vector3(x_value, 10, 0));
        if (state == 0)
        {
            if (x_value < 15)
            {
                x_value += .01f;
            }
            else
            {
                state = 1;
            }

        }
        else if (state == 1)
        {
            if (x_value > -15)
            {
                x_value -= .01f;
            }
            else
            {
                state = 0;
            }
        }
    }
}
