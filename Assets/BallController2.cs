using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController2 : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float speed = 5f;
    public Vector3 vel;
    public bool isPlaying;
    public ScoreManagement scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        ResetAndSendBallInRandomDirection();
        ResetBall();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isPlaying == false)
        {
            ResetAndSendBallInRandomDirection();
        }
    }

    private void ResetAndSendBallInRandomDirection()
    {
        ResetBall();
        rb2D.velocity = GenerateRandomVelocity(true) * speed;
        vel = rb2D.velocity;
        isPlaying = true;
    }

    private void ResetBall()
    {
        rb2D.velocity = Vector3.zero;
        transform.position = Vector3.zero;
        isPlaying = false;
    }
          
    

    private Vector3 GenerateRandomVelocity(bool shouldReturnNormalized)
    {
        Vector3 velocity = new Vector3();
        bool shouldGoRight = Random.Range(1, 100) > 50;
        velocity.x = shouldGoRight ? Random.Range(-0.8f, -0.3f): Random.Range(0.8f, 0.3f);
        velocity.y = shouldGoRight ? Random.Range(-0.8f, -0.3f): Random.Range(0.8f, 0.3f);

        if (shouldReturnNormalized)
        {
            return velocity.normalized;
        }

        return velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 newVelocity = vel;
        newVelocity += new Vector3(Random.Range(-.5f, .5f), Random.Range(-.5f, .5f));
        rb2D.velocity = Vector3.Reflect(newVelocity.normalized * speed, collision.contacts[0].normal);
        vel = rb2D.velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.position.x > 0)
            scoreManager.IncrementLeftPlayerScore();


        if (transform.position.x < 0)
             scoreManager.IncrementRightPlayerScore();

        ResetAndSendBallInRandomDirection();
        ResetBall();
    }
    




}
