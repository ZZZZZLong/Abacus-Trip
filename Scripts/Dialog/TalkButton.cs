using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TalkButton : MonoBehaviour
{
    public GameObject Button;

    public GameObject talkUI;
    bool IsShow;



    private void OnTriggerEnter2D(Collider2D other)
    {
        EventCenter.Instance.AddEventListener<string>("ShowDia", ShowDia);
        EventCenter.Instance.AddEventListener("HideBtn", HideBtn);
        Button.SetActive(true);
        IsShow = true;
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        EventCenter.Instance.RemoveEventListener<string>("ShowDia", ShowDia);
        Button.SetActive(false);
        IsShow = false;
    }

    void HideBtn()
    {
        if (Button != null)
        {
            Button.SetActive(false);
        }
    }


    private void Update()
    {
        if (Button.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            PlayerMove.ISMove = false;
            Button.SetActive(false);
            talkUI.SetActive(true);
        }
    }

    void ShowDia(string Name)
    {
        if (gameObject.name == Name && IsShow)//在这添加NPC触发事件
        {
            Debug.Log(Name);
            EventCenter.Instance.EventTrigger("KeyDia"+Name, Name);
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
