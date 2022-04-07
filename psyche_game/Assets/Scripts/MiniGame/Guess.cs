using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guess : MonoBehaviour  {
    
    public Text messageText;
    public InputField guessInput;
    public int computersNumber;
    public int numberOfGuesses = 10;
    public Button guessButton;
    public Button nextButton;
    public Image flash;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() {
        messageText.text = "You have 10 guesses. Please type guess in the box below.";
        computersNumber = Random.Range(1,101);
    }
    public void GetGuess()  {
        numberOfGuesses--;
        string guessString = guessInput.text;
        int guessInt = System.Convert.ToInt32(guessString);
        if (guessInt > computersNumber) {
            messageText.text = "Too high. Guess lower";
            flashScreen(Color.red);
        } else if (guessInt < computersNumber)  {
            messageText.text = "Too low. Guess higher";
            flashScreen(Color.red);
        } else  {
            messageText.text = "Correct! Click next";
            GameOver();
        }
        if(numberOfGuesses <= 0)    {
            messageText.text = "Out of guesses. The answer was " + computersNumber;
            GameOver();
        }
    }

    void flashScreen(Color c)
    {
        flash.color = c;
        flash.canvasRenderer.SetAlpha(.5f);
        Invoke("endFlash", .2f);
    }

    void endFlash()
    {
        flash.canvasRenderer.SetAlpha(0);
    }

    void GameOver() {
        guessInput.gameObject.SetActive(false);
        guessButton.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(true);

    }
}
