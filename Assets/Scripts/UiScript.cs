using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiScript : MonoBehaviour
{
    public static UiScript instance;

    public GameObject titlePanel;
    public GameObject gameOverPanel;
    public GameObject tapText;
    public GameObject highScore;
    public GameObject currentScoreObj;
    public GameObject mainCamera;
    //public GameObject mainCameraDepth;
    public Text currentScore;
    public Text score;
    public Text highScore1;
    public Text highScore2;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        highScore1.text = "High Score: " + System.Convert.ToString(PlayerPrefs.GetInt("highScore"));
    }

    public void GameStart()
    {
        currentScoreObj.SetActive(true);
        titlePanel.GetComponent<Animator>().Play("PanelUp");
        titlePanel.SetActive(false);
        highScore.SetActive(false);
    }

    public void GameOver()
    {
        //if gameover, disable current score, enable gameOverPanel and display scores, fade background
        currentScoreObj.SetActive(false);
        score.text = System.Convert.ToString(PlayerPrefs.GetInt("score"));
        highScore2.text = System.Convert.ToString(PlayerPrefs.GetInt("highScore"));
        gameOverPanel.SetActive(true);

        /*var tempColour = gameOverPanel.transform.Find("Panel").GetComponent<Image>().color;
        tempColour.a = 30;
        tempColour = gameOverPanel.transform.Find("Panel").GetComponent<Image>().color;*/


        //stop following
        mainCamera.GetComponent<Camera>().enabled = true;
        mainCamera.GetComponent<CameraFollow>().gameover = true;

        //reset game if mousedown
        if (Input.GetMouseButtonDown(0))
            Reset();
    }

    public void Reset()
    {
        //reset to original
        SceneManager.LoadScene(0);   
    }
    // Update is called once per frame
    void Update()
    {
        //update score
        currentScore.text = System.Convert.ToString(PlayerPrefs.GetInt("score"));
    }
}
