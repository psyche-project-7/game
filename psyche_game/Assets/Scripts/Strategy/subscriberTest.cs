using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subscriberTest : MonoBehaviour
{

    void OnEnable()
    {
        eventTest.OnDeletePressed += printDeletePressedCount;
    }

    void OnDisable()
    {
        eventTest.OnDeletePressed -= printDeletePressedCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void printDeletePressedCount(int pressCount)
    {
        Debug.Log("printDeletePressedCount was called and the pressCount is " + pressCount);
    }
}
