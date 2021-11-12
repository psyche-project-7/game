using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public static CameraShake instance;

    void Awake()
    {
        instance = this;
    }

    public IEnumerator Shake(float duration, float amount)
    {
        Vector3 originalPos = new Vector3(0, 0, 0);
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float xOffset = Random.Range(-.5f, .5f) * amount;
            float yOffset = Random.Range(-.5f, .5f) * amount;
            transform.localPosition = new Vector3(xOffset, yOffset, 0);

            elapsedTime += Time.deltaTime;

            yield return null;
        }
        transform.localPosition = originalPos;
    }


}