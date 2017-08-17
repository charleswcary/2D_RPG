using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDddol : MonoBehaviour {

    static private HUDddol _instance;
    static public HUDddol instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<HUDddol>();
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
        set { }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (_instance != this)
                Destroy(gameObject);
        }
    }
}
