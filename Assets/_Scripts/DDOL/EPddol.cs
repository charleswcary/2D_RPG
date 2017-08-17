using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EPddol : MonoBehaviour {
    static private EPddol _instance;
    static public EPddol instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<EPddol>();
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
