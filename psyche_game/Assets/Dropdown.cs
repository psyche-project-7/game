using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropdown : MonoBehaviour
{
    public TextMeshProUGUI outputMesh;

    public void handleInputData(int val)
    {
        if (val == 0){
            output.text = "You're on the wrong rocketship!";
        }
         if (val == 1){
            output.text = "You better flip that switch!";
        }
         if (val == 2){
            output.text = "Please Don't cut the wrong wire!";
        }
    }
}
