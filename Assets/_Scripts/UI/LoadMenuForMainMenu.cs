using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMenuForMainMenu : MonoBehaviour {

    public GameObject mLoad_p;
    public GameObject mMain_p;

    public void LoadMenuMain()
    {
        if (!mLoad_p.activeSelf)
        {
            mMain_p.SetActive(false);
            mLoad_p.SetActive(true);
        }
        else
        {
            mLoad_p.SetActive(false);
            mMain_p.SetActive(true);
        }
    }
}
