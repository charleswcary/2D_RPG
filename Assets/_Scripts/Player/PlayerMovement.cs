using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rigid;
    Transform char1Spawn_transform;

    public float speed = 10;

    bool canMove_b = true;

    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("BattleGround") || SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMenu"))
        {
            canMove_b = false;
            anim.SetFloat("input_x", 1);
        }
        else
        {
            canMove_b = true;
        }
        if (movement != Vector2.zero && canMove_b)
        {
            anim.SetBool("isWalking", true);
            anim.SetFloat("input_x", movement.x);
            anim.SetFloat("input_y", movement.y);
            rigid.MovePosition(rigid.position + movement.normalized * speed * Time.deltaTime);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

    }
    void Update()
    {
        
    }

    

    
    
}
