using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public Text bottomText;

    // Update is called once per frame
    void Update()
    {
        switch (GameController.instance.gameState)
        {
            case GameState.Start:
                scoreText.text = "";
                bottomText.text = "SPACEBAR TO FLAP!";
                break;
            case GameState.Play:
                scoreText.text = "Score: " + GameController.instance.score;
                bottomText.text = "";
                break;
            case GameState.GameOver:
                scoreText.text = "Score: " + GameController.instance.score;
                bottomText.text = "GAME OVER";
                break;
        }
    }
}
