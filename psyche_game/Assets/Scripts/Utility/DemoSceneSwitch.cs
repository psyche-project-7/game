using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoSceneSwitch : MonoBehaviour
{
    public string miniGame1;
    public string miniGame2;
    public string endScene;
    private bool pressed = false;

    //save things you want carried to the next scene here as static variables

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            startMiniGame1();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            startMiniGame2();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            startEndScene();
        }

    }
    private void startMiniGame1()
    {
        SceneManager.LoadScene(miniGame1);
    }

    private void startMiniGame2()
    {
        SceneManager.LoadScene(miniGame2);
    }

    private void startEndScene()
    {
        SceneManager.LoadScene(endScene);
    }

    public void playAltScene(string altScene)
    {
        SceneManager.LoadScene(altScene);
    }


}