using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeDialScript : MonoBehaviour
{

    private const float MAX_TIME_ANGLE = -45;
    private const float ZERO_TIME_ANGLE = 220;

    private Transform needleTranform;

    private float timeMax;
    private float currentTime;

    private void Awake()
    {
        needleTranform = transform.Find("needle");

        currentTime = 0f;
        timeMax = 120f; //arbitrarily selected

    }

    private void Update()
    {
        HandleInput();

        needleTranform.eulerAngles = new Vector3(0, 0, TranslateTimeUnitsToRotation());
    }

    private void HandleInput()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            currentTime += 25f * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            currentTime -= 25f * Time.deltaTime;
        }

        currentTime = Mathf.Clamp(currentTime, 0f, timeMax);
    }


    private float TranslateTimeUnitsToRotation()
    {
        float totalAngleSize = ZERO_TIME_ANGLE - MAX_TIME_ANGLE;

        float timeNormalized = currentTime / timeMax;

        return ZERO_TIME_ANGLE - timeNormalized * totalAngleSize;
    }
}
