using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventTest : MonoBehaviour
{

    public delegate void DeletePressed(int pressCount);
    public static event DeletePressed OnDeletePressed;

    private int pressCount = 0;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("backspace"))
        {
            pressCount += 1;
            if (OnDeletePressed != null) // in case noone has subscribed
            {
                OnDeletePressed(pressCount);
            }
            
        }
    }
}
