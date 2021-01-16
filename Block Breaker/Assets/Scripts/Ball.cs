using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    // config params
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] float randomFactor = 0.2f;
    [SerializeField] AudioClip[] ballSounds;




    //state
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    //Cached componoent references
    AudioSource myAudioSource;
    Rigidbody2D myRidgidBody2D;


    // Start is called before the first frame update
    void Start()
    {
        
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRidgidBody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        LockBallToPaddle();
        LaunchBallOnClick();
    }


    private void LockBallToPaddle()
    {
        if (!hasStarted)
        {
            Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
            transform.position = paddlePos + paddleToBallVector;
        }
    }

    private void LaunchBallOnClick()
    {
        if (Input.GetMouseButtonDown(0) && !hasStarted)
        {
            myRidgidBody2D.velocity = new Vector2(xPush, yPush);
            hasStarted = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2
            (Random.Range(0f, randomFactor),
            Random.Range(0f, randomFactor));
        if (hasStarted)
        {
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRidgidBody2D.velocity += velocityTweak;
        }
    }

}
