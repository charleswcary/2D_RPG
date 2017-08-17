using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaHUD : MonoBehaviour {

    static public ManaHUD instance;
    Text mpHUD_t;

    void Awake()
    {
        instance = this;
        mpHUD_t = GetComponent<Text>();
    }

    public void UpdateManaHUD(float currentMana, float maxMana)
    {
        mpHUD_t.text = currentMana + "/" + maxMana;
    }
}
