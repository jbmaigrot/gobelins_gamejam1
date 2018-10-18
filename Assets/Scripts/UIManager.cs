using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager UImanager = null;
    private GameObject ui;

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
    void Start()
    {
        ui = GameObject.Find("UI");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamageUI(int nbLifes)
    {
        if (nbLifes >= 0)
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

    public void KillPlayerUI()
    {
        Component[] lifes = ui.transform.Find("Life").GetComponentsInChildren<Image>(true);
        foreach (Image life in lifes)
        {
            life.enabled = false;
        }
    }
}
