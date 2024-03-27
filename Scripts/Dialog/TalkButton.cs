using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkButton : MonoBehaviour
{
    public GameObject Button;

    public GameObject talkUI;

    private void Awake()
    {
        EventCenter.Instance.AddEventListener("ShowDia", ShowDia); 
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        EventCenter.Instance.AddEventListener("HideBtn", HideBtn);
        EventCenter.Instance.AddEventListener("ShowBtn", ShowBtn);
        Button.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Button.SetActive(false);
    }

    void HideBtn()
    {
        if (Button != null)
        {
            Button.SetActive(false);
        }
    }
    void ShowBtn()
    {
        if (Button != null)
        {
            Button.SetActive(true);
        }
    }


    private void Update()
    {
        if(Button.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            PlayerMove.ISMove = false;
            Button.SetActive(false);
            talkUI.SetActive(true);
        }
    }

    void ShowDia()
    {
        if(this.gameObject.name == "NPC1" && Button.activeSelf)//在这添加NPC触发事件
        {
            Debug.Log("我启动了");
            PlayerMove.ISMove = false;
            Button.SetActive(false);
            talkUI.SetActive(true);
        }
        else
        {
            PlayerMove.ISMove = true;
        }
    }


}
