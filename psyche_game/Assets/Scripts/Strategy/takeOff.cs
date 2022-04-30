using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeOff : MonoBehaviour
{

    public ParticleSystem combustion;

    void OnEnable()
    {
        LaunchButton.OnRocketLaunchRequest += beginRocketLaunchSequence;
    }

    void OnDisable()
    {
        LaunchButton.OnRocketLaunchRequest -= beginRocketLaunchSequence;
    }

    public void beginRocketLaunchSequence()
    {
        combustion.Play();
    }

}
