using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public GameObject ScoreText;
    public GameObject HighScoreText;
    public static float finalScore;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText.GetComponent<Text>().text =  "SCORE: " + finalScore.ToString();
        HighScoreText.GetComponent<Text>().text = "BEST: " + PlayerPrefs.GetFloat("HighScore", 0f).ToString();
    }
}
