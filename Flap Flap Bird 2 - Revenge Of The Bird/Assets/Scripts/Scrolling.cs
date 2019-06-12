using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    public float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        switch (GameController.instance.gameState)
        {
            
            case GameState.GameOver:
                break;
            case GameState.Start:
            case GameState.Play:
                transform.Translate(-speed * Time.deltaTime, 0, 0);
                break;
        }
        
    }
}
