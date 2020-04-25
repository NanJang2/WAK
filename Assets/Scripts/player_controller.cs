using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{

    public float moveSpeed;
    public bool InputDisabled = false;
    public DialougeManager dmanager;
    
    private Animator anim;
    private Vector3 direction;
    private Rigidbody2D rb2d;

    private bool playerMoving;
    private Vector2 lastMove;
    private GameObject scanObject;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //scan obj
        if(Input.GetButtonDown("Jump") && scanObject != null)
        {
            if (scanObject.tag != "NPC")
            {
                dmanager.Action(scanObject);
                
            }
            else if (scanObject.tag == "NPC")
            {
                if(!dmanager.isAction)
                {
                    //대화창이 안 떠 있을 경우
                    //해당 npc의 다이얼로그를 큐에 탑재
                    scanObject.GetComponent<DialougeTrigger>().TriggerDialouge();
                }
                else if(dmanager.isAction)
                {
                    dmanager.DisplayNextSentence();
                }
            }   
        }

        
    }

    private void FixedUpdate()
    {
        if (!InputDisabled  && !dmanager.isAction )
        {
            Moving();

            //Debug.DrawRay(rb2d.position, direction * 0.7f, new Color(0, 1, 0));

        }
        RaycastHit2D rayHit = Physics2D.Raycast(rb2d.position, direction, 0.7f, LayerMask.GetMask("Object"));
        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
        {
            scanObject = null;
        }
    }

    void Moving()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        playerMoving = false;
        Vector2 position = rb2d.position;

        if (h > 0f || h < 0f)
        {
            //transform.Translate(new Vector3(h * moveSpeed * Time.deltaTime, 0f, 0f));
            position.x = position.x + h * moveSpeed * Time.deltaTime;
            playerMoving = true;
            lastMove = new Vector2(h, 0f);
        }
        if (v > 0f || v < 0f)
        {
            //transform.Translate(new Vector3(0f, v * moveSpeed * Time.deltaTime, 0f));
            position.y = position.y + v * moveSpeed * Time.deltaTime;
            playerMoving = true;
            lastMove = new Vector2(0f, v);
        }

        rb2d.MovePosition(position);

        anim.SetFloat("MoveX", h);
        anim.SetFloat("MoveY", v);
        anim.SetBool("isMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
        
        if(v == 1)
            direction = Vector3.up;
        else if(v == -1)
            direction = Vector3.down;
        else if(h == 1)
            direction = Vector3.right;
        else if(h == -1)
            direction = Vector3.left;

    }
  
}
