using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeOff : MonoBehaviour
{
    public ParticleSystem smoke;
    public ParticleSystem combustion;
    private bool pressed = false;


    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            pressed = !pressed;

        }
        if (pressed)
        {
            smoke.Play();
            combustion.Play();
            CameraShake.instance.Shake(0.25f, 4f);
        } else
        {
            smoke.Stop();
            combustion.Stop();
        }


    }
}
