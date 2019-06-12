using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Start,
    Play,
    GameOver,
}

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public AudioSource musicSource;
    public int score { get; private set; }
    public GameState gameState { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        gameState = GameState.Start;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (gameState)
            {
                case GameState.Start:
                    Play();
                    break;
                case GameState.GameOver:
                    SceneManager.LoadScene("MainScene");
                    break;
            }
        }

    }

    public void Scored()
    {
        score++;
    }

    public void Play()
    {
        gameState = GameState.Play;
        musicSource.Play();
    }

    public void GameOver()
    {
        gameState = GameState.GameOver;
        musicSource.Stop();
    }
}
