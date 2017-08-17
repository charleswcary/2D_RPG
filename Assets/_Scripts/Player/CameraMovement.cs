using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    GameObject target;
    Transform targetPos;
    Camera thisCam;

    float zPosCam;
    float scale = 4f;
    float speed = 0.1f;

    void Start()
    {
        thisCam = GetComponent<Camera>();
        zPosCam = thisCam.transform.position.z;
        target = GameObject.FindGameObjectWithTag("Player");
        targetPos = target.transform;
    }
    void Update()
    {
        thisCam.orthographicSize = (Screen.height / 100f / scale);

        if (target)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos.position, speed) + new Vector3(0, 0, zPosCam);
        }
    }
}
