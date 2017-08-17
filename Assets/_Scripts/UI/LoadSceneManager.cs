using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour {

	public void OnLoadTestScene()
    {
        SceneManager.LoadScene("TestScene");
        MenuManager.instance.mLoad_p.SetActive(false);
        Time.timeScale = 1;
    }
    public void OnLoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        MenuManager.instance.mPause_p.SetActive(false);
        Time.timeScale = 1;
    }
    public void OnExitGame()
    {
        Application.Quit();
    }
}
