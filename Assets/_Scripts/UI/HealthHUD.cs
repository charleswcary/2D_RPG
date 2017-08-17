using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthHUD : MonoBehaviour {

    static public HealthHUD instance;
    TextMeshProUGUI hpHUD_text;

    void Awake()
    {
        instance = this;
        hpHUD_text = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateHealthHUD(float currentHealth, float maxHealth)
    {
        hpHUD_text.text = currentHealth + "/" + maxHealth;
    }
}
