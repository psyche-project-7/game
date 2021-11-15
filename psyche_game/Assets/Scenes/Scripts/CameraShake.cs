using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public float shakeTime, shakeIntensity;

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            startShake(.1f, .1f);
        }
    }

    private void LateUpdate()
    {
        if(shakeTime > 0)
        {
            shakeTime -= Time.deltaTime;

            float xOffset = Random.Range(-.1f, .1f) * shakeIntensity;
            float yOffset = Random.Range(-.1f, .1f) * shakeIntensity;

            transform.position += new Vector3(xOffset, yOffset, 0f);
        }
    }

    public void startShake(float shakeTimeDesired, float intensity)
    {
        shakeTime = shakeTimeDesired;
        shakeIntensity = intensity;
    }
}