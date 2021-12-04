using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchButton : MonoBehaviour
{

    public delegate void RocketLaunchRequest();
    public static event RocketLaunchRequest OnRocketLaunchRequest;

    void OnMouseDown()
    {
        if (OnRocketLaunchRequest != null)
        {
            OnRocketLaunchRequest();
        }
    }
}
