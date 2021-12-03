using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public string nextScene;
    private bool pressed = false;

    //save things you want carried to the next scene here as static variables

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            pressed = !pressed;

        }
        if (pressed)
        {
            Invoke("switchScene", 2);
        }

    }
    public void switchScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void playAltScene(string altScene)
    {
        SceneManager.LoadScene(altScene);
    }


}