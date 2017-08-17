using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DMddol : MonoBehaviour { //Dungeon Master Don't Destroy On Load

    static private DMddol _instance;
    static public DMddol instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<DMddol>();
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
