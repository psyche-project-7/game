using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButtonHandler : MonoBehaviour
{
    public string playGameScene = "Strategy_scene";
    public void OnButtonPress()
    {
        Invoke("StartGame", 1);
    }

    private void StartGame()
    {
        SceneManager.LoadScene(playGameScene);
    }
}
