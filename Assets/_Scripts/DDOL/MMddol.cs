using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMddol : MonoBehaviour {

    static private MMddol _instance;
    static public MMddol instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<MMddol>();
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
