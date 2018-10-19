using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Gm = null;

    void Awake()
    {
        if (Gm == null)
        {
            Gm = this;
        }
        else if (Gm != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Command to restart the level
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Restart();
        }
        //Command Exit
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Exit the game when it is the hub
            if (SceneManager.GetActiveScene().name == "Menu")
            {
                Application.Quit();
            }
            //Exit the current level
            else
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    //Load the level
    public void SetLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}


