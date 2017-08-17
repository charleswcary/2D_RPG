using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

    static public MenuManager instance;

    public GameObject mPause_p;
    public GameObject mLoad_p;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu();
        }
    }

    public void PauseMenu()
    {
        if (mPause_p.activeSelf)
        {
            mPause_p.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            mPause_p.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void LoadMenuPause()
    {
        if (!mLoad_p.activeSelf)
        {
            mPause_p.SetActive(false);
            mLoad_p.SetActive(true);
        }
        else
        {
            mPause_p.SetActive(true);
            mLoad_p.SetActive(false);
        }
    }
    
}
