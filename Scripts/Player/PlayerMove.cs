using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    Animator Player_anim;
    Vector2 position;
    bool isMove;
    public static bool ISMove = true;

    void Awake()
    {
        Player_anim = GetComponent<Animator>();
        //if(GameManager.Instance.FileName != null )
        //{
        //    GameManager.Instance.InitLoad(GameManager.Instance.FileName);
        //}
        position = transform.position;
    }
    

    void Update()
    {
        Move();
    }

    public void Move()
    {
        Player_anim.SetBool("Move", isMove);
        if (Input.GetKey(KeyCode.A) && ISMove)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            isMove = true;
            //if (transform.position.x < -2.01)
            //{
            //    speed = 0;
            //    position.x = -2;
            //}
            //else
            //{
            //    speed = 10;
            //}//¿ÕÆøÇ½±¿·½·¨


            position.x -= speed * Time.deltaTime;
            transform.position = position;
        }
        else if (Input.GetKey(KeyCode.D) && ISMove)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
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
