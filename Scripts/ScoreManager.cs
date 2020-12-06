using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject ScoreText;
    public GameObject HitsText;
    public GameObject HighScoreText;
    public GameObject tShieldsLeftText;
    public static int score;
    public static int hits;
    public static int tShields;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        hits = 0;
        ScoreText.GetComponent<Text>().text = "Score: 0";
        HitsText.GetComponent<Text>().text = "Hits: 5";
        tShieldsLeftText.GetComponent<Text>().text = "T-Shields: 5";
        tShields = 5;
        HighScoreText.GetComponent<Text>().text = "Best: " + PlayerPrefs.GetFloat("HighScore", 0f).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.GetComponent<Text>().text = "Score: " + score;
        HitsText.GetComponent<Text>().text = "Hits: " + (5 - hits);
        tShieldsLeftText.GetComponent<Text>().text = "T-Shields: " + tShields;
        HighScoreText.GetComponent<Text>().text = "Best: " + PlayerPrefs.GetFloat("HighScore", 0f).ToString();
    }
}
