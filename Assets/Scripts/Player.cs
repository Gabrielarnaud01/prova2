using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float Speed;
    private Rigidbody2D rig;
    public float Jumpforce;

    public bool isJumping;
    public bool doubleJump;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        OnAnimatorMove();
        Jump();
    }

    private void OnAnimatorMove()
    {
        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f,0f);
        //transform.position += movement * Time.deltaTime * Speed;

        float movement = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2 (movement * Speed, rig.velocity.y);

        if (movement > 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        if (movement < 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        if (movement == 0f)
        {
            anim.SetBool("walk", false);
        }

    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if(!isJumping)
            {
                rig.velocity=new Vector2(rig.velocity.x, Jumpforce);
                doubleJump = true;
                anim.SetBool("jump", true);
            }
            else
            {
                if (doubleJump)
                {
                    rig.velocity = new Vector2(rig.velocity.x, Jumpforce);
                    doubleJump = false;
                }
            }
            
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            isJumping = false;
            anim.SetBool("jump", false);
        }

        if (collision.gameObject.tag == "spike")
        {
            GameController.instance.GameOver();
            Destroy(gameObject);
        }


    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isJumping = true;
            doubleJump = true;
        }
    }

    private void WinGame()
    {
        GameController.stopTime = true;
    }
}
