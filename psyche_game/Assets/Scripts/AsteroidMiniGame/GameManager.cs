using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void EndGame ()

        {
            Invoke("switchScene", 2);
        }

        private void switchScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
