using System.Collections;
using System.Collections.Generic;
using UnityEngine;
UnityEngine.SceneManagement

public class ChangeScene : MonoBehaviour
{
    public string SceneName;

    // Update is called once per frame
    public void ChangeToScene()
    {
        SceneManager.LoadScene(SceneName);
    }
}
