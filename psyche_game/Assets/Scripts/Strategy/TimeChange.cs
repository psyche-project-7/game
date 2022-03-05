using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeChange : MonoBehaviour
{
    public int timeValue = 10;
    public GameObject Timer;
    public GameObject timeCounter;

    public void changeTimeOnClick()
    {
        int timeLeft = Timer.GetComponent<Timekeeper>().timeValue - timeValue;
        Timer.GetComponent<Timekeeper>().timeValue = timeLeft;
        timeCounter.GetComponent<UnityEngine.UI.Text>().text = "Time Left: " + timeLeft;

    }
}
