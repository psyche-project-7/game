using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustaScript : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyCode.Escape))
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex();
            Scenemanager.LoadScene(currentScene - 1);
        }
    }

    public void Next()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex().buildIndex;
        Scenemanager.LoadScene(currentScene + 1);
        sfxManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.Click);
    }

public void prev()
{
    int currentScene = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(currentScene - 1);
}
}
