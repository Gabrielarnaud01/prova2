using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public int totalScore;
    public Text scoreText;

    public static GameController instance;

    public Text timeText;
    public float timeCount;

    public static bool stopTime;
        

    public GameObject GameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        stopTime = false;
    }

    private void Update()
    {
        if (stopTime==false)
        {
            timeCount = timeCount + Time.deltaTime;
            timeText.text = timeCount.ToString("f0");
        }
    }

    public void updateScoreTxt()
    {
        scoreText.text = totalScore.ToString();
    }

    public void GameOver()
    {
        GameOverUI.SetActive(true);
    }

    public void RestartGame(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }

}


    