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
    string SceneName;

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
        SceneName = GameManager.Instance.SceneName();
        Move();
    }

    public void MoveAudio()
    {
        SoundManager.Instance.PlayLoopSound(Globals.Move);
    }

    public void Move()
    {
        
        Player_anim.SetBool("Move", isMove);
        if (Input.GetKey(KeyCode.A) && ISMove)
        {
            speed = 5f;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            isMove = true;
            if(SceneName == "Scene_1" || SceneName == "Scene_3"|| SceneName == "Scene_4" || SceneName == "Scene_6")
            {
                if (transform.position.x < -2.01)
                {
                    speed = 0;
                    position.x = -2;
                }
            }
            else if(SceneName == "Scene_2" || SceneName == "Scene_5")
            {
                if (transform.position.x < -7.01)
                {
                    speed = 0;
                    position.x = -7;
                }
            }
            position.x -= speed * Time.deltaTime;
            transform.position = position;
        }
        else if (Input.GetKey(KeyCode.D) && ISMove)
        {
            speed = 5f;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            isMove = true;
            position.x += speed * Time.deltaTime;
            transform.position = position;

            if (SceneName == "Scene_1" || SceneName == "Scene_3" || SceneName == "Scene_4"|| SceneName == "Scene_6")
            {
                if (transform.position.x > 35.01)
                {
                    speed = 0;
                    position.x = 35;
                }//¿ÕÆøÇ½
            }
            else if (SceneName == "Scene_2"|| SceneName == "Scene_5")
            {
                if (transform.position.x > 7.51)
                {
                    speed = 0;
                    position.x = 7.5f;
                }//¿ÕÆøÇ½
            }
        }
        else
        {
            isMove = false;
        }
    }

}
