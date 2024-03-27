using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkButton : MonoBehaviour
{
    public GameObject Button;

    public GameObject talkUI;


    private void OnTriggerEnter2D(Collider2D other)
    {
        EventCenter.Instance.AddEventListener("HideBtn", HideBtn);
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


    private void Update()
    {
        if(Button.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            PlayerMove.ISMove = false;
            Button.SetActive(false);
            talkUI.SetActive(true);
        }
    }
}
