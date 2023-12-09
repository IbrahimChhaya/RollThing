using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //public GameObject ball;
    GameObject ball;
    Vector3 offset;
    public float lerpRate;
    public bool gameover;
    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
        //offset = GameObject.Find("Ball").transform.position - transform.position;
        offset = ball.transform.position - transform.position;
        gameover = false;
    }

    // Update is called once per frame
    /*void Update()
    {
        if (!gameover)
            Follow();
    }*/

    void FixedUpdate()
    {
        if (!gameover)
            Follow();
    }

    void Follow()
    {
        Vector3 pos = transform.position;
        Vector3 targetPos = ball.transform.position - offset;
        pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime);
        transform.position = pos;
    }
}
