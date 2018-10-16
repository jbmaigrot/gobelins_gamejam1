using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
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

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Command to restart the level
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1;
        }
        //Command Exit
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Exit the game when it is the hub
            if(SceneManager.GetActiveScene().name=="Hub")
            {
                Application.Quit();
            }
            //Exit the current level
            else
            {
                SceneManager.LoadScene("Hub");
            }
        }
    }
    //Load the level
    public void SetLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        
    }
    // Enable the trigger to end the level
    public void UnlockEnd()
    {
        Component[] colliders = Gm.GetComponentsInChildren<Collider2D>(false);
            foreach(Collider2D collider in colliders)
        {
            collider.enabled = true;
        }
    }
}
