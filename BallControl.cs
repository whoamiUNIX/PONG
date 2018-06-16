using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {

    public float RandomNumber;
    public float RND_Vector1;
    public float RND_Vector2;
    public Rigidbody2D ball;
    public float ball_initial_speed = 100;
    public Transform ball_reset;
    public int xVel;


    // SET SLEEP on START
    void Start () {
        StartCoroutine(Wait_on_start());
    }

    // Bost BALL velocity/speed in "X" direction in case that fall bellow speed
    // UPDATE BALL SPEED if drop under 18velocity on X     
    void Update()
    {
        ball = GetComponent<Rigidbody2D>();
        Vector2 xVel = ball.velocity;
        xVel = ball.velocity;
        if (xVel.x < 18 && xVel.x > -18 && xVel.x != 0)
        {
            if (xVel.x > 0)
            {
                Vector2 boostxVel = ball.velocity;
                boostxVel.x = 20;
                ball.velocity = boostxVel;
            }
            else
            {
                Vector2 boostxVel = ball.velocity;
                boostxVel.x = -20;
                ball.velocity = boostxVel;
            }
            //Debug.Log("before" + xVel.x);
            //Debug.Log("after" + ball.velocity);
        }
        
    }
    
    // SET SLEEP on RESET
    void Reset_balls()
    {
        ResetBall();
        StartCoroutine(ResetBall_wait());
    }

    // On collision to player change ball direction
    void OnCollisionEnter2D ( Collision2D colInfo) {
        ball = GetComponent<Rigidbody2D>();
        if (colInfo.collider.tag == "Player")
        { 
            ball.velocity = new Vector2(ball.velocity.x, ball.velocity.y / 2 + colInfo.collider.GetComponent<Rigidbody2D>().velocity.y / 3);
            AudioSource audio = GetComponent<AudioSource>();
            audio.pitch = Random.Range(0.8f, 1.2f);
            audio.Play();

        }
	}

    // RESET BALL to CENTER and SET initial SPEED to 0
    public void ResetBall()
    {
        ball = GetComponent<Rigidbody2D>();
        ball_reset = GetComponent<Transform>();

        ball.velocity = new Vector2(0, 0);
        ball_reset.position = new Vector2(0, 0);
    }

    // WAIT 1 SEC on reset and then startball
    public IEnumerator ResetBall_wait()
    {
        yield return new WaitForSeconds(1);
        StartBall();
    }


    // WAIT/SLEEP on START for 2seconds and then START ball
    IEnumerator Wait_on_start()
    {
        yield return new WaitForSeconds(2);
        StartBall();
    }

    // START ball to random side with variable speed
    public void StartBall()
    {
        ball = GetComponent<Rigidbody2D>();
        RandomNumber = Random.Range(1, 4);
        if (RandomNumber <= 2)
        {
            if (RandomNumber == 1)
            {
                RND_Vector1 = 15;
            }
            else
            {
                RND_Vector1 = -15;
            }
            ball.AddForce(new Vector2(ball_initial_speed, RND_Vector1));
        }
        else
        {
            if (RandomNumber == 3)
            {
                RND_Vector2 = 15;
            }
            else
            {
                RND_Vector2 = -15;
            }
            ball.AddForce(new Vector2(-ball_initial_speed, RND_Vector2));
        }

    }
}