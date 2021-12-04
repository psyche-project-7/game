using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeDialScript : MonoBehaviour
{

    private const float MAX_TIME_ANGLE = -45;
    private const float ZERO_TIME_ANGLE = 220;

    private Transform needleTranform;

    public float timeMax;
    public static float currentTime;



    private void Awake()
    {
        needleTranform = transform.Find("needle");

        currentTime = 120f;
        timeMax = 120f; //arbitrarily selected

    }

    void OnEnable()
    {
        dragDrop.OnPartChanged += UpdateNeedleOnPartChangedEvent;
    }

    void OnDisable()
    {
        dragDrop.OnPartChanged -= UpdateNeedleOnPartChangedEvent;
    }

    private void Update()
    {
        needleTranform.eulerAngles = new Vector3(0, 0, TranslateTimeUnitsToRotation());
    }

    private void UpdateNeedleOnPartChangedEvent(int amount)
    {
        currentTime += amount;
        currentTime = Mathf.Clamp(currentTime, 0f, timeMax);
        if (currentTime == 0f)
        {     
            Debug.Log("All Time Used!");
        }
    }


    private float TranslateTimeUnitsToRotation()
    {
        float totalAngleSize = ZERO_TIME_ANGLE - MAX_TIME_ANGLE;

        float timeNormalized = currentTime / timeMax;

        return ZERO_TIME_ANGLE - timeNormalized * totalAngleSize;
    }

}
