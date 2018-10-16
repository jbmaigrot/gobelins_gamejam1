using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
    public static UIManager UImanager = null;
    private GameObject ui;
    public Text levelName;
    
    void Awake()
    {
        if (UImanager == null)
        {
            UImanager = this;
        }
        else if (UImanager != this)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        ui = GameObject.Find("UI");
        SetLevelNameUI(SceneManager.GetActiveScene().name);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamageUI(int nbLifes)
    {
        if(nbLifes >= 0)
        {
            ui.transform.Find("Life").GetChild(nbLifes).GetComponent<Image>().enabled = false;
        }
    }

    public void ResetLifesUI()
    {
        Component[] lifes = ui.transform.Find("Life").GetComponentsInChildren<Image>(true);
        foreach (Image life in lifes)
        {
            life.enabled = true;
        }
    }

    public void SetLevelNameUI(string sceneName)
    {
        levelName.text = sceneName;
    }

    public void KillPlayerUI()
    {
        Component[] lifes = ui.transform.Find("Life").GetComponentsInChildren<Image>(true);
        foreach (Image life in lifes)
        {
            life.enabled = false;
        }
    }
}
