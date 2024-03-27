using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    Transform Player;
    Animator anim;
    bool isMove;
    public static bool ISMove = true;
    void Awake()
    {
        Player = transform.Find("Player");
        anim = Player.GetComponent<Animator>();
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        anim.SetBool("Move", isMove);

        Vector2 position = transform.position;
        if (Input.GetKey(KeyCode.A) && ISMove)
        {
            speed = 10;
            Quaternion newRotation = Quaternion.Euler(0, 180, 0);
            Player.transform.rotation = newRotation;
            isMove = true;
            if (transform.position.x < -2.01)
            {
                speed = 0;
                position.x = -2;
            }
            else
            {
                speed = 10;
            }
            position.x -= speed * Time.deltaTime;
            transform.position = position;
        }
        else if (Input.GetKey(KeyCode.D) && ISMove)
        {
            speed = 10;
            Quaternion newRotation = Quaternion.Euler(0, 0, 0);
            Player.transform.rotation = newRotation;
            isMove = true;
            position.x += speed * Time.deltaTime;
            transform.position = position;
        }
        else
        {
            isMove = false;
        }
        
            
        
    }

}
