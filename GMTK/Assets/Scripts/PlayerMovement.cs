using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CircleCollider2D playerCollider;
    public Rigidbody2D PlayerRb;
    public float speed = 2;
    public static bool isRandomizingSpell = false;
    public bool canMove = true;
    //public Animator PlayerAnim;

    // Start is called before the first frame update
    void Awake()
    {
        playerCollider = transform.GetComponent<CircleCollider2D>();
        PlayerRb = transform.GetComponent<Rigidbody2D>();
        PlayerRb.constraints = RigidbodyConstraints2D.FreezeRotation;
        PlayerRb.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isRandomizingSpell)
        {
            canMove = true;
        }
        else
        {
            canMove = false;
        }
    }

    void FixedUpdate()
    {
        if(canMove)
        {
            Move();
        }
    }

    public void Move()
    {
        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                PlayerRb.velocity = new Vector2(-speed, PlayerRb.velocity.y);
                transform.eulerAngles = new Vector3(0, 180, 0);
            }

            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                PlayerRb.velocity = new Vector2(speed, PlayerRb.velocity.y);
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
       else
       {
           PlayerRb.velocity = new Vector2(0, 0); 
       }
    }
}
