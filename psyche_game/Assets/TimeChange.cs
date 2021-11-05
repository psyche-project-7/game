using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeChange : MonoBehaviour
{
    int timeValue = 10;
    public GameObject Timer;

    public void changeTimeOnClick()
    {
        int timeLeft = Timer.GetComponent<Timekeeper>().timeValue;
        Timer.GetComponent<Timekeeper>().timeValue = timeLeft - timeValue;

    }
}
