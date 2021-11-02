using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timekeeper : MonoBehaviour
{
    public static int timeLeft = 50;
    public GameObject selectedPart;
    
    // Start is called before the first frame update
    public void changeTime(){
        int toChange = selectedPart.GetComponent<stats>().timeValue;
        timeLeft = timeLeft - toChange;

    }
}
