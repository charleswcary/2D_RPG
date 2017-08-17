using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBarHUD : MonoBehaviour {

    static public ActionBarHUD instance;
    Image actionBarHUD_image;
    Color fillColor_c;
    void Awake()
    {
        instance = this;
        actionBarHUD_image = GetComponent<Image>();
        fillColor_c = actionBarHUD_image.color;
    }

    public void UPdateActionTimerHUD(float min, float max)
    {
        actionBarHUD_image.fillAmount = min / max;
    }
    void Update()
    {
        if (actionBarHUD_image.fillAmount == 1)
        {
            actionBarHUD_image.color = new Color32(255, 222, 39, 200);
        }
        else
            actionBarHUD_image.color = fillColor_c;
    }
}
