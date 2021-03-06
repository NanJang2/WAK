﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{

    public float moveSpeed;
    public bool InputDisabled = false;


    private Animator anim;
    private Rigidbody2D rigid;

    bool playerMoving;
    Vector2 lastMove;

    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!InputDisabled)
        {
            Moving();
        }
    }

    void Moving()
    {
        playerMoving = false;

        //if (Input.GetAxisRaw("Horizontal") > 0f || Input.GetAxisRaw("Horizontal") < 0f)
        //{
        //    transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
        //    playerMoving = true;
        //    lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        //}
        //if (Input.GetAxisRaw("Vertical") > 0f || Input.GetAxisRaw("Vertical") < 0f)
        //{
        //    transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
        //    playerMoving = true;
        //    lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        //}

        Vector2 MovePostion = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
        rigid.MovePosition((Vector2)this.transform.position + (MovePostion * moveSpeed * Time.deltaTime));
        
        if (MovePostion != Vector2.zero)
        {
            playerMoving = true;
            lastMove = MovePostion;
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("isMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }
}
