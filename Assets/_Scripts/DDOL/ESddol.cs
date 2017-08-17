using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESddol : MonoBehaviour { //Event System Don't Destroy On Load

    static private ESddol _instance;
    static public ESddol instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ESddol>();
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
