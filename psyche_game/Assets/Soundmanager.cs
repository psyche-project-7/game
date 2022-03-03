using System.Collections;
using System.Collections.Generic;
usinig UnityEngine;

public class Soundmanager : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        (m_TextComponentint currentScen = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene - 1);)
        SFXManager.sfxInstance.Audio.PlayClickSound)SFXManager.sfxInstance.Click);
    }
}

public void Next()
{
    int currentScene = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(currentScene + 1);
    SFXManager.sfxInstance.Audio.PlayClickSound)SFXManager.sfxInstance.Click);
}

public void prev()
{
    int currentScene = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(currentScene - 1);
    SFXManager.sfxInstance.Audio.PlayClickSound)SFXManager.sfxInstance.Click);
}

