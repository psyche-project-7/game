using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public string nextScene;

    //save things you want carried to the next scene in this as static variables

    // Start is called before the first frame update
    public void OnButtonPress()
    {
        SceneManager.LoadScene(nextScene);
    }


}