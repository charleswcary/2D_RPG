using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    Rigidbody2D rigid_rb;
    Animator anim_ar;
    Vector2 movement_v2;
    public Vector2 startPos_v2;
    public Vector2 v2_dest;
    public Vector2 maxDest_v2;
    public Vector2 minDest_v2;

    float speed_f = 1f;
    float move_f = 1f;
    float wait_f = 3f;
    float xMin_f = -1f;
    float xMax_f = 1f;
    float yMin_f = -1f;
    float yMax_f = 1f;

    bool moving_b = false;
    bool waiting_b = false;

    void Start()
    {
        rigid_rb = GetComponent<Rigidbody2D>();
        anim_ar = GetComponent<Animator>();
        startPos_v2 = rigid_rb.transform.position;
        minDest_v2 = new Vector2(xMin_f + startPos_v2.x, yMin_f + startPos_v2.y);
        maxDest_v2 = new Vector2(xMax_f + startPos_v2.x, yMax_f + startPos_v2.y);
    }

    void Update()
    {

        if (moving_b)
        {
            v2_dest = rigid_rb.position + movement_v2 * speed_f * Time.deltaTime;

            if(v2_dest.x <= maxDest_v2.x && v2_dest.x >= minDest_v2.x && v2_dest.y <= maxDest_v2.y && v2_dest.y >= minDest_v2.y)
            {
                anim_ar.SetBool("isMoving", true);
                StartCoroutine(MoveTimer());
                anim_ar.SetFloat("dir_x", movement_v2.x);
                anim_ar.SetFloat("dir_y", movement_v2.y);
                rigid_rb.MovePosition(v2_dest);
            }
            
        }
        else if (!waiting_b && !moving_b)
        {
            anim_ar.SetBool("isMoving", false);
            StartCoroutine(WaitTimer());
            movement_v2 = new Vector2(Random.Range(-.5f, .5f), Random.Range(-.5f, .5f));
        }
    }

    IEnumerator MoveTimer()
    {
        waiting_b = false;
        yield return new WaitForSeconds(move_f);
        moving_b = false;
    }
    IEnumerator WaitTimer()
    {
        waiting_b = true;
        yield return new WaitForSeconds(wait_f);
        moving_b = true;
    }
}
