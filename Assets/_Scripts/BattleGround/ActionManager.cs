using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour {

    public GameObject actionPanel_go;
    public GameObject magicList_go;

    public void MagicMenu()
    {
        magicList_go.SetActive(true);
    }
}
