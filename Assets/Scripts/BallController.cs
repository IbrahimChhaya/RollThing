//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public static BallController instance;
    public GameObject particle;
    float speed;
    public bool started;
    bool gameover;
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        speed = 6;
        started = false;
        gameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if game is not started and button is pressed, start the game by moving ball 
        if (!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;

                GameManagerScript.instance.GameStart();
            }
        }

        Debug.DrawRay(transform.position, Vector3.down, Color.red);

        if (!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            gameover = true;
            rb.velocity = new Vector3(0, -25f, 0);
            Camera.main.GetComponent<CameraFollow>().gameover = true;
            GameManagerScript.instance.GameOver();
        }

        //if button pressed again, switch direction
        if (Input.GetMouseButtonDown(0) && !gameover)
            SwitchDirection();
    }

    void SwitchDirection()
    {
        if (PlayerPrefs.GetInt("score") > 10)
            speed = 7;
        if (PlayerPrefs.GetInt("score") > 30)
            speed = 8;
        //if ball is going in z direction, switch direction to x
        if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        //if ball is going in x direction, switch direction to z
        else if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        //if ball collides with diamond, destroy the diamond and update the score
        if (col.gameObject.tag == "Diamond")
        {
            GameObject part = Instantiate(particle, col.gameObject.transform.position, Quaternion.identity) as GameObject;
            //col.gameObject.GetComponentInChildren<Animator>().Play("ScorePop");
            Destroy(col.gameObject);
            //col.gameObject.GetComponentInChildren<Animator>().StopPlayback();
            Destroy(part, 1f);
            ScoreManagerScript.instance.score += 10;
        }
    }
}