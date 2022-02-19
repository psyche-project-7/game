using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public string nextScene;
    //save things you want carried to the next scene here as static variables
    private bool pressed = false;
    static int[] minigamesPlayed = {0, 0, 0, 0};
    static string[] selectedParts = {"", "", ""};

    
    public void setPart(string part, string spriteName) {
        if (part.Equals("body")){
            selectedParts[0] = spriteName;
        } else if (part.Equals("booster")){
            selectedParts[1] = spriteName;
        } else if (part.Equals("capsule")){
            selectedParts[2] = spriteName;
        }

    }

    public string getBody() {
        return selectedParts[0];
    }

    public string getBooster() {
        return selectedParts[1];
    }

    public string getCapsule() {
        return selectedParts[2];
    }

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


    public static void playAltScene(string altScene)
    {
        SceneManager.LoadScene(altScene);
    }

    public void addMiniGame(int num)
    {
        minigamesPlayed[num - 1] = 1;
    }

    public bool checkPlayed(int num)
    {
        if (minigamesPlayed[num-1] == 0)
        {
            return false;
        } else
        {
            return true;
        }
    }

}