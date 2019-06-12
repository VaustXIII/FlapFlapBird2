using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public Rigidbody2D rigidBody;

    public float gravity = 3;
    public float flapSpeed = 10;

    public float maxAngle;
    public float minAngle;
    public float anglularSpeed;
    public float anglularAcceleration;

    public AudioSource birdAudio;
    public AudioClip flapSfx;
    public AudioClip scoreSfx;
    public AudioClip deathSfx;

    private void Start()
    {
        rigidBody.AddTorque(10);
    }

    // Update is called once per frame
    void Update()
    {
        switch(GameController.instance.gameState)
        {
            case GameState.Start:
            case GameState.GameOver:
                rigidBody.gravityScale = 0;
                rigidBody.velocity = Vector2.zero;
                rigidBody.angularVelocity = 0;
                break;
            case GameState.Play:
                rigidBody.gravityScale = gravity;
                Flap();
                Rotate();
                break;
        }
        
    }

    private void Flap()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.velocity = Vector2.up * flapSpeed;
            rigidBody.angularVelocity = anglularSpeed;

            birdAudio.clip = flapSfx;
            birdAudio.Play();
        }
    }

    private void Rotate()
    {
        rigidBody.rotation = Mathf.Min(rigidBody.rotation, maxAngle);
        rigidBody.rotation = Mathf.Max(rigidBody.rotation, minAngle);
        rigidBody.angularVelocity -= anglularAcceleration * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ScoreObj")
        {
            GameController.instance.Scored();
            birdAudio.clip = scoreSfx;
            birdAudio.Play();
        } else
        {
            GameController.instance.GameOver();
            birdAudio.clip = deathSfx;
            birdAudio.Play();
        }
    }

}
