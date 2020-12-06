using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    public static bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver == true)
        {
            LoadGameOverScene();
        }
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("GAME_OVER");
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game_Scene");
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene("START_MENU");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadInstructionsScene()
    {
        SceneManager.LoadScene("INSTRUCTIONS");
    }
}
