using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    private float shakeIntensity = 0.5f;

    private bool rocketIsLaunching = false;
    private bool diminishShake = false;
    private float xBounds = 0.15f;
    private float yBounds = 0.15f;

    private Vector3 initialPosition;

    private float boundedxAbsMax;
    private float boundedxAbsMin;
    private float boundedyAbsMax;
    private float boundedyAbsMin;
    

    private void Awake()
    {
        initialPosition = transform.position;
        boundedxAbsMax = initialPosition.x + xBounds;
        boundedxAbsMin = initialPosition.x - xBounds;
        boundedyAbsMax = initialPosition.y + yBounds;
        boundedyAbsMin = initialPosition.y - yBounds;
    }

    void OnEnable()
    {
        shipTakeoffMove.OnRocketIsLaunching += beginRocketLaunchSequence;
    }

    void OnDisable() 
    {
        shipTakeoffMove.OnRocketIsLaunching -= beginRocketLaunchSequence;
    }

    public void beginRocketLaunchSequence()
    {
        rocketIsLaunching = true;
        Invoke("beginScreenShakeDiminish", 1.5f);
    }

    public void beginScreenShakeDiminish()
    {
        diminishShake = true;
    }

    public void LateUpdate()
    {
        if (rocketIsLaunching)
        {
            shakeScreen(shakeIntensity);

        }
        if (diminishShake && shakeIntensity > 0.0f)
        {
            shakeIntensity -= 0.001f;
        }

    }

    public void shakeScreen(float shakeIntensity)
    {

        float xOffset = Random.Range(-.1f, .1f) * shakeIntensity;
        float yOffset = Random.Range(-.1f, .1f) * shakeIntensity;
        float absX = transform.position.x + xOffset;
        float absY = transform.position.y + yOffset;

        if ((absX > boundedxAbsMax) || (absX < boundedxAbsMin))
        {
            xOffset = 0.0f;
        }
        if ((absY > boundedyAbsMax) || (absY < boundedyAbsMin))
        {
            yOffset = 0.0f;
        }

        transform.position += new Vector3(xOffset, yOffset, 0f);
    }
}