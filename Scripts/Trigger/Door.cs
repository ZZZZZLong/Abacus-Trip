using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject Button;
    // Start is called before the first frame update
    private void Start()
    {
        Button.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        Button.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Button.SetActive(false);
    }

    private void Update()
    {
        if (Button.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("yep");
            PlayerMove.ISMove = false;
            Button.SetActive(false);
            CanEnter();
        }
    }
    void CanEnter()
    {
        bool isCanEnter = (GameManager.Instance.isCanEnter_1) && (GameManager.Instance.isCanEnter_2);
        if (isCanEnter)
        {
            UIManager.Instance.OpenPanel(UIConst.Sure);
        }
        else
        {
            UIManager.Instance.OpenPanel(UIConst.Block);
        }
    }
}
