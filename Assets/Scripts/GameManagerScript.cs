using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    public static GameManagerScript instance;
    public bool gameOver;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        UiScript.instance.GameStart();
        //BallController.instance.setMagnet(true);
        ScoreManagerScript.instance.startScore();
        GameObject.Find("PlatformSpawner").GetComponent<PlatformSpawn>().StartSpawing();
    }

    public void GameOver()
    {
        UiScript.instance.GameOver();
        ScoreManagerScript.instance.stopScore();
        gameOver = true;
    }
}
