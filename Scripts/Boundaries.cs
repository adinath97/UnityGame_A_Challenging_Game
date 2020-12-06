using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boundaries : MonoBehaviour
{
    public AudioClip gameOverAudio;
    public float gameOverAudioVolume = .5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(this.tag == "bottom" && other.tag == "ball")
        {
            ScoreManager.hits++;
            if(ScoreManager.hits == 5)
            {
                StartCoroutine(WaitAndLoadRoutine());
            }
        }
        else if(this.tag == "top")
        {
            ScoreManager.score += 3;
        }
        else if (this.tag == "right" && other.tag == "ball")
        {
            ScoreManager.score++;
        }
        else if (this.tag == "left" && other.tag == "ball")
        {
            ScoreManager.score++;
        }
        if (other.tag == "ball")
        {
            Ball.currentBallDestroyed = true;
        }
        if (ScoreManager.score > PlayerPrefs.GetFloat("HighScore", 0f))
        {
            PlayerPrefs.SetFloat("HighScore", ScoreManager.score);
        }
    }

    IEnumerator WaitAndLoadRoutine()
    {
        Scene_Manager.gameOver = true;
        Count_Down.beginGame = false;
        AudioSource.PlayClipAtPoint(gameOverAudio, Camera.main.transform.position, gameOverAudioVolume);
        yield return new WaitForSeconds(2f);
        GameOverManager.finalScore = ScoreManager.score;
        SceneManager.LoadScene("GAME_OVER");
    }
}
